using ReadyGo.Identity.Domain.Abstractions.Primitives;

namespace ReadyGo.Identity.Domain.Entities
{
    public partial class ScopePermission : Entity
    {
        private ScopePermission(Guid id,
                                Guid authorizationId,
                                Guid scopeId,
                                long createdAt,
                                long? expiresAt,
                                bool isActive)
        {
            Id = id;
            AuthorizationId = authorizationId;
            ScopeId = scopeId;
            CreatedAt = createdAt;
            ExpiresAt = expiresAt;
            IsActive = isActive;
        }

        internal static ScopePermission Create(Guid id,
                                               Guid authorizationId,
                                               Guid scopeId,
                                               long createdAt,
                                               long? expiresAt = null,
                                               bool isActive = true)
        {
            return new ScopePermission(id,
                                       authorizationId,
                                       scopeId,
                                       createdAt,
                                       expiresAt,
                                       isActive);
        }

        public Guid AuthorizationId { get; }

        public Guid ScopeId { get; }

        public long CreatedAt { get; }

        public long? ExpiresAt { get; private set; }

        public bool IsActive { get; private set; }

        public bool IsValidAt(long timestamp)
        {
            return IsActive && ExpiresAt.HasValue ?
                        ExpiresAt > timestamp :
                        IsActive || !ExpiresAt.HasValue;
        }

        internal void Activate()
        {
            IsActive = true;
        }

        internal void Deactivate()
        {
            IsActive = false;
        }
    }

    #region Ef
    public partial class ScopePermission
    {
        private ScopePermission()
        {
        }
    }
    #endregion
}
