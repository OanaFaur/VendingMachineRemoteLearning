using System;

namespace DataAccess.Exceptions
{
    internal class NullProductException:Exception
    {
        private const string DefaultMessage = "The product was null";

        public NullProductException() : base(DefaultMessage)
        {

        }
    }
}
