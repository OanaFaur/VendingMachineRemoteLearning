namespace iQuest.VendingMachine.PresentationLayer
{
    internal interface ICardPaymentView
    {
        string AskForCardNumber();
        void MoneyRetractedFromCard(double price);
    }
}