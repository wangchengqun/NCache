//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: InternalPayload.proto
// Note: requires additional types generated from: EventMessage.proto
// Note: requires additional types generated from: CollectionEventMessage.proto
namespace Alachisoft.NCache.Common.Protobuf
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"InternalPayload")]
  public partial class InternalPayload : global::ProtoBuf.IExtensible
  {
    public InternalPayload() {}
    

    private Alachisoft.NCache.Common.Protobuf.EventMessage _eventMessage = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"eventMessage", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Alachisoft.NCache.Common.Protobuf.EventMessage eventMessage
    {
      get { return _eventMessage; }
      set { _eventMessage = value; }
    }

    private Alachisoft.NCache.Common.Protobuf.InternalPayload.PayloadType _payloadType = Alachisoft.NCache.Common.Protobuf.InternalPayload.PayloadType.CACHE_ITEM_EVENTS;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"payloadType", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(Alachisoft.NCache.Common.Protobuf.InternalPayload.PayloadType.CACHE_ITEM_EVENTS)]
    public Alachisoft.NCache.Common.Protobuf.InternalPayload.PayloadType payloadType
    {
      get { return _payloadType; }
      set { _payloadType = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"PayloadType")]
    public enum PayloadType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"CACHE_ITEM_EVENTS", Value=1)]
      CACHE_ITEM_EVENTS = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"COLLECTION_EVENTS", Value=2)]
      COLLECTION_EVENTS = 2
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}