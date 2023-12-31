﻿
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VendingMachine.Tests")]
namespace iQuest.VendingMachine.Authentication
{
    internal class AuthenticationService : IAuthenticationService
    {
        public bool IsUserAuthenticated { get; private set; }

        public void Login(string password)
        {
            if (password == "remote")
                IsUserAuthenticated = true;
            else
                throw new InvalidPasswordException();
        }

        public void Logout()
        {
            IsUserAuthenticated = false;
        }
    }
}