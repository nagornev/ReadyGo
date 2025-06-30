namespace ReadyGo.Identity.Domain.Failures.Exceptions.Users
{
    public class TokenVersionNullDomainException : NullDomainException
    {
        private const string _message = "The token version cannot be null.";

        public TokenVersionNullDomainException()
            : base(_message)
        {
        }
    }
}
