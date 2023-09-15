using System;
using iQuest.VendingMachine.Authentication;

namespace iQuest.VendingMachine.UseCases
{
    internal class LogoutUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;

        public LogoutUseCase(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            authenticationService.Logout();
        }
    }
}