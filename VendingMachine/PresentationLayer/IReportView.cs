using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal interface IReportView
    {
        DateTime AskForEndDate();
        DateTime AskForStartDate();
    }
}