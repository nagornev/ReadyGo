using ReadyGo.Identity.Persistence.Entities;

namespace ReadyGo.Identity.Persistence.Abstractions.Repositories
{
    public interface IOutboxRepository
    {
        Task<OutboxMessage?> LockNextOutboxMessageAsync(long timestamp, CancellationToken cancellationToken = default);
    }
}
