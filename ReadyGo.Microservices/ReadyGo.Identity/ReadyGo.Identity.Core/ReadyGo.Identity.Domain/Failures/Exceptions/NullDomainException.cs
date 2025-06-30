using ReadyGo.Identity.Domain.Exceptions;

namespace ReadyGo.Identity.Domain.Failures.Exceptions
{
    public class NullDomainException : DomainException
    {
        public NullDomainException(string message)
            : base(ErrorTypes.Null, message)
        {
        }
    }
}
