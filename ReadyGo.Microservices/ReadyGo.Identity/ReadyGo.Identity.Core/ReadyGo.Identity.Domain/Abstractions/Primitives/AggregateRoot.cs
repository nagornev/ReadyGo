using ReadyGo.Identity.Domain.Abstractions.Events;

namespace ReadyGo.Identity.Domain.Abstractions.Primitives
{
    public abstract class AggregateRoot : Entity
    {
        private List<IDomainEvent> _domainEvents = new();

        public IReadOnlyCollection<IDomainEvent> GetDomainEvents()
        {
            return _domainEvents.AsReadOnly();
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void AddDomainEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }
    }
}
