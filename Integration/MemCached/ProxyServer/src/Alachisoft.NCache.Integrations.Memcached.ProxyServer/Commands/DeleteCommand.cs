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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alachisoft.NCache.Integrations.Memcached.Provider;
using Alachisoft.NCache.Integrations.Memcached.ProxyServer.Common;

namespace Alachisoft.NCache.Integrations.Memcached.ProxyServer.Commands
{
    class DeleteCommand : AbstractCommand
    {
        private string _key;

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public DeleteCommand(Opcode opcode) : base(opcode)
        { 
        }

        public override void Execute(IMemcachedProvider cacheProvider)
        {
            _result = cacheProvider.Delete(_key,0);
        }
    }
}
