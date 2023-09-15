using iQuest.VendingMachine.UseCases;
using System;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    class LookCommand : ICommandView
    {
        public string Name => "Display";

        public string Description => "Display items from machine";

        public bool CanExecute => true;

        private IUseCaseFactory useCaseFactory;


        public LookCommand(IUseCaseFactory useCaseFactory)
        {
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<LookUseCase>().Execute();
        }
    }
}
