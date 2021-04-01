﻿//  Copyright (c) 2021 Alachisoft
//  
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  
//     http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License
using System;

namespace Alachisoft.NCache.Runtime.Caching
{
    /// <summary>
    /// Arguments containing deleted topic information
    /// </summary>
    internal class TopicDeleteEventArgs : EventArgs
    {
        private readonly string  _topicName;


        /// <summary>
        /// Creates TopicDeleteEventArgs instance
        /// </summary>
        /// <param name="topicName">Deleted topic name</param>
        public TopicDeleteEventArgs(string topicName )
        {
            _topicName = topicName;
        }

        /// <summary>
        /// Name of deleted topic
        /// </summary>
        public string TopicName
        {
            get { return _topicName; }
        }

    }
}
