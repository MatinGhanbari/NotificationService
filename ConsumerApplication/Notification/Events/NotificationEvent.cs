using Core.Events.EventBus;

namespace ConsumerApplication.Notification.Events;

[Serializable]
public class NotificationEvent : BaseEvent
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime? DateTime { get; set; }
}