using System;

namespace mattresses_management_dektop_app.Core.Exceptions
{
    public class InvalidInitializationException : Exception
    {
        public InvalidInitializationException(string message) : base(message)
        {
        }
    }
}