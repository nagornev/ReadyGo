namespace ReadyGo.Identity.Domain.Failures.Exceptions.Users
{
    public class TFASecretEmptyDomainException : EmptyDomainException
    {
        private const string _message = "The TFA secret cannot be empty.";

        public TFASecretEmptyDomainException()
            : base(_message)
        {
        }
    }
}
