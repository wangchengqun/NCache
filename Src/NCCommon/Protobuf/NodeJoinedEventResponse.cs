//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: NodeJoinedEventResponse.proto
// Note: requires additional types generated from: EventId.proto
namespace Alachisoft.NCache.Common.Protobuf
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NodeJoinedEventResponse")]
  public partial class NodeJoinedEventResponse : global::ProtoBuf.IExtensible
  {
    public NodeJoinedEventResponse() {}
    

    private string _clusterIp = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"clusterIp", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string clusterIp
    {
      get { return _clusterIp; }
      set { _clusterIp = value; }
    }

    private string _clusterPort = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"clusterPort", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string clusterPort
    {
      get { return _clusterPort; }
      set { _clusterPort = value; }
    }

    private string _serverIp = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"serverIp", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string serverIp
    {
      get { return _serverIp; }
      set { _serverIp = value; }
    }

    private string _serverPort = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"serverPort", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string serverPort
    {
      get { return _serverPort; }
      set { _serverPort = value; }
    }

    private bool _reconnect = default(bool);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"reconnect", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool reconnect
    {
      get { return _reconnect; }
      set { _reconnect = value; }
    }

    private Alachisoft.NCache.Common.Protobuf.EventId _eventId = null;
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"eventId", DataFormat = global::ProtoBuf.DataFormat.Default)]
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
