using ReadyGo.Identity.Domain.Abstractions.Primitives;
using ReadyGo.Identity.Domain.Failures.Exceptions.Users;

namespace ReadyGo.Identity.Domain.ValueObjects
{
    public class PasswordHash : ValueObject
    {
        private PasswordHash(string value)
        {
            Value = value;
        }

        internal static PasswordHash Create(string value)
        {
            if (string.IsNullOrEmpty(value) ||
                string.IsNullOrWhiteSpace(value))
                throw new PasswordHashEmptyDomainException();

            return new PasswordHash(value);
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
