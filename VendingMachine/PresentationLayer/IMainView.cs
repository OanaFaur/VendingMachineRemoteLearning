using iQuest.VendingMachine.PresentationLayer.Commands;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal interface IMainView
    {
        ICommandView ChooseCommand(IEnumerable<ICommandView> useCases);
        void DisplayApplicationHeader();
    }
}