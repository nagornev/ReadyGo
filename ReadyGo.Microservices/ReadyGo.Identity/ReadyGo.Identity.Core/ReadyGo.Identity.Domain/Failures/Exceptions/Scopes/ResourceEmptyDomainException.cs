namespace ReadyGo.Identity.Domain.Failures.Exceptions.Scopes
{
    public class ResourceEmptyDomainException : EmptyDomainException
    {
        private const string _message = "The scope resource cannot be empty.";

        public ResourceEmptyDomainException()
            : base(_message)
        {
        }
    }
}
