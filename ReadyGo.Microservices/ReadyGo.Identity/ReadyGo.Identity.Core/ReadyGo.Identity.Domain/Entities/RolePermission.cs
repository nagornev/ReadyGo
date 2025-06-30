using ReadyGo.Identity.Domain.Abstractions.Primitives;

namespace ReadyGo.Identity.Domain.Entities
{
    public partial class RolePermission : Entity
    {
        private RolePermission(Guid id,
                               Guid authorizationId,
                               Guid roleId,
                               long createdAt,
                               bool isActive)
        {
            Id = id;
            AuthorizationId = authorizationId;
            RoleId = roleId;
            CreatedAt = createdAt;
            IsActive = isActive;
        }

        internal static RolePermission Create(Guid id,
                                              Guid authorizationId,
                                              Guid roleId,
                                              long createdAt,
                                              bool isActive = true)
        {
            return new RolePermission(id,
                                      authorizationId,
                                      roleId,
                                      createdAt,
                                      isActive);
        }

        public Guid AuthorizationId { get; private set; }

        public Guid RoleId { get; private set; }

        public long CreatedAt { get; private set; }

        public bool IsActive { get; private set; }

        public bool IsValid()
        {
            return IsActive;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }

    #region Ef

    public partial class RolePermission
    {
        private RolePermission()
        {
        }
    }

    #endregion
}
