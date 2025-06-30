namespace ReadyGo.Identity.Domain.Abstractions.Events
{
    public interface IDomainEvent
    {
        Guid AggregateId { get; }

        long OccurredOn { get; }
    }
}
