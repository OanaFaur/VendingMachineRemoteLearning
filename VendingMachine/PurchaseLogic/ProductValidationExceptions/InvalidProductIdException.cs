using System;

namespace iQuest.VendingMachine.PurchaseLogic
{
    internal class InvalidProductIdException : Exception
    {
        private const string DefaultMessage = "The item with the inserted id was not found";

        public InvalidProductIdException() : base(DefaultMessage)
        {

        }
    }
}
