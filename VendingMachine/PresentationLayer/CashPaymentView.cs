using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CashPaymentView : ICashPaymentView
    {
        public string AskForMoneyMessage()
        {
            Console.WriteLine("Insert money");
            string value = Console.ReadLine();

            return value;
        }

        public void AskForRomanianMoneyMessage()
        {
            Console.WriteLine("Insert a Romanian type of money");
        }

        public void InvalidMoneyInsertedMessage()
        {
            Console.WriteLine("Invalid format");
        }

        public void GiveChange(int count, double moneyType)
        {
            Console.WriteLine("You received {0} of {1}", count, moneyType);
        }
    }
}
