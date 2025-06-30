using ReadyGo.Identity.Domain.Exceptions;

namespace ReadyGo.Identity.Domain.Failures.Exceptions
{
    public class OutOfRangeDomainException : DomainException
    {
        public OutOfRangeDomainException(string message)
            : base(ErrorTypes.OutOfRange, message)
        {
        }
    }
}
