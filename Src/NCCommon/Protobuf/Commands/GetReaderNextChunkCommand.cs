//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: GetReaderNextChunkCommand.proto
namespace Alachisoft.NCache.Common.Protobuf
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GetReaderNextChunkCommand")]
  public partial class GetReaderNextChunkCommand : global::ProtoBuf.IExtensible
  {
    public GetReaderNextChunkCommand() {}
    

    private string _readerId = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"readerId", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string readerId
    {
      get { return _readerId; }
      set { _readerId = value; }
    }

    private int _nextIndex = default(int);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"nextIndex", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int nextIndex
    {
      get { return _nextIndex; }
      set { _nextIndex = value; }
    }

    private long _requestId = default(long);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"requestId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long requestId
    {
      get { return _requestId; }
      set { _requestId = value; }
    }

    private string _nodeIP = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"nodeIP", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string nodeIP
    {
      get { return _nodeIP; }
      set { _nodeIP = value; }
    }

    private int _commandVersion = (int)0;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"commandVersion", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((int)0)]
    public int commandVersion
    {
      get { return _commandVersion; }
      set { _commandVersion = value; }
    }

    private int _commandID = (int)-1;
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"commandID", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((int)-1)]
    public int commandID
    {
      get { return _commandID; }
      set { _commandID = value; }
    }

    private long _clientLastViewId = (long)-1;
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"clientLastViewId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((long)-1)]
    public long clientLastViewId
    {
      get { return _clientLastViewId; }
      set { _clientLastViewId = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}