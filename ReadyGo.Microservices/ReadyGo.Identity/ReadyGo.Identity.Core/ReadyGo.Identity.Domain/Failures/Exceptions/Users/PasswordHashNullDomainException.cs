namespace ReadyGo.Identity.Domain.Failures.Exceptions.Users
{
    public class PasswordHashNullDomainException : NullDomainException
    {
        private const string _message = "The password hash cannot be null.";

        public PasswordHashNullDomainException()
            : base(_message)
        {
        }
    }
}
