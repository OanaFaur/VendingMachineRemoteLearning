using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.UseCases;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class LoginCommand : ICommandView
    {
        private readonly IUseCaseFactory useCaseFactory;
        private readonly IAuthenticationService authenticationService;
        public string Name => "Login";

        public string Description => "Login inside machine";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;


        public LoginCommand(IUseCaseFactory useCaseFactory, IAuthenticationService service)
        {
            this.useCaseFactory = useCaseFactory;
            authenticationService = service;
        }

        public void Execute()
        {
            useCaseFactory.Create<LoginUseCase>().Execute();
        }
    }
}
