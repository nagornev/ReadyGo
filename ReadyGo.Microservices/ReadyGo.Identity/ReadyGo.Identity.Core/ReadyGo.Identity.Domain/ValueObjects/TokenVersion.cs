using ReadyGo.Identity.Domain.Abstractions.Primitives;
using ReadyGo.Identity.Domain.Failures.Exceptions.Users;

namespace ReadyGo.Identity.Domain.ValueObjects
{
    public class TokenVersion : ValueObject
    {
        private TokenVersion(Guid value)
        {
            Value = value;
        }

        internal static TokenVersion Create(Guid value)
        {
            if (value == Guid.Empty)
                throw new TokenVersionEmptyDomainException();

            return new TokenVersion(value);
        }

        public Guid Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
