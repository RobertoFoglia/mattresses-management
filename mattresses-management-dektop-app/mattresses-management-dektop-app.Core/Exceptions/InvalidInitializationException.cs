using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Exceptions
{
    public class InvalidInitializationException : Exception
    {
        public InvalidInitializationException(string message) : base(message)
        {
        }
    }
}
