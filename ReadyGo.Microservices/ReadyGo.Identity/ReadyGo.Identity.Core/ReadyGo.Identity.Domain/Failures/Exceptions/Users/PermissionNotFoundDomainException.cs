namespace ReadyGo.Identity.Domain.Failures.Exceptions.Users
{
    public class PermissionNotFoundDomainException : NotFoundDomainException
    {
        private const string _message = "The permission was not found.";

        public PermissionNotFoundDomainException()
            : base(_message)
        {
        }
    }
}
