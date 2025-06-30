using ReadyGo.Identity.Domain.Abstractions.Primitives;
using ReadyGo.Identity.Domain.ValueObjects;

namespace ReadyGo.Identity.Domain.Entities
{
    public partial class Profile : Entity
    {
        private Profile(Guid id,
                        EmailAddress emailAddress,
                        PersonName personName)
        {
            Id = id;
            EmailAddress = emailAddress;
            PersonName = personName;
        }
        internal static Profile Create(Guid id,
                                       EmailAddress emailAddress,
                                       PersonName personName)
        {
            return new Profile(id,
                               emailAddress,
                               personName);
        }

        public EmailAddress EmailAddress { get; private set; }

        public PersonName PersonName { get; private set; }

        internal void ChangeEmailAddress(EmailAddress emailAddress)
        {
            EmailAddress = emailAddress;
        }

        internal void ChangePersonName(PersonName personName)
        {
            PersonName = personName;
        }
    }

    #region Ef

    public partial class Profile
    {
        private Profile()
        {
        }
    }

    #endregion
}
