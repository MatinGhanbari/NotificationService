using Grpc.Core;
using static NotificationGrpc.NotificationGrpcService;

namespace ConsumerApplication.GrpcServices;

public class NotificationService : NotificationBaseService
{
    private readonly List<IServerStreamWriter<NotificationResponse>> _notificationStreams = new();

    public override async Task GetNotifications(NotificationRequest request, IServerStreamWriter<NotificationResponse> responseStream, ServerCallContext context)
    {
        _notificationStreams.Add(responseStream);

        while (!context.CancellationToken.IsCancellationRequested)
            await Task.Delay(100);

        _notificationStreams.Remove(responseStream);
    }

    public virtual IReadOnlyList<IServerStreamWriter<NotificationResponse>> GetNotificationStreams()
    {
        return _notificationStreams.AsReadOnly();
    }
}