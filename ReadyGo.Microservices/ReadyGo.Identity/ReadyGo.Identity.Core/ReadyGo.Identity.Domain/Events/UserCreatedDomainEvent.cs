using ReadyGo.Identity.Domain.Abstractions.Events;

namespace ReadyGo.Identity.Domain.Events
{
    public sealed class UserCreatedDomainEvent : DomainEvent
    {
        public UserCreatedDomainEvent(Guid aggregateId)
            : base(aggregateId)
        {
        }
    }
}
