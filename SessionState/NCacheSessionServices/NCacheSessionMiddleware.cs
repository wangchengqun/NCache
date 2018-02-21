﻿// Copyright (c) 2018 Alachisoft
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
// limitations under the License

using System;
using System.Threading.Tasks;
using Alachisoft.NCache.Web.SessionState.Configuration;
using Alachisoft.NCache.Web.SessionState.Interface;
using Alachisoft.NCache.Web.SessionState.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;

namespace Alachisoft.NCache.Web.SessionState
{
    public class NCacheSessionMiddleware
    {

        private readonly ISessionStoreService _sessionStoreService;
        private readonly RequestDelegate _next;
        private readonly NCacheSessionConfiguration _options;

        public NCacheSessionMiddleware(RequestDelegate next, ISessionStoreService sessionStoreService,
            IOptions<NCacheSessionConfiguration> options)
        {
            _sessionStoreService = sessionStoreService;
            _next = next;
            _options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            string sessionId = null;
            NCacheSession session = null;
            try
            {
                bool isNewSession, isReadOnly = false;
                sessionId = _sessionStoreService.GetSessionKey(context, out isNewSession);
                context.Response.OnStarting(ApplySessionKey, new object[] {context, sessionId});
                //If the request is readonly
                object readOnlyValue;
                if (context.Items.TryGetValue(_options.ReadOnlyFlag, out readOnlyValue))
                {
                    try
                    {
                        isReadOnly = (bool) readOnlyValue;
                    }
                    catch
                    {

                    }
                }

                session = new NCacheSession(context, sessionId, _sessionStoreService, isReadOnly,
                    isNewSession, _options.RequestTimeout, TimeSpan.FromMinutes(_options.SessionOptions.IdleTimeout));
                await session.LoadAsync();

                var feature = new NCacheSessionFeature {Session = session};
                context.Features.Set<ISessionFeature>(feature);
            }
            catch (Exception ex)
            {
                _sessionStoreService.LogError(ex, sessionId ?? "");
            }


            try
            {
                await _next(context);
            }
            finally
            {
                try
                {
                    context.Features.Set<ISessionFeature>(null);
                    if (session != null)
                    {
                        var shouldCommit = session.WasModified || !session.NewSession;

                        if (context.Items.ContainsKey(NCacheStatics.AbandonSessionFlag))
                            await session.AbandonAsync();
                        else if (shouldCommit)
                            await session.CommitAsync();
                    }
                }
                catch (Exception ex)
                {
                    _sessionStoreService.LogError(ex, sessionId ?? "");
                }
            }
        }

        internal Task ApplySessionKey(object state)
        {
            object[] parameters = (object[]) state;
            var context = (HttpContext) parameters[0];
            var sessionKey = (string) parameters[1];
            _sessionStoreService.ApplySessionKey(context, sessionKey);
            return Task.FromResult(0);
        }
    }
}

