using System;

namespace iQuest.VendingMachine.PurchaseLogic.ProductValidationExceptions
{
    internal class CancelException : Exception
    {
        private const string DefaultMessage = "Operation canceled";

        public CancelException() : base(DefaultMessage)
        {

        }
    }
}
