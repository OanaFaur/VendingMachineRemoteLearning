using iQuest.VendingMachine.PurchaseLogic.PaymentMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VendingMachine.Tests")]
namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyView : IBuyView
    {
        public string RequestId()
        {
            Console.WriteLine("Please insert the product id");
            return Console.ReadLine();
        }
        public void DispenseProduct(string productName)
        {
            Console.WriteLine("You've received a {0}", productName);
        }

        public int AskForPaymentMethod(List<PaymentMethod> paymentMethods)
        {
            int choice = 0;
            bool isConvertible;

            do
            {
                ShowPaymentMethods(paymentMethods);
                isConvertible = Int32.TryParse(Console.ReadLine(), out choice);

            } while (!paymentMethods.Any(k => k.Id == choice));

            return choice;
        }

        private void ShowPaymentMethods(List<PaymentMethod> paymentMethods)
        {
            Console.WriteLine("Choose the id of one of the payments above");
            for (int i = 0; i <= paymentMethods.Count - 1; i++)
            {
                Console.WriteLine("{0} {1}", paymentMethods[i].Id, paymentMethods[i].Name);
            }
        }
    }
}
