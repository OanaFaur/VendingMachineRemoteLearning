using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CardPaymentView : ICardPaymentView
    {
        public string AskForCardNumber()
        {
            Console.WriteLine("Insert your card number");
            string cardNumberInserted = Console.ReadLine();

            return cardNumberInserted;
        }

        public void MoneyRetractedFromCard(double price)
        {
            Console.WriteLine("{0} have been retracted from your card", price);
        }
    }
}
