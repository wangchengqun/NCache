// Copyright (c) 2015 Alachisoft
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//    http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ===============================================================================
// Alachisoft (R) NCache Integrations
// NCache Provider for NHibernate
// ===============================================================================
// Copyright © Alachisoft.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// ===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alachisoft.NCache.Integrations.NHibernate.Cache.Configuration;
using NHibernate;
using NHibernate.Cache;

namespace Alachisoft.NCache.Integrations.NHibernate.Cache
{
    class NCache : ICache
    {
        private static readonly IInternalLogger _logger = LoggerProvider.LoggerFor(typeof(Alachisoft.NCache.Integrations.NHibernate.Cache.NCacheProvider));
        private static Dictionary<string, CacheHandler> _caches = new Dictionary<string, CacheHandler>();
       
        private CacheHandler _cacheHandler = null;
        private readonly RegionConfiguration _regionConfig = null;
        private string _regionName = null;
        private string _connectionString = null;

        /// <summary>
        /// Initializes new cache region.
        /// </summary>
        /// <param name="regionName">Name of region.</param>
        /// <param name="properties"></param>
        public NCache(string regionName, IDictionary<string, string> properties)
        {
            try
            {
                if (_logger.IsDebugEnabled)
                {
                    _logger.Debug(String.Format("Initializing NCache with region : {0}", regionName));
                }

                _regionName = regionName;
                _regionConfig = ConfigurationManager.Instance.GetRegionConfiguration(regionName);

                lock (_caches)
                {
                    if (_caches.ContainsKey(_regionConfig.CacheName))
                    {
                        _cacheHandler = _caches[_regionConfig.CacheName];
                        _cacheHandler.IncrementRefCount();
                    }
                    else
                    {
                        _cacheHandler = new CacheHandler(_regionConfig.CacheName, ConfigurationManager.Instance.ExceptionEnabled);
                        _caches.Add(_regionConfig.CacheName, _cacheHandler);
                    }
                }

                if (properties["connection.connection_string"] != null)
                {
                    _connectionString = Convert.ToString(properties["connection.connection_string"]);
                }
            }
            catch (Exception e)
            {
                if (_logger.IsErrorEnabled)
                {
                    _logger.Error("Failed to initialize NCache. " + e.Message);
                }
                throw new CacheException("Failed to initialize NCache. "+e.Message,e);
            }
        }


        #region ICache Members
        /// <summary>
        /// Clear cache.
        /// </summary>
        public void Clear()
        {
            try
            {
                if (_logger.IsDebugEnabled)
                {
                    _logger.Debug(String.Format("Clearing Region Cache : {0}", _regionName));
                }

                _cacheHandler.Cache.Clear();

            }
            catch (Exception e)
            {
                if (_logger.IsErrorEnabled)
                {
                    _logger.Error("Clear operaion failed." + e.Message);
                }
                throw new CacheException("Clear operaion failed." + e.Message, e);
            }
        }

        /// <summary>
        /// Disposes cache.
        /// </summary>
        public void Destroy()
        {
            try
            {
                lock (_caches)
                {
                    if (_cacheHandler != null)
                    {
                        if (_logger.IsDebugEnabled)
                        {
                            _logger.Debug(String.Format("Destroying Region Cache : {0}", _regionName));
                        }
                        if (_cacheHandler.DecrementRefCount() == 0)
                        {
                            _caches.Remove(_regionConfig.CacheName);
                            _cacheHandler.DisposeCache();
                        }
                        _cacheHandler = null;
                    }
                }
            }
            catch (Exception e)
            {
                if (_logger.IsErrorEnabled)
                {
                    _logger.Error("Destroy operation failed." + e.Message);
                }
                throw new CacheException("Destroy operation failed." + e.Message, e);
            }
        }

        /// <summary>
        /// Get object from cache
        /// </summary>
        /// <param name="key">key of the object.</param>
        /// <returns></returns>
        public object Get(object key)
        {
            try
            {
                if (key == null)
                    return null;

                string cacheKey = ConfigurationManager.Instance.GetCacheKey(key);
                if (_logger.IsDebugEnabled)
                {
                    _logger.Debug(String.Format("Fetching object from the cache with key = {0}", cacheKey));
                }

                return _cacheHandler.Cache.Get(cacheKey);
            }
            catch (Exception e)
            {
                if (_logger.IsErrorEnabled)
                {
                    _logger.Error("Get operation failed. " + e.Message);
                }
                throw new CacheException("Get operation failed. " + e.Message, e);
            }
        }

        public void Lock(object key)
        {
            
        }

        public long NextTimestamp()
        {
            return Timestamper.Next();
        }

        /// <summary>
        /// Insert an object in cahce with key specified.
        /// </summary>
        /// <param name="key">key of the object.</param>
        /// <param name="value">Object to be inserted in cache.</param>
        public void Put(object key, object value)
        {
            try
            {
                if (key == null)
                    throw new ArgumentNullException("key", "null key not allowed");

                if (value == null)
                    throw new ArgumentNullException("value", "null value not allowed");

                string cacheKey = ConfigurationManager.Instance.GetCacheKey(key);

                Alachisoft.NCache.Web.Caching.CacheItem item = new Web.Caching.CacheItem(value);
                item.Priority = _regionConfig.CacheItemPriority;
               
                

                if (_regionConfig.ExpirationType.ToLower() == "sliding")
                    item.SlidingExpiration = new TimeSpan(0, 0, _regionConfig.ExpirationPeriod);
                else if (_regionConfig.ExpirationType.ToLower() == "absolute")
                    item.AbsoluteExpiration = DateTime.Now.AddSeconds(_regionConfig.ExpirationPeriod);


                    if (_logger.IsDebugEnabled)
                    {
                        _logger.Debug(String.Format("Inserting: key={0}&value={1}", key, value.ToString()));
                    }
                    _cacheHandler.Cache.Insert(cacheKey, item);
            }
            catch (Exception e)
            {
                if (_logger.IsErrorEnabled)
                {
                    _logger.Error("Put operation failed. " + e.Message);
                }
                throw new CacheException("Put operation failed. " + e.Message, e);
            }
        }

        /// <summary>
        /// RegionName associated with current cache.
        /// </summary>
        public string RegionName
        {
            get { return _regionName; }
        }

        /// <summary>
        /// Remove an object from cache.
        /// </summary>
        /// <param name="key">Key of the object.</param>
        public void Remove(object key)
        {
            try
            {
                string cacheKey = ConfigurationManager.Instance.GetCacheKey(key);
                   
                    if (_logger.IsDebugEnabled)
                    {
                        _logger.Debug("Removing item with key: " + cacheKey);
                    }
                    _cacheHandler.Cache.Remove(cacheKey);
            }
            catch (Exception e)
            {
                if (_logger.IsErrorEnabled)
                {
                    _logger.Error("Remove operation failed. " + e.Message);
                }
                throw new CacheException("Remove operation failed. " + e.Message, e);
            }
        }

        public int Timeout
        {
            get { return Timestamper.OneMs*60000; }
        }

        public void Unlock(object key)
        {

        }

        #endregion
    }
}
