//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: TopicMessages.proto
// Note: requires additional types generated from: Message.proto
namespace Alachisoft.NCache.Common.Protobuf
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"TopicMessages")]
  public partial class TopicMessages : global::ProtoBuf.IExtensible
  {
    public TopicMessages() {}
    

    private string _topic = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"topic", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string topic
    {
      get { return _topic; }
      set { _topic = value; }
    }
    private readonly global::System.Collections.Generic.List<Alachisoft.NCache.Common.Protobuf.Message> _messageList = new global::System.Collections.Generic.List<Alachisoft.NCache.Common.Protobuf.Message>();
    [global::ProtoBuf.ProtoMember(2, Name=@"messageList", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Alachisoft.NCache.Common.Protobuf.Message> messageList
    {
      get { return _messageList; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}