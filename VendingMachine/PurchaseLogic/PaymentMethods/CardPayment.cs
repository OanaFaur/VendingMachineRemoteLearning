using iQuest.VendingMachine.Logger;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PurchaseLogic.PaymentExceptions;

namespace iQuest.VendingMachine.PurchaseLogic.PaymentMethods
{
    internal class CardPayment : IPaymentAlgorithm
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IEventViewerWriter eventViewer;
        public string Name => "Card";

        private readonly ICardPaymentView cardView;

        public CardPayment(ICardPaymentView terminal, IEventViewerWriter eventViewer)
        {
            cardView = terminal;

            this.eventViewer = eventViewer;
        }

        public void Run(double price)
        {
            string cardNo = cardView.AskForCardNumber();

            if (!CheckCardValidation(cardNo))
            {
                log.Error(new InvalidCardException());
                eventViewer.EventLogger("InvalidCard");
                throw new InvalidCardException();
            }
            else
            {
                cardView.MoneyRetractedFromCard(price);
            }
        }

        private bool CheckCardValidation(string cardNo)
        {
            int nDigits = cardNo.Length;

            int nSum = 0;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {

                int d = cardNo[i] - '0';

                if (isSecond)
                    d *= 2;

                nSum += d / 10;
                nSum += d % 10;

                isSecond = !isSecond;
            }
            return (nSum % 10 == 0);
        }
    }
}
