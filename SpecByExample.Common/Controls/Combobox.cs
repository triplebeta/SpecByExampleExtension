using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace SpecByExample.Common.Controls
{
    /// <summary>
    /// Adapter for Combobox controls on the page
    /// </summary>
    public class Combobox : BaseSeleniumControl
    {
        /// <summary>
        /// Extends the standard initializations by performing additional checks.
        /// </summary>
        /// <param name="innerElement"></param>
        /// <exception cref="HtmlElementIsNoInputElementException">Thrown if it's not an input control.</exception>
        public override void Initialize(IWebDriver driver, IWebElement innerElement)
        {
            base.Initialize(driver, innerElement);
            if (innerElement.TagName.Equals("select", StringComparison.InvariantCultureIgnoreCase) == false)
                throw new InvalidHtmlInputTypeException("The element is not a combobox.");
        }

        public void Select(string optionText)
        {
            // Find the option to work with
            //create select element object 
            var selectElement = new SelectElement(InnerWebElement);

            // select by text
            selectElement.SelectByText(optionText);
        }


        /// <summary>
        /// Get the selected item.
        /// </summary>
        public string CurrentSelectedItem
        {
            get
            {
                // Find the option to work with
                //create select element object 
                var selectElement = new SelectElement(InnerWebElement);
                return selectElement.SelectedOption.Text;
            }
        }
    }
}
