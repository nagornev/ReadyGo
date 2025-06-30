using ReadyGo.Identity.Domain.Abstractions.Primitives;
using ReadyGo.Identity.Domain.Failures.Exceptions.Scopes;

namespace ReadyGo.Identity.Domain.ValueObjects
{
    public class Action : ValueObject
    {
        private Action(string value)
        {
            Value = value;
        }

        internal static Action Create(string value)
        {
            if (string.IsNullOrEmpty(value) ||
                string.IsNullOrWhiteSpace(value))
                throw new ActionEmptyDomainException();

            return new Action(value);
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
