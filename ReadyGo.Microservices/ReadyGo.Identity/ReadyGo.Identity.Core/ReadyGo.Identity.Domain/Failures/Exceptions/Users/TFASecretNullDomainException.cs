namespace ReadyGo.Identity.Domain.Failures.Exceptions.Users
{
    public class TFASecretNullDomainException : NullDomainException
    {
        private const string _message = "The TFA secret cannot be empty.";

        public TFASecretNullDomainException()
            : base(_message)
        {
        }
    }
}
