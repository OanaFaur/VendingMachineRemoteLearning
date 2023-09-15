using System;

namespace DataAccess.Exceptions
{
    internal class InvalidDateInserted : Exception
    {
        private const string message = "Please insert a valid date. Use the - separator";

        public InvalidDateInserted() : base(message)
        {

        }
    }
}
