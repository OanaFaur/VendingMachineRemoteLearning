using DataAccess;
using DataAccess.Models;
using iQuest.VendingMachine.Logger;
using iQuest.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.VendingMachine.PurchaseLogic.PaymentMethods
{
    internal class CashPayment : IPaymentAlgorithm
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IEventViewerWriter eventViewer;

        private readonly IMoneyRepository moneyRepo;
        private readonly ICashPaymentView cashTerminal;

        public static double Sum { get; set; }

        public string Name => "Cash";

        public CashPayment(ICashPaymentView cashTerminal, IMoneyRepository moneyRepo, IEventViewerWriter eventViewer)
        {
            this.cashTerminal = cashTerminal;
            this.moneyRepo = moneyRepo;
            this.eventViewer = eventViewer;
        }

        public void Run(double price)
        {
            while (Sum != price)
            {
                double value = AskForMoney();

                IncrementSum(value);
                if (Sum > price)
                {
                    GiveChange(price);
                    break;
                }
            }

            Sum = 0;
        }

        private void IncrementSum(double value)
        {
            Sum += value;
        }

        private double AskForMoney()
        {
            double moneyInserted = 0;
            try
            {
                do
                {
                    moneyInserted = double.Parse(cashTerminal.AskForMoneyMessage());

                } while (!AskForRomanianMoney(moneyInserted));
            }
            catch (FormatException e)
            {
                log.Error(e + "\n");
                eventViewer.EventLogger("Invalid money inserted");
                cashTerminal.InvalidMoneyInsertedMessage();
            }

            return moneyInserted;
        }

        private void GiveChange(double price)
        {
            List<CashMoney> money = moneyRepo.GetAll().ToList();
            double change = Sum - price;

            for (int i = money.Count - 1; i >= 0; i--)
            {
                int count = (int)(change / money[i].MoneyType);

                if (count > 0)
                {
                    cashTerminal.GiveChange(count, money[i].MoneyType);
                    change %= (int)(money[i].MoneyType);
                }
            }
        }

        private bool AskForRomanianMoney(double value)
        {
            CashMoney money = moneyRepo.FindByMoneyType(value);

            bool state = false;

            if (money == null)
            {
                cashTerminal.AskForRomanianMoneyMessage();
            }
            else
            {
                state = true;
            }

            return state;
        }
    }
}
