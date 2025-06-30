using ReadyGo.Identity.Domain.Exceptions;

namespace ReadyGo.Identity.Domain.Failures.Exceptions
{
    public class NotFoundDomainException : DomainException
    {
        public NotFoundDomainException(string message)
            : base(ErrorTypes.NotFound, message)
        {
        }
    }
}
