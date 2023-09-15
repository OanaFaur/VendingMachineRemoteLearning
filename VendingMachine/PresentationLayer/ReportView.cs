using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class ReportView : IReportView
    {
        public DateTime AskForStartDate()
        {
            DateTime date;

            bool isConvertible;
            Console.WriteLine("Please insert the start date ");
            do
            {
                isConvertible = DateTime.TryParse(Console.ReadLine(), out date);

            } while (!isConvertible);

            return date;
        }

        public DateTime AskForEndDate()
        {
            DateTime date;

            bool isConvertible;
            Console.WriteLine("Please insert the end date ");
            do
            {
                isConvertible = DateTime.TryParse(Console.ReadLine(), out date);

            } while (!isConvertible);

            return date;
        }
    }
}
