using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.Common
{
    public class HtmlElementIsNoInputElementException : Exception
    {
        public HtmlElementIsNoInputElementException() : base() { }
        public HtmlElementIsNoInputElementException(string message) : base(message) { }
        public HtmlElementIsNoInputElementException(string message, Exception innerException) : base(message, innerException) { }
    }
}
