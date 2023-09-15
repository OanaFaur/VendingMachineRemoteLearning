using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.UseCases;
using System;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    class StockReportCommand : ICommandView
    {

        private readonly IUseCaseFactory useCaseFactory;

        private readonly IAuthenticationService authenticationService;
        public string Name => "Stock";

        public string Description => "Create a Stock report";

        public bool CanExecute => authenticationService.IsUserAuthenticated;


        public StockReportCommand(IUseCaseFactory useCaseFactory, IAuthenticationService authenticationService)
        {
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            useCaseFactory.Create<StockReportUseCase>().Execute();
        }
    }
}
