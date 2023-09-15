namespace iQuest.VendingMachine.PresentationLayer
{
    internal interface ICashPaymentView
    {
        string AskForMoneyMessage();
        void AskForRomanianMoneyMessage();
        void GiveChange(int count, double moneyType);
        void InvalidMoneyInsertedMessage();
    }
}