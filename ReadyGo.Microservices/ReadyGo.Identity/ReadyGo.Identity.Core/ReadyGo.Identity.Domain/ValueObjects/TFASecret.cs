using ReadyGo.Identity.Domain.Abstractions.Primitives;
using ReadyGo.Identity.Domain.Failures.Exceptions.Users;

namespace ReadyGo.Identity.Domain.ValueObjects
{
    public class TFASecret : ValueObject
    {
        private TFASecret(string value)
        {
            Value = value;
        }

        internal static TFASecret Create(string value)
        {
            if (string.IsNullOrEmpty(value) ||
                string.IsNullOrWhiteSpace(value))
                throw new TFASecretEmptyDomainException();

            return new TFASecret(value);
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
