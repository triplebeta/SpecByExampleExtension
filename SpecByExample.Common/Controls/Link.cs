using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.Common.Controls
{
    /// <summary>
    /// Adapter for Link elements in the HTML
    /// </summary>
    public class Link : BaseSeleniumControl
    {
        /// <summary>
        /// Text of this control
        /// </summary>
        public string Text
        {
            get { return InnerWebElement.Text; }
        }


        /// <summary>
        /// Click the link.
        /// </summary>
        public void Click()
        {
            InnerWebElement.Click();
        }
    }
}
