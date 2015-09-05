using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.Common
{
    public class InvalidHtmlInputTypeException : Exception
    {
        public InvalidHtmlInputTypeException() : base() { }
        public InvalidHtmlInputTypeException(string message) : base(message) { }
        public InvalidHtmlInputTypeException(string message, Exception innerException) : base(message, innerException) { }
    }
}
