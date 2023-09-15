using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.UseCases;
using System;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class SaleReportCommand : ICommandView
    {
        private readonly IUseCaseFactory useCaseFactory;

        private readonly IAuthenticationService authenticationService;

        public string Name => "Sales";

        public string Description => "Create a Sales report";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public SaleReportCommand(IUseCaseFactory useCaseFactory, IAuthenticationService authenticationService)
        {
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            useCaseFactory.Create<SalesReportUseCase>().Execute();
        }
    }
}
