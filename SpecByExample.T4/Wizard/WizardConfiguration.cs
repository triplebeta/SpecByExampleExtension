using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SpecByExample.T4
{
    /// <summary>
    /// Configuration of the wizard.
    /// </summary>
    [Serializable, XmlRoot("wizardConfig")]
    public class WizardConfiguration
    {
        [XmlArray("controlTypes"), XmlArrayItem("register")]
        public List<ControlTypeRegistration> RegisteredControlTypes { get; set; }

        /// <summary>
        /// Check the configuration.
        /// </summary>
        /// <param name="errors">List of all errors found during validation.</param>
        /// <returns>True if successfull.</returns>
        public bool ValidateConfiguration(out List<string> errors)
        {
            errors = new List<string>();
            foreach (var ctrl in RegisteredControlTypes)
            {
                // Check required fields
                if (String.IsNullOrWhiteSpace(ctrl.TypeName))
                    errors.Add(String.Format("Control type with an empty typename is not supported."));
                else
                {
                    // Check that the controls can be found in the namespaces

                }

                // Check required fields
                if (String.IsNullOrWhiteSpace(ctrl.XPath))
                    errors.Add(String.Format("Control type {0} has an empty XPath expression which is not supported.", ctrl.TypeName));

                // Check that the controls have a valid HtmlControlType (being not HtmlControlType.None)
                if (ctrl.HtmlControlType == HtmlControlTypeEnum.None)
                    errors.Add(String.Format("Control type {0} does not have a valid value for BasedOn: {1} is not supported.", ctrl.TypeName, ctrl.BasedOn));
            }

            return (errors.Count==0);
        }
    }


    /// <summary>
    /// Entity with the details of one registered control.
    /// This defines a mapping for an HTML tag to the class that implements an adapter for it.
    /// </summary>
    /// <example>
    /// The &lt;table&gt;&lt;/table&gt; tag can be mapped to the class SpecByExample.Common.Controls.WebTable
    /// As a result, if you then create a PageObject for a page that contains a table, the PageObject will get a property of the type WebTable
    /// providing access to that underlying html table. 
    /// </example>
    [Serializable]
    public class ControlTypeRegistration
    {
        /// <summary>
        /// Parameterless constructor is required
        /// </summary>
        public ControlTypeRegistration() { }

        /// <summary>
        /// Constructor
        /// </summary>
        public ControlTypeRegistration(string typeName, string basedOn, string xpath, string suffix = null)
        {
            TypeName = typeName;
            BasedOn = basedOn;
            XPath = xpath;
            Suffix = suffix;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ControlTypeRegistration(Type controlType, HtmlControlTypeEnum type, string xpath, string suffix = null)
        {
            TypeName = controlType.Name;
            BasedOn = type.ToString();
            XPath = xpath;
            Suffix = suffix;
        }

        /// <summary>
        /// String representation of the type of control.
        /// </summary>
        [XmlAttribute("type")]
        public string TypeName { get; set; }

        /// <summary>
        /// Represents the underlying type of HTML control.
        /// Must be an element of the HtmlControlTypes enum.
        /// </summary>
        [XmlAttribute("basedOn")]
        public string BasedOn { get; set; }

        /// <summary>
        /// XPath query to identify the elements to use.
        /// </summary>
        [XmlAttribute("xPath")]
        public string XPath { get; set; }

        /// <summary>
        /// Suffix to apply to the fields created for this type of control
        /// When null, the TypeName will be used instead
        /// </summary>
        [XmlAttribute("suffix")]
        public string Suffix { get; set; }


        /// <summary>
        /// Suffix to append to the fieldname.
        /// </summary>
        public string FieldSuffix
        {
            get { return String.IsNullOrEmpty(Suffix) ? TypeName : Suffix; }
        }


        /// <summary>
        /// Type of HTML control expected by this control (IWebElement implementation)
        /// </summary>
        public HtmlControlTypeEnum HtmlControlType
        {
            get
            {
                // Convert the BaseOn value to an element of the enumerator.
                // If it fails: return the None item.
                HtmlControlTypeEnum enumItem;
                if (Enum.TryParse<HtmlControlTypeEnum>(BasedOn, out enumItem))
                    return enumItem;
                else
                    return HtmlControlTypeEnum.None;
            }
        }
    }
}
