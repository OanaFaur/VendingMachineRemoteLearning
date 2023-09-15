using iQuest.VendingMachine.PurchaseLogic.PaymentMethods;

namespace iQuest.VendingMachine.UseCases
{
    public interface IPaymentUseCase
    {
        void Execute(double price);

        IPaymentAlgorithm PaymentMethodChoice { get; set; }
    }
}