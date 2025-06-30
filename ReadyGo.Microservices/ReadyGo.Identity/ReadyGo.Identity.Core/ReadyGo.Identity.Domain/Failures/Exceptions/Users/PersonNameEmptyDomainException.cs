namespace ReadyGo.Identity.Domain.Failures.Exceptions.Users
{
    public class PersonNameEmptyDomainException : NullDomainException
    {
        private const string _message = "The person name cannot be empty.";

        public PersonNameEmptyDomainException()
            : base(_message)
        {
        }
    }
}
