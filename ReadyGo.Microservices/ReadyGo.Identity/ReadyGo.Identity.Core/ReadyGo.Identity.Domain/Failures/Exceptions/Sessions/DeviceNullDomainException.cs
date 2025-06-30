namespace ReadyGo.Identity.Domain.Failures.Exceptions.Sessions
{
    public class DeviceNullDomainException : NullDomainException
    {
        private const string _message = "The session device cannot be null.";

        public DeviceNullDomainException()
            : base(_message)
        {
        }
    }
}
