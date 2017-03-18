using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SpecByExample.Common.Controls
{
    /// <summary>
    /// Adapter for Button elements in the HTML
    /// </summary>
    public class Button : BaseSeleniumControl
    {
        /// <summary>
        /// Extends the standard initializations by performing additional checks.
        /// </summary>
        /// <param name="innerElement"></param>
        /// <exception cref="HtmlElementIsNoInputElementException">Thrown if it's not an input control.</exception>
        public override void Initialize(IWebDriver driver, IWebElement innerElement)
        {
            base.Initialize(driver,innerElement);
            if (innerElement.TagName.Equals("button", StringComparison.InvariantCultureIgnoreCase)==false &&
                innerElement.TagName.Equals("input", StringComparison.InvariantCultureIgnoreCase) == false)
                throw new InvalidHtmlInputTypeException("The element is not a button.");
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
            var href = InnerWebElement.GetAttribute("href");
            if (String.IsNullOrEmpty(href) == false)
            {
                CurrentWebDriver.Url = href;
                CurrentWebDriver.Navigate();
            }
            else
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
}
