using ReadyGo.Identity.Domain.Aggregates;

namespace ReadyGo.Identity.Domain.Abstractions.Repositories
{
    public interface IScopeRepository
    {
        Task<IReadOnlyCollection<Scope>> GetAsync(CancellationToken cancellation = default);

        Task<Scope> GetAsync(int scopeId, CancellationToken cancellation = default);
    }
}
