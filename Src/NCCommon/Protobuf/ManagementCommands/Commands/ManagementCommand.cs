//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: ManagementCommand.proto
namespace Alachisoft.NCache.Common.Protobuf
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ManagementCommand")]
  public partial class ManagementCommand : global::ProtoBuf.IExtensible
  {
    public ManagementCommand() {}
    

    private long _requestId = default(long);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"requestId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long requestId
    {
      get { return _requestId; }
      set { _requestId = value; }
    }

    private int _commandVersion = (int)0;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"commandVersion", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((int)0)]
    public int commandVersion
    {
      get { return _commandVersion; }
      set { _commandVersion = value; }
    }

    private string _methodName = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"methodName", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string methodName
    {
      get { return _methodName; }
      set { _methodName = value; }
    }

    private int _overload = default(int);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"overload", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int overload
    {
      get { return _overload; }
      set { _overload = value; }
    }

    private byte[] _arguments = null;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"arguments", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public byte[] arguments
    {
      get { return _arguments; }
      set { _arguments = value; }
    }

    private string _objectName = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"objectName", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string objectName
    {
      get { return _objectName; }
      set { _objectName = value; }
    }

    private Alachisoft.NCache.Common.Protobuf.ManagementCommand.SourceType _source = Alachisoft.NCache.Common.Protobuf.ManagementCommand.SourceType.TOOL;
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"source", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(Alachisoft.NCache.Common.Protobuf.ManagementCommand.SourceType.TOOL)]
    public Alachisoft.NCache.Common.Protobuf.ManagementCommand.SourceType source
    {
      get { return _source; }
      set { _source = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"SourceType")]
    public enum SourceType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"TOOL", Value=1)]
      TOOL = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MANAGER", Value=2)]
      MANAGER = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MONITOR", Value=3)]
      MONITOR = 3
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
