using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.UseCases;
using System;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class VolumeReportCommand : ICommandView
    {
        private readonly IUseCaseFactory useCaseFactory;

        private readonly IAuthenticationService authenticationService;

        public string Name => "Volume";

        public string Description => "Create a Volume Report";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public VolumeReportCommand(IUseCaseFactory useCaseFactory, IAuthenticationService authenticationService)
        {
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            useCaseFactory.Create<VolumeReportUseCase>().Execute();
        }
    }
}
