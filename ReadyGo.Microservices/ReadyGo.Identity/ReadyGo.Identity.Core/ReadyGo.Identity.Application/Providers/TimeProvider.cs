using ReadyGo.Identity.Application.Abstractions.Providers;

namespace ReadyGo.Identity.Application.Providers
{
    public class TimeProvider : ITimeProvider
    {
        public long NowUnix()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        public DateTime NowDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}
