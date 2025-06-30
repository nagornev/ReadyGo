namespace ReadyGo.Identity.Domain.Failures.Exceptions.Users
{
    public class PermissionAlreadyExistsDomainException : AlreadyExistsDomainException
    {
        private const string _message = "The permission already exists.";

        public PermissionAlreadyExistsDomainException()
            : base(_message)
        {
        }
    }
}
