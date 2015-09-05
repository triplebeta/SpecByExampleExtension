using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace SpecByExample.Common.Controls
{
    /// <summary>
    /// Baseclass for all Selenium controls
    /// A control is an adapter for an element in the webpage, like a Page Object.
    /// </summary>
    public abstract class BaseSeleniumControl
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public BaseSeleniumControl()
        {
            // A parameterless constructor is required in order to use this class in an extension method with a new() clause
            // Therefore we can also initialize this control using the Initialize method.
        }

        /// <summary>
        /// Constructor to use when directly instantiating this control.
        /// </summary>
        /// <param name="innerElement"></param>
        public BaseSeleniumControl(IWebDriver driver, IWebElement innerElement)
        {
            if (driver == null) throw new ArgumentNullException("driver");
            if (innerElement == null) throw new ArgumentNullException("innerElement");

            Initialize(driver, innerElement);
        }

        /// <summary>
        /// Use this to initialize the elements and sets the InnerWebElement and InputType property.
        /// </summary>
        /// <param name="innerElement"></param>
        public virtual void Initialize(IWebDriver driver, IWebElement innerElement)
        {
            CurrentWebDriver = driver;
            InnerWebElement = innerElement;
            InputType = DetectInputType(InnerWebElement);
        }

        /// <summary>
        /// True if the control is enabled
        /// </summary>
        public virtual bool IsEnabled
        {
            // Use the standard Selenium implementation to check for being enabled.
            get { return InnerWebElement.Enabled; }
        }

        /// <summary>
        /// True if the control is displayed
        /// </summary>
        public virtual bool IsDisplayed
        {
            // Use the standard Selenium implementation to check for being displayed.
            get { return InnerWebElement.Displayed; }
        }

        /// <summary>
        /// Send a combination of keys to this control.
        /// </summary>
        /// <remarks>
        /// Use the OpenQA.Selenium.Keys to define special keystrokes.
        /// </remarks>
        public virtual void SendKeys(string keys)
        {
            // Use the standard Selenium implementation to check for being displayed.
            InnerWebElement.SendKeys(keys);
        }


        #region Protected items

        /// <summary>
        /// Element being wrapped
        /// </summary>
        protected IWebElement InnerWebElement
        {
            get;
            private set;
        }

        /// <summary>
        /// The web driver
        /// </summary>
        protected IWebDriver CurrentWebDriver
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns the type of INPUT control of InnerWebElement
        /// </summary>
        protected HtmlInputType InputType
        {
            get;
            set;
        }


        /// <summary>
        /// Provides access to some utility methods
        /// </summary>
        protected IJavaScriptExecutor ScriptExecutor
        {
            get { return ((IJavaScriptExecutor)CurrentWebDriver); }
        }


        /// <summary>
        /// Extract the JavaScript code from the specified event of this control and run it async.
        /// </summary>
        /// <param name="eventName">Name of the event from which to get the JavaScript code.</param>
        protected void ExecuteJavascriptCodeFromEvent(string eventName)
        {
            // Click the link and make sure to do it thre right way:
            // - when it has an onclick attribute: run it
            // - otherwise: just invoke its Submit
            var script = InnerWebElement.GetAttribute(eventName);

            // Perform the actual clicking on the button
            if (String.IsNullOrEmpty(script) == false)
            {
                if (script.EndsWith(";") == false)
                    script += ";";

                // Remove an options Javascript: prefix
                Regex re = new Regex("^javascript:(.*)$");
                if (re.IsMatch(script))
                {
                    var m = re.Match(script);
                    script = m.Groups[1].Captures[0].Value;
                }

                string wrapper = String.Format("setTimeout(function() {{{0}}},0);", script);
                ScriptExecutor.ExecuteScript(wrapper);
            }
        }

        #endregion


        #region Private support code

        /// <summary>
        /// Find out what type of inputcontrol we are handling here.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        virtual protected HtmlInputType DetectInputType(IWebElement element)
        {
            if (InnerWebElement.TagName == null) throw new InvalidOperationException("Tagname is required when detecting the type of input element.");

            // Buttons will be detected by their tagname
            switch (InnerWebElement.TagName.ToUpper())
            {
                case "SELECT": return HtmlInputType.Combobox;
                case "BUTTON": return HtmlInputType.Button;
                case "A": return HtmlInputType.Link;
                case "DIV": return HtmlInputType.Label;
                case "SPAN": return HtmlInputType.Label;
                case "TR": return HtmlInputType.TableRow;
                case "TABLE": return HtmlInputType.Table;
            }
                
/*
            // Combobox will be detected by their tagname
            if (InnerWebElement.TagName.Equals("select", StringComparison.InvariantCultureIgnoreCase))
                return HtmlInputType.Combobox;

            // Combobox will be detected by their tagname
            if (InnerWebElement.TagName.Equals("a", StringComparison.InvariantCultureIgnoreCase))
                return HtmlInputType.Link;

            // Labels will be used for Div or Span
            if (InnerWebElement.TagName.Equals("div", StringComparison.InvariantCultureIgnoreCase) ||
                InnerWebElement.TagName.Equals("span", StringComparison.InvariantCultureIgnoreCase))
                return HtmlInputType.Label;

            // Combobox will be detected by their tagname
            if (InnerWebElement.TagName.Equals("table", StringComparison.InvariantCultureIgnoreCase))
                return HtmlInputType.Table;

            // Combobox will be detected by their tagname
            if (InnerWebElement.TagName.Equals("tr", StringComparison.InvariantCultureIgnoreCase))
                return HtmlInputType.TableRow;
*/

            // For other controls, use the input tag
            if (InnerWebElement.TagName.Equals("input", StringComparison.InvariantCultureIgnoreCase))
            {
                string typeAttribute = (InnerWebElement.GetAttribute("type") ?? "").ToUpperInvariant();
                if (String.IsNullOrWhiteSpace(typeAttribute))
                    throw new HtmlElementIsNoInputElementException();
                else
                {
                    switch (typeAttribute)
                    {
                        case "BUTTON": return HtmlInputType.Button;
                        case "CHECKBOX": return HtmlInputType.Checkbox;
                        case "TEXTBOX": return HtmlInputType.Textbox;
                        case "TEXTAREA": return HtmlInputType.Textarea;
                    }
                }
            }

            // By default: throw an error
            throw new InvalidHtmlInputTypeException("Input control is not recognized as a proper control");
        }
        #endregion
    }
}
