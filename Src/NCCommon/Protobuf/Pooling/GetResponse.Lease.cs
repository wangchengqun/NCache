//  Copyright (c) 2021 Alachisoft
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

using Alachisoft.NCache.Common.Pooling.Lease;
using Alachisoft.NCache.Common.Pooling.Extension;

namespace Alachisoft.NCache.Common.Protobuf
{
    public partial class GetResponse : SimpleLease
    {
        #region ILeasable

        public override sealed void ResetLeasable()
        {
            data.Clear();
            flag = default(int);
            lockId = string.Empty;
            lockTime = default(long);
            version = default(ulong);
            commandID = default(int);
            requestId = default(long);
            itemType = CacheItemType.ItemType.CACHEITEM;
            extensionObject = default(ProtoBuf.IExtension);
        }

        public override sealed void ReturnLeasableToPool()
        {
            PoolManager.GetProtobufGetResponsePool()?.Return(this);
        }

        #endregion
    }
}