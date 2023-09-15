using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.UseCases;
using System;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    class LogoutCommand : ICommandView
    {
        private readonly IAuthenticationService authenticationService;
        private IUseCaseFactory useCaseFactory;
        public string Name => "Logout";

        public string Description => "Logout from app";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public LogoutCommand(IUseCaseFactory useCaseFactory, IAuthenticationService service)
        {
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
            authenticationService = service ?? throw new ArgumentNullException(nameof(service));
        }
        public void Execute()
        {
            useCaseFactory.Create<LogoutUseCase>().Execute();
        }
    }
}
