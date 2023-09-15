namespace iQuest.VendingMachine.PurchaseLogic.PaymentMethods
{
    public interface IPaymentAlgorithm
    {
        string Name { get; }
        void Run(double price);
    }
}
