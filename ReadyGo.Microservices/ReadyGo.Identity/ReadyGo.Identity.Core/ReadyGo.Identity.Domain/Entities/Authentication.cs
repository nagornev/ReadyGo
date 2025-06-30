using ReadyGo.Identity.Domain.Abstractions.Primitives;
using ReadyGo.Identity.Domain.ValueObjects;
using TokenVersion = ReadyGo.Identity.Domain.ValueObjects.TokenVersion;

namespace ReadyGo.Identity.Domain.Entities
{
    public partial class Authentication : Entity
    {
        private Authentication(Guid id,
                               PasswordHash passwordHash,
                               TFASecret tfaSecret,
                               TokenVersion tokenVersion)
        {
            Id = id;
            PasswordHash = passwordHash;
            TFASecret = tfaSecret;
            TokenVersion = tokenVersion;
        }

        internal static Authentication Create(Guid id,
                                              PasswordHash passwordHash,
                                              TFASecret tfaSecret,
                                              TokenVersion tokenVersion)
        {
            return new Authentication(id,
                                      passwordHash,
                                      tfaSecret,
                                      tokenVersion);
        }

        public PasswordHash PasswordHash { get; private set; }

        public TFASecret TFASecret { get; private set; }

        public TokenVersion TokenVersion { get; private set; }

        internal void ChangePassword(PasswordHash passwordHash)
        {
            PasswordHash = passwordHash;
        }

        internal void ChangeTokenVersion(TokenVersion tokenVersion)
        {
            TokenVersion = tokenVersion;
        }
    }

    #region Ef
    public partial class Authentication
    {
        private Authentication()
        {
        }
    }
    #endregion
}
