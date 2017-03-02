using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecByExample.Common.Controls;
using OpenQA.Selenium;
using SpecByExample.Common;
using System.Text.RegularExpressions;

namespace TestProject4.Common.Controls
{
    /// <summary>
    /// Wrapper for a clickable table that act as a button.
    /// This expects a tables with an OnClick event attached to it and redefines the click on it.
    /// </summary>
    /// <remarks>This is an example of a custom control</remarks>
    public class TableAsButton : BaseSeleniumControl
    {

        /// <summary>
        /// Extends the standard initializations by performing additional checks.
        /// </summary>
        /// <param name="innerElement"></param>
        /// <exception cref="HtmlElementIsNoInputElementException">Thrown if it's not an input control.</exception>
        public override void Initialize(IWebDriver driver, IWebElement innerElement)
        {
            base.Initialize(driver, innerElement);
            if (innerElement.TagName.Equals("table", StringComparison.InvariantCultureIgnoreCase) == false ||
                String.IsNullOrEmpty(innerElement.GetAttribute("onclick")))
                throw new InvalidHtmlInputTypeException("The element is not a table or it does not contain an onclick event.");
        }

        /// <summary>
        /// Text of this control
        /// </summary>
        public string Text
        {
            get { return InnerWebElement.Text; }
        }

        /// <summary>
        /// Click the button
        /// </summary>
        public void Click()
        {
            // Click the link and make sure to do it thre right way:
            // - when it has an onclick attribute: run it
            // - otherwise: just invoke its Submit
            var script = InnerWebElement.GetAttribute("onclick");

            // Perform the actual clicking on the button
            if (String.IsNullOrEmpty(script) == false)
                ExecuteJavascriptCodeFromEvent("onclick");
            else
                InnerWebElement.Submit();
        }
    }
}
