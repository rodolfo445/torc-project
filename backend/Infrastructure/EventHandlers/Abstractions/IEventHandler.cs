namespace backend.Infrastructure.EventHandlers;

public interface IEventHandler<TEvent>
{
    Task Handle(TEvent @event);
}