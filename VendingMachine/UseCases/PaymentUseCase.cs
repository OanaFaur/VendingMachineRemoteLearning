using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PurchaseLogic.PaymentMethods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.VendingMachine.UseCases
{
    internal class PaymentUseCase : IPaymentUseCase
    {
        private readonly IBuyView buyView;

        private readonly List<IPaymentAlgorithm> paymentAlgorithms;

        public IPaymentAlgorithm PaymentMethodChoice { get; set; }

        public PaymentUseCase(IBuyView buyView, IEnumerable<IPaymentAlgorithm> paymentAlgorithms)
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.paymentAlgorithms = paymentAlgorithms.ToList();
        }
        public void Execute(double price)
        {
            IPaymentAlgorithm payment = ChoosePaymentAlgorithm();
            payment.Run(price);
        }

        private int GetUserMethod()
        {
            List<PaymentMethod> paymentMethodInfos = new List<PaymentMethod>();
            for (int i = 0; i <= paymentAlgorithms.Count - 1; i++)
            {
                PaymentMethod paymentMethod = new PaymentMethod
                {
                    Id = i + 1,
                    Name = paymentAlgorithms[i].Name
                };
                paymentMethodInfos.Add(paymentMethod);
            }
            return buyView.AskForPaymentMethod(paymentMethodInfos);
        }

        private IPaymentAlgorithm ChoosePaymentAlgorithm()
        {

            int index = GetUserMethod();

            PaymentMethodChoice = paymentAlgorithms[index - 1];

            return paymentAlgorithms[index - 1];
        }
    }
}
