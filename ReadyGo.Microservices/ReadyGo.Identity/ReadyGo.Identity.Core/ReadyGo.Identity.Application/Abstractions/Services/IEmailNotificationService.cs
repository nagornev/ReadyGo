namespace ReadyGo.Identity.Application.Abstractions.Services
{
    public interface IEmailNotificationService
    {
        Task SendAsync(string to, string from, string subject, string body);
    }
}
