namespace ReadyGo.Identity.Domain.Failures.Exceptions.Users
{
    public class EmailAddressInvalidFormatDomainException : InvalidFormatDomainException
    {
        private const string _message = "The email address has an invalid format.";

        public EmailAddressInvalidFormatDomainException()
            : base(_message)
        {
        }
    }
}
