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
using System.Text;
using Alachisoft.NCache.Common.Configuration;
using Alachisoft.NCache.Common.Enum;
using Alachisoft.NCache.Runtime.Serialization;
using Runtime = Alachisoft.NCache.Runtime;

namespace Alachisoft.NCache.Config.NewDom
{
    [Serializable]
    public class ServerNode : ICloneable,ICompactSerializable
    {
        string ip;
       

        public ServerNode()
        {

        }
        public ServerNode(string ip)
        {
            this.ip = ip;
        }

        [ConfigurationAttribute("ip")]
        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj is ServerNode)
            {
                ServerNode serverNode = obj as ServerNode;
                return serverNode.ip.ToLower().CompareTo(ip.ToLower()) == 0;
            }

            return false;
        }

        #region ICloneable Members

        public object Clone()
        {
            ServerNode node = new ServerNode();
            node.ip = ip;
            return node;
        }

        #endregion

        #region ICompactSerializable Members
        public void Deserialize(Runtime.Serialization.IO.CompactReader reader)
        {
            this.ip = reader.ReadString();
        }

        public void Serialize(Runtime.Serialization.IO.CompactWriter writer)
        {
            writer.Write(ip);
        }
        #endregion
    }

}
