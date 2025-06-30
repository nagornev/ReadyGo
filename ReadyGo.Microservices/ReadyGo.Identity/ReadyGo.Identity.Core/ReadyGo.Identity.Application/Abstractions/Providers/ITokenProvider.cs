using ReadyGo.Identity.Domain.Aggregates;

namespace ReadyGo.Identity.Application.Abstractions.Providers
{
    public interface ITokenProvider
    {
        /// <summary>
        /// Creates token for <paramref name="user"/>.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string Create(User user);

        /// <summary>
        /// Validates <paramref name="token"/> and returns subject if token is valided.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        bool Validate(string token, out Guid? subject);
    }
}
