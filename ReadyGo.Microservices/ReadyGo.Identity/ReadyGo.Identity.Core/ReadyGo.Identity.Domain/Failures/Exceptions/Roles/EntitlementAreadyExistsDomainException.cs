namespace ReadyGo.Identity.Domain.Failures.Exceptions.Roles
{
    public class EntitlementAreadyExistsDomainException : AlreadyExistsDomainException
    {
        private const string _message = "The entitlement with id ({0}) already exists.";

        public EntitlementAreadyExistsDomainException(Guid scopeId)
            : base(string.Format(_message, scopeId))
        {
        }
    }
}
