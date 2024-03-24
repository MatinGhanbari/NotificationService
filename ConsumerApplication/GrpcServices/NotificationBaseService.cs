using ConsumerApplication.GrpcServices;
using grpc = Grpc.Core;

namespace NotificationGrpc;

public static partial class NotificationGrpcService
{
    private const string ServiceName = "NotificationGrpc.NotificationGrpcService";

    [System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    private static void __Helper_SerializeMessage(Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
#if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
        if (message is Google.Protobuf.IBufferMessage)
        {
            context.SetPayloadLength(message.CalculateSize());
            Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
            context.Complete();
            return;
        }
#endif
        context.Complete(Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    private static class HelperMessageCache<T>
    {
        public static readonly bool IsBufferMessage = System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    private static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, Google.Protobuf.MessageParser<T> parser) where T : Google.Protobuf.IMessage<T>
    {
#if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
        if (HelperMessageCache<T>.IsBufferMessage)
            return parser.ParseFrom(context.PayloadAsReadOnlySequence());
#endif
        return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    private static readonly grpc::Marshaller<NotificationRequest> MarshallerNotificationGrpcNotificationRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, NotificationRequest.Parser));
    [System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    private static readonly grpc::Marshaller<NotificationResponse> MarshallerNotificationGrpcNotificationResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, NotificationResponse.Parser));

    [System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    private static readonly grpc::Method<NotificationRequest, NotificationResponse> MethodGetNotifications = new grpc::Method<NotificationRequest, NotificationResponse>(
        grpc::MethodType.ServerStreaming,
        ServiceName,
        "GetNotifications",
        MarshallerNotificationGrpcNotificationRequest,
        MarshallerNotificationGrpcNotificationResponse);

    /// <summary>Service descriptor</summary>
    public static Google.Protobuf.Reflection.ServiceDescriptor Descriptor => NotificationReflection.Descriptor.Services[0];

    /// <summary>Base class for server-side implementations of NotificationService</summary>
    [grpc::BindServiceMethod(typeof(NotificationBaseService), "BindService")]
    public abstract partial class NotificationBaseService
    {
        [System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public virtual Task GetNotifications(NotificationRequest request, grpc::IServerStreamWriter<NotificationResponse> responseStream, grpc::ServerCallContext context)
        {
            throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
        }
    }

    /// <summary>Client for NotificationService</summary>
    public partial class NotificationServiceClient : grpc::ClientBase<NotificationServiceClient>
    {
        /// <summary>Creates a new client for NotificationService</summary>
        /// <param name="channel">The channel to use to make remote calls.</param>
        [System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public NotificationServiceClient(grpc::ChannelBase channel) : base(channel)
        {
        }
        /// <summary>Creates a new client for NotificationService that uses a custom <c>CallInvoker</c>.</summary>
        /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
        [System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public NotificationServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
        {
        }
        /// <summary>Protected parameter less constructor to allow creation of test doubles.</summary>
        [System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        protected NotificationServiceClient() : base()
        {
        }
        /// <summary>Protected constructor to allow creation of configured clients.</summary>
        /// <param name="configuration">The client configuration.</param>
        [System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        protected NotificationServiceClient(ClientBaseConfiguration configuration) : base(configuration)
        {
        }

        [System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public virtual grpc::AsyncServerStreamingCall<NotificationResponse> GetNotifications(NotificationRequest request, grpc::Metadata headers = null, System.DateTime? deadline = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return GetNotifications(request, new grpc::CallOptions(headers, deadline, cancellationToken));
        }
        [System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public virtual grpc::AsyncServerStreamingCall<NotificationResponse> GetNotifications(NotificationRequest request, grpc::CallOptions options)
        {
            return CallInvoker.AsyncServerStreamingCall(MethodGetNotifications, null, options, request);
        }
        /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
        [System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        protected override NotificationServiceClient NewInstance(ClientBaseConfiguration configuration)
        {
            return new NotificationServiceClient(configuration);
        }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(NotificationBaseService serviceImpl)
    {
        return grpc::ServerServiceDefinition.CreateBuilder()
            .AddMethod(MethodGetNotifications, serviceImpl.GetNotifications).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, NotificationBaseService serviceImpl)
    {
        serviceBinder.AddMethod(MethodGetNotifications, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<NotificationRequest, NotificationResponse>(serviceImpl.GetNotifications));
    }

}


