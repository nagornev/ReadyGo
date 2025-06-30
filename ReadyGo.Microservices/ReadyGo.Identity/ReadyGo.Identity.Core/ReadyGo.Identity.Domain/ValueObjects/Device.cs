using ReadyGo.Identity.Domain.Abstractions.Primitives;
using ReadyGo.Identity.Domain.Failures.Exceptions.Sessions;

namespace ReadyGo.Identity.Domain.ValueObjects
{
    public class Device : ValueObject
    {
        private Device(string value)
        {
            Value = value;
        }
        internal static Device Create(string value)
        {
            if (string.IsNullOrEmpty(value) ||
                string.IsNullOrWhiteSpace(value))
                throw new DeviceEmptyDomainException();

            return new Device(value);
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
