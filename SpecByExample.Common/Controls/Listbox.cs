using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace SpecByExample.Common.Controls
{
    /// <summary>
    /// Adapter for Listbox controls on the page
    /// </summary>
    public class Listbox : BaseSeleniumControl
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
                throw new InvalidHtmlInputTypeException("The element is not a listbox.");
        }


        /// <summary>
        /// Deselect all items.
        /// </summary>
        public void Clear()
        {
            var selectElement = new SelectElement(InnerWebElement);
            selectElement.DeselectAll();
        }


        /// <summary>
        /// Deselect one item.
        /// </summary>
        public void Deselect(string item)
        {
            var selectElement = new SelectElement(InnerWebElement);
            selectElement.DeselectByText(item);
        }


        /// <summary>
        /// Select one or more items in the list.
        /// Extends an existing selection, already selected items will remain selected.
        /// </summary>
        /// <param name="items">All items to select.</param>
        public void Select(string[] items)
        {
            var selectElement = new SelectElement(InnerWebElement);

            // select by text
            foreach(var item in items)
                selectElement.SelectByText(item);
        }


        /// <summary>
        /// Get the selected items.
        /// </summary>
        public IWebElement[] SelectedItems
        {
            get
            {
                var selectElement = new SelectElement(InnerWebElement);
                if (selectElement.IsMultiple)
                {
                    return selectElement.AllSelectedOptions.ToArray();
                }
                else
                    return new IWebElement[] { selectElement.SelectedOption };
            }
        }
    }
}
