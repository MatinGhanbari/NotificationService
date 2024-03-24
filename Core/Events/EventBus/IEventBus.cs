using Core.Events.EventHandler;

namespace Core.Events.EventBus;

public interface IEventBus
{
    void Publish<T>(T @event) where T : BaseEvent;

    void Subscribe<T, TH>() where T : BaseEvent where TH : IEventHandler<T>;
}