using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PresentationLayer.Commands;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine
{
    internal class VendingMachineApplication : IVendingMachineApplication
    {
        private readonly IEnumerable<ICommandView> useCases;
        private readonly IMainView mainView;

        public VendingMachineApplication(IEnumerable<ICommandView> useCases, IMainView mainView)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
        }

        public void Run()
        {
            mainView.DisplayApplicationHeader();

            while (true)
            {
                IEnumerable<ICommandView> availableUseCases = GetExecutableUseCases();

                ICommandView useCase = mainView.ChooseCommand(availableUseCases);
                useCase.Execute();
            }
        }

        private List<ICommandView> GetExecutableUseCases()
        {
            
            List<ICommandView> executableUseCases = new List<ICommandView>();

            foreach (ICommandView useCase in useCases)
            {
                if (useCase.CanExecute)
                    executableUseCases.Add(useCase);
            }

            return executableUseCases;
        }
    }
}