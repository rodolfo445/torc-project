namespace backend.Infrastructure.EventHandlers;

public interface IEventBus
{
    void Publish<TEvent>(TEvent @event);
    void Subscribe<TEvent, TEventHandler>(TEventHandler t) where TEventHandler : IEventHandler<TEvent>;
    void Unsubscribe<TEvent, TEventHandler>() where TEventHandler : IEventHandler<TEvent>;

}