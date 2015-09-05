using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using SpecByExample.Common.Controls;

namespace SpecByExample.Common.Controls
{
    /// <summary>
    /// Adapter for Input elements of type Text
    /// </summary>
    public sealed class Textbox : BaseSeleniumControl
    {
        /// <summary>
        /// Extends the standard initializations by performing additional checks.
        /// </summary>
        /// <param name="innerElement">Element to be wrapped</param>
        /// <exception cref="HtmlElementIsNoInputElementException">Thrown if it's not an input control.</exception>
        public override void Initialize(IWebDriver driver, IWebElement innerElement)
        {
            base.Initialize(driver, innerElement);
            if (this.InputType != HtmlInputType.Textbox)
                throw new InvalidHtmlInputTypeException("The element is not a textbox.");
        }

        public void Clear()
        {
            InnerWebElement.Clear();
        }

        public string Text
        {
            get { return InnerWebElement.Text; }
            set { InnerWebElement.SendKeys(value); }
        }
    }
}
