using Core.Events.EventBus;
using FluentResults;

namespace Core.Events.EventHandler;

public interface IEventHandler { }

public interface IEventHandler<in TEvent> : IEventHandler where TEvent : BaseEvent
{
    Task<Result> Handle(TEvent @event);
}