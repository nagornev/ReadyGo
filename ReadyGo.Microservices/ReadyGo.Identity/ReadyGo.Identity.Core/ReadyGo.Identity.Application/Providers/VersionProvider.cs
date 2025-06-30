using ReadyGo.Identity.Application.Abstractions.Providers;

namespace ReadyGo.Identity.Application.Providers
{
    public class VersionProvider : IVersionProvider
    {
        public Guid Create()
        {
            return Guid.NewGuid();
        }
    }
}
