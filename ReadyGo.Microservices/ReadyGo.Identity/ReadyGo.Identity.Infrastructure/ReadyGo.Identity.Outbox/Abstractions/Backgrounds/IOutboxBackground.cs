namespace ReadyGo.Identity.Outbox.Abstractions.Backgrounds
{
    public interface IOutboxBackground
    {
        Task HandleAsync(CancellationToken cancellation);
    }
}
