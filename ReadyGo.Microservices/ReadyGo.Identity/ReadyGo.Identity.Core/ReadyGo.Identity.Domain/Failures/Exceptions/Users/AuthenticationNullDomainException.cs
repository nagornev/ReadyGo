﻿namespace ReadyGo.Identity.Domain.Failures.Exceptions.Users
{
    public class AuthenticationNullDomainException : NullDomainException
    {
        private const string _message = "The user`s authentication cannot be null.";

        public AuthenticationNullDomainException()
            : base(_message)
        {
        }
    }
}
