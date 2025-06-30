using ReadyGo.Identity.Domain.Aggregates;

namespace ReadyGo.Identity.Domain.Abstractions.Repositories
{
    public interface ISessionRepository
    {
        Task<IReadOnlyCollection<Session>> GetAsync(Guid userId, CancellationToken cancellation = default);

        Task<Session> GetAsync(Guid userId, Guid sessionId, CancellationToken cancellation = default);

        Task AddAsync(Session session, CancellationToken cancellation = default);

        Task DeleteAsync(Guid userId, Guid sessionId, CancellationToken cancellation = default);
    }
}
