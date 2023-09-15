using iQuest.VendingMachine.PresentationLayer.Commands;
using iQuest.VendingMachine.UseCases;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class MainView : DisplayBase, IMainView
    {
        public void DisplayApplicationHeader()
        {
            ApplicationHeaderControl applicationHeaderControl = new ApplicationHeaderControl();
            applicationHeaderControl.Display();
        }

        public ICommandView ChooseCommand(IEnumerable<ICommandView> useCases)
        {
            CommandSelectorControl commandSelectorControl = new CommandSelectorControl
            {
                UseCases = useCases
            };
            return commandSelectorControl.Display();
        }
    }
}