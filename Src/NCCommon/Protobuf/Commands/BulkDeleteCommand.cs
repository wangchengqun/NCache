//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: BulkDeleteCommand.proto
namespace Alachisoft.NCache.Common.Protobuf
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BulkDeleteCommand")]
  public partial class BulkDeleteCommand : global::ProtoBuf.IExtensible
  {
    public BulkDeleteCommand() {}
    
    private readonly global::System.Collections.Generic.List<string> _keys = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(1, Name=@"keys", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> keys
    {
      get { return _keys; }
    }
  

    private long _requestId = default(long);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"requestId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long requestId
    {
      get { return _requestId; }
      set { _requestId = value; }
    }

    private int _flag = default(int);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"flag", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int flag
    {
      get { return _flag; }
      set { _flag = value; }
    }

    private int _datasourceItemRemovedCallbackId = default(int);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"datasourceItemRemovedCallbackId", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int datasourceItemRemovedCallbackId
    {
      get { return _datasourceItemRemovedCallbackId; }
      set { _datasourceItemRemovedCallbackId = value; }
    }

    private string _providerName = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"providerName", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string providerName
    {
      get { return _providerName; }
      set { _providerName = value; }
    }

    private long _clientLastViewId = (long)-1;
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"clientLastViewId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((long)-1)]
    public long clientLastViewId
    {
      get { return _clientLastViewId; }
      set { _clientLastViewId = value; }
    }

    private int _MethodOverload = (int)0;
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"MethodOverload", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((int)0)]
    public int MethodOverload
    {
      get { return _MethodOverload; }
      set { _MethodOverload = value; }
    }

    private string _intendedRecipient = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"intendedRecipient", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string intendedRecipient
    {
      get { return _intendedRecipient; }
      set { _intendedRecipient = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}