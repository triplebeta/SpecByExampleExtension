using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.Common
{
    /// <summary>
    /// Define our own exception to indicate we are not on the expected page.
    /// </summary>
    public class InvalidPageException : Exception
    {
        public InvalidPageException() : base() { }
        public InvalidPageException(string message) : base(message) { }
        public InvalidPageException(string message, Exception innerException) : base(message, innerException) { }
    }
}
