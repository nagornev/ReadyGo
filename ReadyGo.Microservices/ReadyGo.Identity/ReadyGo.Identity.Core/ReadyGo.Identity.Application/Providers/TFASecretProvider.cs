using Microsoft.Extensions.Options;
using ReadyGo.Identity.Application.Abstractions.Providers;
using ReadyGo.Identity.Application.Options;

namespace ReadyGo.Identity.Application.Providers
{
    public class TFASecretProvider : ITFASecretProvider
    {
        private readonly TFASecretOptions _options;

        public TFASecretProvider(IOptions<TFASecretOptions> options)
        {
            _options = options.Value;
        }

        public string Create()
        {
            return Guid.NewGuid()
                       .ToString("N");
        }
    }
}
