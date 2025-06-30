namespace ReadyGo.Identity.Domain.Abstractions.Events
{
    public interface IDomainEventHandler<in TDomainEventType>
        where TDomainEventType : IDomainEvent
    {
        Task HandleAsync(TDomainEventType @event);
    }
}
