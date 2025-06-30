using ReadyGo.Identity.Domain.Abstractions.Primitives;
using ReadyGo.Identity.Domain.Failures.Exceptions.Sessions;
using System.Text.RegularExpressions;

namespace ReadyGo.Identity.Domain.ValueObjects
{
    public class IpAddress : ValueObject
    {
        public const string Format = @"^((25[0-5]|(2[0-4]|1\d|[1-9]|)\d)\.?\b){4}$";

        private IpAddress(string value)
        {
            Value = value;
        }

        internal static IpAddress Create(string value)
        {
            if (string.IsNullOrEmpty(value) ||
                string.IsNullOrWhiteSpace(value))
                throw new IpAddressEmptyDomainException();

            if (!Regex.IsMatch(value, Format))
                throw new IpAddressInvalidFormatDomainException();

            return new IpAddress(value);
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
