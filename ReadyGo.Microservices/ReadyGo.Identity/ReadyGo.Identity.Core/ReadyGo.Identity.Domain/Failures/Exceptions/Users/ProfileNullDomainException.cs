namespace ReadyGo.Identity.Domain.Failures.Exceptions.Users
{
    public class ProfileNullDomainException : NullDomainException
    {
        private const string _message = "The profile cannot be null.";

        public ProfileNullDomainException()
            : base(_message)
        {
        }
    }
}
