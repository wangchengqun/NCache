//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: ModuleCommand.proto
namespace Alachisoft.NCache.Common.Protobuf
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ModuleCommand")]
  public partial class ModuleCommand : global::ProtoBuf.IExtensible
  {
    public ModuleCommand() {}
    

    private string _module = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"module", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string module
    {
      get { return _module; }
      set { _module = value; }
    }
    private readonly global::System.Collections.Generic.List<byte[]> _payload = new global::System.Collections.Generic.List<byte[]>();
    [global::ProtoBuf.ProtoMember(2, Name=@"payload", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<byte[]> payload
    {
      get { return _payload; }
    }
  

    private long _requestId = default(long);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"requestId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long requestId
    {
      get { return _requestId; }
      set { _requestId = value; }
    }

    private long _commandId = default(long);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"commandId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long commandId
    {
      get { return _commandId; }
      set { _commandId = value; }
    }

    private string _version = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"version", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string version
    {
      get { return _version; }
      set { _version = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}