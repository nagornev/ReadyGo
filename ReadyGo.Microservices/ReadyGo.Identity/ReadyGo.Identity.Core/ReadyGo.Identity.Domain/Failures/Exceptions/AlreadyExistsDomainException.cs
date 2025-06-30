using ReadyGo.Identity.Domain.Exceptions;

namespace ReadyGo.Identity.Domain.Failures.Exceptions
{
    public class AlreadyExistsDomainException : DomainException
    {
        public AlreadyExistsDomainException(string message)
            : base(ErrorTypes.AlreadyExists, message)
        {
        }
    }
}
