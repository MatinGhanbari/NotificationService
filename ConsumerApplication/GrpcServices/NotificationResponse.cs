using pb = Google.Protobuf;
using pbr = Google.Protobuf.Reflection;

namespace ConsumerApplication.GrpcServices;

public sealed partial class NotificationResponse : pb::IMessage<NotificationResponse>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
#endif
{
    private pb::UnknownFieldSet _unknownFields;

    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<NotificationResponse> Parser { get; } = new(() => new NotificationResponse());

    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor => NotificationReflection.Descriptor.MessageTypes[1];

    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor => Descriptor;

    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NotificationResponse()
    {
        OnConstruction();
    }

    partial void OnConstruction();

    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NotificationResponse(NotificationResponse other) : this()
    {
        _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NotificationResponse Clone()
    {
        return new NotificationResponse(this);
    }

    /// <summary>Field number for the "title" field.</summary>
    public const int TitleFieldNumber = 1;
    private string title_ = "";
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Title
    {
        get => title_;
        set => title_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }

    /// <summary>Field number for the "description" field.</summary>
    public const int DescriptionFieldNumber = 1;
    private string description_ = "";
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Description
    {
        get => description_;
        set => description_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }

    /// <summary>Field number for the "timeStamp" field.</summary>
    public const int TimeStampFieldNumber = 4;
    private global::Google.Protobuf.WellKnownTypes.Timestamp timeStamp_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Google.Protobuf.WellKnownTypes.Timestamp TimeStamp
    {
        get => timeStamp_;
        set => timeStamp_ = value;
    }

    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other)
    {
        return Equals(other as NotificationResponse);
    }

    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(NotificationResponse other)
    {
        if (ReferenceEquals(other, null))
        {
            return false;
        }
        if (ReferenceEquals(other, this))
        {
            return true;
        }
        if (Title != other.Title) return false;
        if (Description != other.Description) return false;
        if (TimeStamp != other.TimeStamp) return false;
        return Equals(_unknownFields, other._unknownFields);
    }

    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode()
    {
        int hash = 1;
        if (Title.Length != 0) hash ^= Title.GetHashCode();
        if (Description.Length != 0) hash ^= Description.GetHashCode();
        if (timeStamp_ != null) hash ^= TimeStamp.GetHashCode();
        if (_unknownFields != null)
        {
            hash ^= _unknownFields.GetHashCode();
        }
        return hash;
    }

    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString()
    {
        return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output)
    {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        output.WriteRawMessage(this);
#else
          if (Title.Length != 0) {
            output.WriteRawTag(10);
            output.WriteString(Title);
          }
          if (Description.Length != 0) {
            output.WriteRawTag(18);
            output.WriteString(Description);
          }
          if (timeStamp_ != null) {
            output.WriteRawTag(34);
            output.WriteMessage(TimeStamp);
          }
          if (_unknownFields != null) {
            _unknownFields.WriteTo(output);
          }
#endif
    }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output)
    {
        if (Title.Length != 0)
        {
            output.WriteRawTag(10);
            output.WriteString(Title);
        }
        if (Description.Length != 0)
        {
            output.WriteRawTag(18);
            output.WriteString(Description);
        }
        if (timeStamp_ != null)
        {
            output.WriteRawTag(34);
            output.WriteMessage(TimeStamp);
        }
        if (_unknownFields != null)
        {
            _unknownFields.WriteTo(ref output);
        }
    }
#endif

    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize()
    {
        int size = 0;
        if (Title.Length != 0)
        {
            size += 1 + pb::CodedOutputStream.ComputeStringSize(Title);
        }
        if (Description.Length != 0)
        {
            size += 1 + pb::CodedOutputStream.ComputeStringSize(Description);
        }
        if (timeStamp_ != null)
        {
            size += 1 + pb::CodedOutputStream.ComputeMessageSize(TimeStamp);
        }
        if (_unknownFields != null)
        {
            size += _unknownFields.CalculateSize();
        }
        return size;
    }

    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(NotificationResponse other)
    {
        if (other == null)
        {
            return;
        }
        if (other.Title.Length != 0)
        {
            Title = other.Title;
        }
        if (other.Description.Length != 0)
        {
            Description = other.Description;
        }
        if (other.timeStamp_ != null)
        {
            if (timeStamp_ == null)
            {
                TimeStamp = new Google.Protobuf.WellKnownTypes.Timestamp();
            }
            TimeStamp.MergeFrom(other.TimeStamp);
        }
        _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input)
    {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        input.ReadRawMessage(this);
#else
          uint tag;
          while ((tag = input.ReadTag()) != 0) {
            switch(tag) {
              default:
                _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                break;
              case 10: {
                Title = input.ReadString();
                break;
              }
              case 18: {
                Description = input.ReadString();
                break;
              }
              case 34: {
                if (timeStamp_ == null) {
                  TimeStamp = new Google.Protobuf.WellKnownTypes.Timestamp();
                }
                input.ReadMessage(TimeStamp);
                break;
              }
            }
          }
#endif
    }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input)
    {
        uint tag;
        while ((tag = input.ReadTag()) != 0)
        {
            switch (tag)
            {
                default:
                    _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
                    break;
                case 10:
                    {
                        Title = input.ReadString();
                        break;
                    }
                case 18:
                    {
                        Description = input.ReadString();
                        break;
                    }
                case 34:
                    {
                        if (timeStamp_ == null)
                        {
                            TimeStamp = new Google.Protobuf.WellKnownTypes.Timestamp();
                        }
                        input.ReadMessage(TimeStamp);
                        break;
                    }
            }
        }
    }
#endif
}

public static class NotificationReflection
{

