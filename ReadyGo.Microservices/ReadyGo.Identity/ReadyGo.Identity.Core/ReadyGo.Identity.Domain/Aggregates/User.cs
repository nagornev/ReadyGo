using ReadyGo.Identity.Domain.Abstractions.Primitives;
using ReadyGo.Identity.Domain.Entities;
using ReadyGo.Identity.Domain.Events;
using ReadyGo.Identity.Domain.Failures.Exceptions.Users;
using ReadyGo.Identity.Domain.ValueObjects;
using TokenVersion = ReadyGo.Identity.Domain.ValueObjects.TokenVersion;

namespace ReadyGo.Identity.Domain.Aggregates
{
    public partial class User : AggregateRoot
    {
        private User(Guid id,
                     Authentication authentication,
                     Authorization authorization,
                     Profile profile,
                     long createdAt,
                     bool isActive)
        {
            Id = id;
            Authentication = authentication;
            Authorization = authorization;
            Profile = profile;
            CreatedAt = createdAt;
            IsActive = isActive;
        }

        /// <summary>
        /// Creates new user.
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="passwordHash"></param>
        /// <param name="personName"></param>
        /// <param name="tfaSecret"></param>
        /// <param name="version"></param>
        /// <param name="createdAt"></param>
        /// <returns></returns>
        public static User Create(string emailAddress,
                                  string passwordHash,
                                  string personName,
                                  string tfaSecret,
                                  Guid version,
                                  long createdAt)
        {
            Guid id = Guid.NewGuid();

            User user = new User(id,
                                 Authentication.Create(id,
                                                       PasswordHash.Create(passwordHash) ??
                                                       throw new PasswordHashNullDomainException(),

                                                       TFASecret.Create(tfaSecret) ??
                                                       throw new TFASecretNullDomainException(),

                                                       TokenVersion.Create(version) ??
                                                       throw new TokenVersionNullDomainException()) ??
                                 throw new AuthenticationNullDomainException(),

                                 Authorization.Create(id) ??
                                 throw new AuthorizationNullDomainException(),

                                 Profile.Create(id,
                                                EmailAddress.Create(emailAddress) ??
                                                throw new EmailAddressNullDomainException(),

                                                PersonName.Create(personName) ??
                                                throw new PersonNameNullDomainException()) ??
                                 throw new ProfileNullDomainException(),

                                 createdAt,
                                 false);

            user.AddDomainEvent(new UserCreatedDomainEvent(user.Id));

            return user;
        }


        public Authentication Authentication { get; private set; }

        public Authorization Authorization { get; private set; }

        public Profile Profile { get; private set; }

        public long CreatedAt { get; private set; }

        public bool IsActive { get; private set; }

        /// <summary>
        /// Changes user`s password hash.
        /// </summary>
        /// <param name="passwordHash"></param>
        /// <exception cref="PasswordHashNullDomainException"></exception>
        public void ChangePassword(string passwordHash)
        {
            PasswordHash password = PasswordHash.Create(passwordHash) ??
                                    throw new PasswordHashNullDomainException();
            Authentication.ChangePassword(password);

            Guid version = Guid.NewGuid();
            ChangeTokenVersion(version);
        }

        /// <summary>
        /// Changes token version for revokes all tokens.
        /// </summary>
        /// <param name="version"></param>
        /// <exception cref="TokenVersionNullDomainException"></exception>
        public void ChangeTokenVersion(Guid version)
        {
            TokenVersion tokenVersion = TokenVersion.Create(version) ??
                                        throw new TokenVersionNullDomainException();
            Authentication.ChangeTokenVersion(tokenVersion);
        }

        /// <summary>
        /// Changes user`s email address.
        /// </summary>
        /// <param name="email"></param>
        /// <exception cref="EmailAddressNullDomainException"></exception>
        public void ChangeEmailAddress(string email)
        {
            EmailAddress emailAddress = EmailAddress.Create(email) ??
                                        throw new EmailAddressNullDomainException();
            Profile.ChangeEmailAddress(emailAddress);
        }

        /// <summary>
        /// Changes the username in the profile.
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="PersonNameNullDomainException"></exception>
        public void ChangePersonName(string name)
        {
            PersonName personName = PersonName.Create(name) ??
                                    throw new PersonNameNullDomainException();
            Profile.ChangePersonName(personName);
        }

        /// <summary>
        /// Grantes the role permission.
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="createdAt"></param>
        /// <exception cref="PermissionAlreadyExistsDomainException"></exception>
        public void GrantRolePermission(Guid roleId, long createdAt)
        {
            if (Authorization.HasRolePermission(x => x.RoleId == roleId &&
                                                     x.IsValid()))
                throw new PermissionAlreadyExistsDomainException();

            Authorization.GrantRolePermission(roleId, createdAt);
        }

        /// <summary>
        /// Revokes the role permission.
        /// </summary>
        /// <param name="rolePermissionId"></param>
        /// <exception cref="PermissionNotFoundDomainException"></exception>
        public void RevokeRolePermission(Guid rolePermissionId)
        {
            if (!Authorization.HasRolePermission(x => x.Id == rolePermissionId))
                throw new PermissionNotFoundDomainException();

            Authorization.RevokeRolePermission(rolePermissionId);
        }

        /// <summary>
        /// Grantes the scope permission.
        /// </summary>
        /// <param name="scopeId"></param>
        /// <param name="createdAt"></param>
        /// <param name="expiresAt"></param>
        /// <exception cref="PermissionAlreadyExistsDomainException"></exception>
        public void GrantScopePermission(Guid scopeId, long createdAt, long? expiresAt = null)
        {
            if (Authorization.HasScopePermission(x => x.ScopeId == scopeId &&
                                                     x.IsValidAt(createdAt)))
                throw new PermissionAlreadyExistsDomainException();

            Authorization.GrantScopePermission(scopeId, createdAt, expiresAt);
        }

        /// <summary>
        /// Revokes the scope permission.
        /// </summary>
        /// <param name="scopePermissionId"></param>
        /// <exception cref="PermissionNotFoundDomainException"></exception>
        public void RevokeScopePermission(Guid scopePermissionId)
        {
            if (!Authorization.HasScopePermission(x => x.Id == scopePermissionId))
                throw new PermissionNotFoundDomainException();

            Authorization.RevokeScopePermission(scopePermissionId);
        }

        /// <summary>
        /// Activates the user account.
        /// </summary>
        public void Activate()
        {
            IsActive = true;
        }

        /// <summary>
        /// Deactivates the user account.
        /// </summary>
        public void Deactivate()
        {
            IsActive = false;
        }
    }

    #region Ef

    public partial class User
    {
        private User()
        {
        }
    }

    #endregion
}
