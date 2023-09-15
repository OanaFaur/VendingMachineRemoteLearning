using System;

namespace iQuest.VendingMachine.PurchaseLogic.PaymentExceptions
{
    internal class InvalidCardException : Exception
    {
        private const string DefaultMessage = "The card you provided is invalid";
        public InvalidCardException() : base(DefaultMessage)
        {

        }
    }
}
