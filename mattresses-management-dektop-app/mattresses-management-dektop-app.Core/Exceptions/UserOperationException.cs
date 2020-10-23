using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Exceptions
{
    public class UserOperationException : Exception
    {
        public UserOperationException() { }

        public UserOperationException(String message) : base(message) { }

        public UserOperationException(String message, Exception inner) : base(message, inner) { }
    }
}
