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
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: BulkEventItemResponse.proto
// Note: requires additional types generated from: ItemRemoveCallbackResponse.proto
// Note: requires additional types generated from: ItemUpdatedCallbackResponse.proto
// Note: requires additional types generated from: CacheStoppedEventResponse.proto
namespace Alachisoft.NCache.Common.Protobuf
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BulkEventItemResponse")]
  public partial class BulkEventItemResponse : global::ProtoBuf.IExtensible
  {
    public BulkEventItemResponse() {}
    

    private Alachisoft.NCache.Common.Protobuf.BulkEventItemResponse.EventType _eventType = Alachisoft.NCache.Common.Protobuf.BulkEventItemResponse.EventType.ITEM_REMOVED_CALLBACK;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"eventType", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(Alachisoft.NCache.Common.Protobuf.BulkEventItemResponse.EventType.ITEM_REMOVED_CALLBACK)]
    public Alachisoft.NCache.Common.Protobuf.BulkEventItemResponse.EventType eventType
    {
      get { return _eventType; }
      set { _eventType = value; }
    }

    private Alachisoft.NCache.Common.Protobuf.ItemRemoveCallbackResponse _itemRemoveCallback = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"itemRemoveCallback", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Alachisoft.NCache.Common.Protobuf.ItemRemoveCallbackResponse itemRemoveCallback
    {
      get { return _itemRemoveCallback; }
      set { _itemRemoveCallback = value; }
    }

    private Alachisoft.NCache.Common.Protobuf.ItemUpdatedCallbackResponse _ItemUpdatedCallback = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"ItemUpdatedCallback", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Alachisoft.NCache.Common.Protobuf.ItemUpdatedCallbackResponse ItemUpdatedCallback
    {
      get { return _ItemUpdatedCallback; }
      set { _ItemUpdatedCallback = value; }
    }

    private Alachisoft.NCache.Common.Protobuf.CacheStoppedEventResponse _cacheStoppedEvent = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"cacheStoppedEvent", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Alachisoft.NCache.Common.Protobuf.CacheStoppedEventResponse cacheStoppedEvent
    {
      get { return _cacheStoppedEvent; }
      set { _cacheStoppedEvent = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"EventType")]
    public enum EventType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_REMOVED_CALLBACK", Value=1)]
      ITEM_REMOVED_CALLBACK = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_UPDATED_CALLBACK", Value=2)]
      ITEM_UPDATED_CALLBACK = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CACHE_STOPPED_EVENT", Value=3)]
      CACHE_STOPPED_EVENT = 3
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
