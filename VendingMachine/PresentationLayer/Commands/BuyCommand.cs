using iQuest.VendingMachine.UseCases;
using System;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class BuyCommand : ICommandView
    {
        public string Name => "Buy";

        public string Description => "Buy your item";

        public bool CanExecute => true;

        private IUseCaseFactory useCaseFactory;

        public BuyCommand(IUseCaseFactory useCaseFactory)
        {
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<BuyUseCase>().Execute();
        }
    }
}
