using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace SpecByExample.Common.Controls
{
    /// <summary>
    /// Adapter for Label elements in the HTML
    /// </summary>
    public class Label : BaseSeleniumControl
    {
        /// <summary>
        /// Text of this control
        /// </summary>
        public string Text
        {
            get { return InnerWebElement.Text; }
        }


        /// <summary>
        /// Compare the content to a specific value
        /// </summary>
        /// <param name="value">Value to be matched</param>
        /// <returns>True if the values are equal.</returns>
        public bool ValueIs(float value)
        {
            // Compare them as Text to prevent rounding issues such as when comparing 7.0000000001 to 7
            // Both values will be displayed as 7 so we would expect them to be equal when the text equals the given value
            return Text.Equals(value.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }


        /// <summary>
        /// Compare the content to a specific value
        /// </summary>
        /// <param name="value">Value to be matched</param>
        /// <returns>True if the values are equal.</returns>
        public bool ValueIs(int value)
        {
            // Compare them as Text to prevent rounding issues such as when comparing 7.0000000001 to 7
            // Both values will be displayed as 7 so we would expect them to be equal when the text equals the given value
            return Text.Equals(value.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }


        /// <summary>
        /// Compare the content to a specific date/time (using the given format)
        /// </summary>
        /// <param name="dateTime">Value to be matched</param>
        /// <param name="format">Format of the date</param>
        /// <returns>True if the values are equal.</returns>
        public bool ValueIs(DateTime dateTime, string format)
        {
            // Compare them as Text to prevent rounding issues such as when comparing 7.0000000001 to 7
            // Both values will be displayed as 7 so we would expect them to be equal when the text equals the given value
            return Text.Equals(dateTime.ToString(format), StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
