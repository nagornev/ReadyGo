namespace ReadyGo.Identity.Domain.Failures.Exceptions.Scopes
{
    public class ActionEmptyDomainException : EmptyDomainException
    {
        private const string _message = "The scope action cannot be empty.";

        public ActionEmptyDomainException()
            : base(_message)
        {
        }
    }
}
