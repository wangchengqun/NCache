//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: RecordSetValue.proto
// Note: requires additional types generated from: AverageResult.proto
// Note: requires additional types generated from: Commands/Value.proto
namespace Alachisoft.NCache.Common.Protobuf
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RecordSetValue")]
  public partial class RecordSetValue : global::ProtoBuf.IExtensible
  {
    public RecordSetValue() {}
    

    private string _stringValue = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"stringValue", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string stringValue
    {
      get { return _stringValue; }
      set { _stringValue = value; }
    }

    private Alachisoft.NCache.Common.Protobuf.AverageResult _avgResult = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"avgResult", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Alachisoft.NCache.Common.Protobuf.AverageResult avgResult
    {
      get { return _avgResult; }
      set { _avgResult = value; }
    }

    private Alachisoft.NCache.Common.Protobuf.Value _binaryObject = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"binaryObject", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Alachisoft.NCache.Common.Protobuf.Value binaryObject
    {
      get { return _binaryObject; }
      set { _binaryObject = value; }
    }

    private int _flag = default(int);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"flag", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int flag
    {
      get { return _flag; }
      set { _flag = value; }
    }

    private int _type = default(int);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int type
    {
      get { return _type; }
      set { _type = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}