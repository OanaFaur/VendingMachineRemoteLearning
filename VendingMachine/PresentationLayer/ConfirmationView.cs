using iQuest.VendingMachine.PurchaseLogic.ProductValidationExceptions;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VendingMachine.Tests")]
namespace iQuest.VendingMachine.PresentationLayer
{
    internal class ConfirmationView : IConfirmationView
    {
        public string UserConfirmation()
        {
            Console.WriteLine("Please confirm[y/n]");
            string insertedValue = Console.ReadLine();

            return insertedValue;
        }

        public void IsSelectionConfirmed()
        {
            string value;
            do
            {
                value = UserConfirmation();

                if (value == "y")
                {
                    break;
                }

                if (value == "n")
                {
                    throw new CancelException();
                }

            } while (value != "y" || value != "n");
        }
    }
}
