using ReadyGo.Identity.Domain.Exceptions;

namespace ReadyGo.Identity.Domain.Failures.Exceptions
{
    public class InvalidFormatDomainException : DomainException
    {
        public InvalidFormatDomainException(string message)
            : base(ErrorTypes.InvalidFomat, message)
        {
        }
    }
}
