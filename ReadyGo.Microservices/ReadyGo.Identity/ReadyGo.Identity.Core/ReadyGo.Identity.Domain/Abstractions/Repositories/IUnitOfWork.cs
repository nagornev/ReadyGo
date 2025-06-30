namespace ReadyGo.Identity.Domain.Abstractions.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveAsync(CancellationToken cancellation = default);
    }
}
