//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: CacheClearedEventResponse.proto
// Note: requires additional types generated from: EventId.proto
namespace Alachisoft.NCache.Common.Protobuf
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CacheClearedEventResponse")]
  public partial class CacheClearedEventResponse : global::ProtoBuf.IExtensible
  {
    public CacheClearedEventResponse() {}
    

    private Alachisoft.NCache.Common.Protobuf.EventId _eventId = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"eventId", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Alachisoft.NCache.Common.Protobuf.EventId eventId
    {
      get { return _eventId; }
      set { _eventId = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
