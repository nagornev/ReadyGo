using ReadyGo.Identity.Domain.Abstractions.Primitives;
using ReadyGo.Identity.Domain.Failures.Exceptions.Scopes;

namespace ReadyGo.Identity.Domain.ValueObjects
{
    public class Resource : ValueObject
    {
        private Resource(string value)
        {
            Value = value;
        }

        internal static Resource Create(string value)
        {
            if (string.IsNullOrEmpty(value) ||
                string.IsNullOrWhiteSpace(value))
                throw new ResourceEmptyDomainException();

            return new Resource(value);
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
