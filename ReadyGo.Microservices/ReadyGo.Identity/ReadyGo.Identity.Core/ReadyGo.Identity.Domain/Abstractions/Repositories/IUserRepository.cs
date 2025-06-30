using ReadyGo.Identity.Domain.Aggregates;

namespace ReadyGo.Identity.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid userId, CancellationToken cancellation = default);

        Task AddAsync(User user, CancellationToken cancellation = default);

        Task DeleteAsync(Guid userId, CancellationToken cancellation = default);
    }
}
