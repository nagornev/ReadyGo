using Newtonsoft.Json;
using ReadyGo.Identity.Domain.Abstractions.Primitives;
using ReadyGo.Identity.Domain.Abstractions.Repositories;
using ReadyGo.Identity.Persistence.Contexts;
using ReadyGo.Identity.Persistence.Entities;

namespace ReadyGo.Identity.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(CancellationToken cancellation = default)
        {
            var outboxMessages = _context.ChangeTracker.Entries<AggregateRoot>()
                                                       .Select(x => x.Entity)
                                                       .SelectMany(aggregateRoot =>
                                                       {
                                                           var domainEvents = aggregateRoot.GetDomainEvents();

                                                           aggregateRoot.ClearDomainEvents();

                                                           return domainEvents;
                                                       })
                                                       .Select(domainEvent => 
                                                               OutboxMessage.Create(domainEvent.AggregateId, 
                                                                                    domainEvent.GetType().Name,
                                                                                    JsonConvert.SerializeObject(domainEvent, 
                                                                                                                new JsonSerializerSettings
                                                                                                                {
                                                                                                                    TypeNameHandling = TypeNameHandling.All
                                                                                                                }),
                                                                                    domainEvent.OccurredOn))
                                                       .ToArray();

            _context.Outbox.AddRange(outboxMessages);

            _ = await _context.SaveChangesAsync(cancellation);
        }
    }
}
