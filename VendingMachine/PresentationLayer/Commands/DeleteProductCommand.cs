using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.UseCases;
using System;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class DeleteProductCommand : ICommandView
    {
        private readonly IUseCaseFactory useCaseFactory;

        private readonly IAuthenticationService authenticationService;
        public string Name => "Delete";

        public string Description => "Delete a product";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public DeleteProductCommand(IUseCaseFactory useCaseFactory, IAuthenticationService authenticationService)
        {
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            useCaseFactory.Create<DeleteProductUseCase>().Execute();
        }
    }
}
