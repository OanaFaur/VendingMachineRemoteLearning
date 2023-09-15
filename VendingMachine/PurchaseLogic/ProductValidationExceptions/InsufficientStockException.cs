using System;

namespace iQuest.VendingMachine.PurchaseLogic.ProductValidationExceptions
{
    internal class InsufficientStockException : Exception
    {
        private const string DefaultMessage = "This product is out of stock";

        public InsufficientStockException() : base(DefaultMessage)
        {

        }
    }
}
