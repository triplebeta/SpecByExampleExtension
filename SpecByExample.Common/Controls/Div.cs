using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace SpecByExample.Common.Controls
{
    /// <summary>
    /// Adapter for DIV elements in the HTML
    /// </summary>
    public class Div : BaseSeleniumControl
    {
        /// <summary>
        /// Text of this control
        /// </summary>
        public string Text
        {
            get { return InnerWebElement.Text; }
        }

        /// <summary>
        /// True if this control is a container for other controls.
        /// Examples are div or span tags. Default is false.
        /// </summary>
        public override bool IsContainer
        {
            get { return true; }
        }
    }
}