    #region Descriptor
    /// <summary>File descriptor for monitoring.proto</summary>
    public static pbr::FileDescriptor Descriptor { get; }

    static NotificationReflection()
    {
        var descriptorData = Convert.FromBase64String(
            string.Concat(
              "ChBtb25pdG9yaW5nLnByb3RvEhBOb3RpZmljYXRpb25HcnBjGh9nb29nbGUv",
              "cHJvdG9idWYvdGltZXN0YW1wLnByb3RvIhIKEEFjY2Vzc0xvZ1JlcXVlc3Qi",
              "wAIKEUFjY2Vzc0xvZ1Jlc3BvbnNlEgwKBG5hbWUYASABKAkSFgoOZGVwYXJ0",
              "bWVudE5hbWUYAiABKAkSNAoMYWNjZXNzc3RhdHVzGAMgASgOMh4uTm90aWZp",
              "Y2F0aW9uR3JwYy5BY2Nlc3NTdGF0dXMSLQoJdGltZVN0YW1wGAQgASgLMhou",
              "Z29vZ2xlLnByb3RvYnVmLlRpbWVzdGFtcBIQCghkZXZpY2VJZBgFIAEoDRIS",
              "CgpkZXZpY2VOYW1lGAYgASgJEjYKDWRldGVjdGlvblR5cGUYByABKA4yHy5O",
              "b3RpZmljYXRpb25HcnBjLkRldGVjdGlvblR5cGUSDgoGdXNlcklkGAggASgD",
              "EhQKDHByb2ZpbGVJbWFnZRgKIAEoCRIKCgJpZBgLIAEoDRIQCghsb2dJbWFn",
              "ZRgMIAEoCSIWChRSZWFsVGltZUV2ZW50UmVxdWVzdCKRAgoVUmVhbFRpbWVF",
              "dmVudFJlc3BvbnNlEgwKBG5hbWUYASABKAkSFwoPYWNjZXNzR3JvdXBOYW1l",
              "GAIgASgJEjQKDGFjY2Vzc3N0YXR1cxgDIAEoDjIeLk5vdGlmaWNhdGlvbkdy",
              "cGMuQWNjZXNzU3RhdHVzEi0KCXRpbWVTdGFtcBgEIAEoCzIaLmdvb2dsZS5w",
              "cm90b2J1Zi5UaW1lc3RhbXASEAoIZGV2aWNlSWQYBSABKA0SEgoKZGV2aWNl",
              "TmFtZRgGIAEoCRI2Cg1kZXRlY3Rpb25UeXBlGAcgASgOMh8uTm90aWZpY2F0",
              "aW9uR3JwYy5EZXRlY3Rpb25UeXBlEg4KBnVzZXJJZBgIIAEoAyo9CgxBY2Nl",
              "c3NTdGF0dXMSDgoKQXV0aG9yaXplZBAAEhAKDFVuQXV0aG9yaXplZBABEgsK",
              "B1VuS25vd24QAio6Cg1EZXRlY3Rpb25UeXBlEggKBEZhY2UQABIKCgZGaW5n",
              "ZXIQARIICgRDYXJkEAISCQoFT3RoZXIQAzLXAQoRTW9uaXRvcmluZ1NlcnZp",
              "Y2USWgoNR2V0QWNjZXNzTG9ncxIiLk5vdGlmaWNhdGlvbkdycGMuQWNjZXNz",
              "TG9nUmVxdWVzdBojLk5vdGlmaWNhdGlvbkdycGMuQWNjZXNzTG9nUmVzcG9u",
              "c2UwARJmChFHZXRSZWFsVGltZUV2ZW50cxImLk5vdGlmaWNhdGlvbkdycGMu",
              "UmVhbFRpbWVFdmVudFJlcXVlc3QaJy5Ob3RpZmljYXRpb25HcnBjLlJlYWxU",
              "aW1lRXZlbnRSZXNwb25zZTABYgZwcm90bzM="));
        Descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
            new pbr::FileDescriptor[] { Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, }, null);
    }
    #endregion

}

public sealed partial class NotificationRequest : pb::IMessage<NotificationRequest>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
     , pb::IBufferMessage
#endif
{
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<NotificationRequest> Parser { get; } = new(() => new NotificationRequest());

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor => NotificationReflection.Descriptor.MessageTypes[0];

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor => Descriptor;

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NotificationRequest()
    {
        OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NotificationRequest(NotificationRequest other) : this()
    {
        _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NotificationRequest Clone()
    {
        return new NotificationRequest(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other)
    {
        return Equals(other as NotificationRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(NotificationRequest other)
    {
        if (ReferenceEquals(other, null))
        {
            return false;
        }
        if (ReferenceEquals(other, this))
        {
            return true;
        }
        return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode()
    {
        int hash = 1;
        if (_unknownFields != null)
        {
            hash ^= _unknownFields.GetHashCode();
        }
        return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString()
    {
        return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output)
    {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        output.WriteRawMessage(this);
#else
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
#endif
    }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output)
    {
        if (_unknownFields != null)
        {
            _unknownFields.WriteTo(ref output);
        }
    }
#endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize()
    {
        int size = 0;
        if (_unknownFields != null)
        {
            size += _unknownFields.CalculateSize();
        }
        return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(NotificationRequest other)
    {
        if (other == null)
        {
            return;
        }
        _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input)
    {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        input.ReadRawMessage(this);
#else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
        }
      }
#endif
    }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input)
    {
        uint tag;
        while ((tag = input.ReadTag()) != 0)
        {
            switch (tag)
            {
                default:
                    _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
                    break;
            }
        }
    }
#endif

}