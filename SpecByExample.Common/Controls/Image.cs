using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace SpecByExample.Common.Controls
{
    /// <summary>
    /// Adapter for Image elements in the HTML
    /// </summary>
    public class Image : BaseSeleniumControl
    {
        /// <summary>
        /// Extends the standard initializations by performing additional checks.
        /// </summary>
        /// <param name="innerElement">Element to be wrapped</param>
        /// <exception cref="HtmlElementIsNoInputElementException">Thrown if it's not an input control.</exception>
        public override void Initialize(IWebDriver driver, IWebElement innerElement)
        {
            base.Initialize(driver, innerElement);
            if (innerElement.TagName.Equals("img",StringComparison.InvariantCultureIgnoreCase)==false)
                throw new InvalidHtmlInputTypeException("The element is not an image.");
        }


        /// <summary>
        /// ImageUrl
        /// </summary>
        public virtual string ImageUrl
        {
            // Use the standard Selenium implementation to get the size of the control.
            get { return InnerWebElement.GetAttribute("src"); }
        }


        /// <summary>
        /// Size of this image.
        /// </summary>
        public virtual System.Drawing.Size Size
        {
            // Use the standard Selenium implementation to get the size of the control.
            get { return InnerWebElement.Size; }
        }
    }
}
