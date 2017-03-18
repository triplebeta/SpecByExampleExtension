using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace SpecByExample.Common.Controls
{
    /// <summary>
    /// Adapter for Checkbox elements in the HTML
    /// </summary>
    public class Checkbox : BaseSeleniumControl
    {
        /// <summary>
        /// Extends the standard initializations by performing additional checks.
        /// </summary>
        /// <param name="innerElement"></param>
        /// <exception cref="HtmlElementIsNoInputElementException">Thrown if it's not an input control.</exception>
        public override void Initialize(IWebDriver driver, IWebElement innerElement)
        {
            base.Initialize(driver,innerElement);
            if (this.InputType != HtmlInputType.Checkbox)
                throw new InvalidHtmlInputTypeException("The element is not a checkbox.");
        }

        /// <summary>
        /// Checked
        /// </summary>
        public bool IsChecked
        {
            get
            {
                string value = InnerWebElement.GetAttribute("checked");
                return (value.Equals("true", StringComparison.InvariantCultureIgnoreCase));
            }
            set
            {
                // Toggle the state of the checkbox by clicking it - but only if necessary.
                if (value == true && !InnerWebElement.Selected) InnerWebElement.Click();
                if (value == false && InnerWebElement.Selected) InnerWebElement.Click();
            }
        }


        /// <summary>
        /// Text of the checkbox
        /// </summary>
        public string Text
        {
            get { return InnerWebElement.Text; }
        }
    }
}
