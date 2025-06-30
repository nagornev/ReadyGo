namespace ReadyGo.Identity.Domain.Failures.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(int type,
                               string message)
            : base(message)
        {
            Type = type;
        }

        public int Type { get; private set; }
    }
}
