using ConsumerApplication.GrpcServices;
using ConsumerApplication.Notification.Events;
using Core.Events.EventHandler;
using FluentResults;
using Google.Protobuf.WellKnownTypes;

namespace ConsumerApplication.Notification.Handler;

public class NotificationEventHandler(NotificationService notificationService) : IEventHandler<NotificationEvent>
{
    public async Task<Result> Handle(NotificationEvent @event)
    {
        var notificationResponse = new NotificationResponse()
        {
            Title = @event.Title,
            Description = @event.Description ?? string.Empty,
            TimeStamp = @event.DateTime == null ? ((DateTime)@event.DateTime!).ToTimestamp() : DateTime.UtcNow.ToTimestamp(),
        };

        var streams = notificationService.GetNotificationStreams();

        Parallel.ForEach(streams, async stream => await stream.WriteAsync(notificationResponse));

        return Result.Ok();
    }
}