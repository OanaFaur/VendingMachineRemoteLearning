using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.UseCases;
using System;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class CreateNewProductCommand : ICommandView
    {
        private readonly IUseCaseFactory useCaseFactory;

        private readonly IAuthenticationService authenticationService;
        public string Name => "Create";

        public string Description => "Add a new product";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public CreateNewProductCommand(IUseCaseFactory useCaseFactory, IAuthenticationService authenticationService)
        {
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            useCaseFactory.Create<CreateNewProductUseCase>().Execute();
        }
    }
}
