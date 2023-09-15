using System;

namespace DataAccess.Exceptions
{
    internal class InvalidProductIdException : Exception
    {
        private const string message = "This product doesn't exist";

        public InvalidProductIdException() : base(message)
        {

        }
    }
}
