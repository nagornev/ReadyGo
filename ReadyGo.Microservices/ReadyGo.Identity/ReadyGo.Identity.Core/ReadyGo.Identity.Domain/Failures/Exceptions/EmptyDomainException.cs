using ReadyGo.Identity.Domain.Exceptions;

namespace ReadyGo.Identity.Domain.Failures.Exceptions
{
    public class EmptyDomainException : DomainException
    {
        public EmptyDomainException(string message)
            : base(ErrorTypes.Empty, message)
        {
        }
    }
}
