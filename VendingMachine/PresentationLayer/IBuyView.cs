using iQuest.VendingMachine.PurchaseLogic.PaymentMethods;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    public interface IBuyView
    {
        void DispenseProduct(string productName);
        string RequestId();

        int AskForPaymentMethod(List<PaymentMethod> paymentMethods);

    }
}