namespace backend.Infrastructure.EventHandlers;

public class InMemoryEventBus : IEventBus
{
    private readonly Dictionary<Type, List<object>> _handlers = new();

    public void Publish<TEvent>(TEvent @event)
    {
        var eventType = typeof(TEvent);
        if (_handlers.ContainsKey(eventType))
        {
            foreach (var handler in _handlers[eventType])
            {
                ((IEventHandler<TEvent>)handler).Handle(@event);
            }
        }
    }

    public void Subscribe<TEvent, TEventHandler>(TEventHandler t) where TEventHandler : IEventHandler<TEvent>
    {
        var eventType = typeof(TEvent);
        if (!_handlers.ContainsKey(eventType))
        {
            _handlers[eventType] = new List<object>();
        }
        _handlers[eventType].Add(t);
    }

    public void Unsubscribe<TEvent, TEventHandler>() where TEventHandler : IEventHandler<TEvent>
    {
        var eventType = typeof(TEvent);
        if (_handlers.ContainsKey(eventType))
        {
            _handlers[eventType].RemoveAll(h => h.GetType() == typeof(TEventHandler));
        }
    }
}