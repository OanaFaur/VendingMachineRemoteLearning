using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.UseCases;
using System;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class UpdateProductCommand:ICommandView
    {
        private readonly IUseCaseFactory useCaseFactory;

        private readonly IAuthenticationService authenticationService;
        public string Name => "Update";

        public string Description => "Update a product";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public UpdateProductCommand(IUseCaseFactory useCaseFactory, IAuthenticationService authenticationService)
        {
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            useCaseFactory.Create<UpdateProductUseCase>().Execute();
        }
    }
}
