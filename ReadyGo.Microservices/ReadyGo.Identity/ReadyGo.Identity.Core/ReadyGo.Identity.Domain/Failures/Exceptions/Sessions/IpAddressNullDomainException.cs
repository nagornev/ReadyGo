﻿namespace ReadyGo.Identity.Domain.Failures.Exceptions.Sessions
{
    public class IpAddressNullDomainException : NullDomainException
    {
        private const string _message = "The user`s ip address cannot be null.";

        public IpAddressNullDomainException()
            : base(_message)
        {
        }
    }
}
