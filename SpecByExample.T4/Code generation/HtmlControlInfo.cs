using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace SpecByExample.T4
{
    /// <summary>
    /// Entity for collecting information about the controls in the webpage for which we will be generating a class.
    /// This will be used as a ViewModel.
    /// </summary>
    [Serializable]
    public sealed class HtmlControlInfo
    {
        private string _innerText = null;

        public HtmlControlInfo()
        {
            IdentifiedBy = ControlIdentificationType.None;
            SupportsCodeGeneration = true;
            ReasonNoCodeGeneration = ExclusionCodeGenerationReasons.None;
        }

        /// <summary>
        /// Defines if we can actually generate code for this item.
        /// Will be false if e.g. the control cannot be identified uniquely.
        /// If not, the ReasonNoCodeGeneration field describes why.
        /// </summary>
        [XmlIgnore]
        public bool SupportsCodeGeneration { get; set; }

        /// <summary>
        /// Flag to define if we need to generate code for this item.
        /// Can only be set to True if SupportsCodeGeneration is true.
        /// </summary>
        public bool GenerateCodeForThisItem
        {
            get; set;
        }

        /// <summary>
        /// Reason why it's excluded. Only used when GenerateCodeForThisItem is false. None otherwise.
        /// </summary>
        [XmlIgnore]
        public ExclusionCodeGenerationReasons ReasonNoCodeGeneration { get; private set; }


        /// <summary>
        /// The name assigned to this control (so it's NOT the html name attribute, that would be the HtmlName)
        /// </summary>
        public string UserDefinedName
        {
            get
            {
                // Find a default for the name of the control which might be customized lateron
                if (String.IsNullOrEmpty(InnerText) == false)
                    return HtmlLoader.NormalizeAsControlName(InnerText);
                else if (String.IsNullOrEmpty(HtmlTitle) == false)
                    return HtmlLoader.NormalizeAsControlName(HtmlTitle);
                else if (String.IsNullOrEmpty(HtmlId) == false)
                    return HtmlId;
                else if (String.IsNullOrEmpty(HtmlName) == false)
                    return HtmlName;
                else
                    return CodeControlType;
            }
        }

        /// <summary>
        /// Name to show to the user in the wizard.
        /// </summary>
        public string DisplayName
        {
            get
            {
                if (String.IsNullOrWhiteSpace(UserDefinedName) == false) return UserDefinedName;
                if (String.IsNullOrWhiteSpace(HtmlId) == false) return HtmlId;
                else if (String.IsNullOrWhiteSpace(HtmlName) == false) return HtmlName;
                else return HtmlXPath;
            }
        }


        #region Values read from the HTML

        /// <summary>
        /// ID of the control, used to identify the element.
        /// </summary>
        public string HtmlId { get; set; }

        /// <summary>
        /// Name attribute of the HTML element.
        /// </summary>
        public string HtmlName { get; set; }

        /// <summary>
        /// Title attribute from the HTML.
        /// </summary>
        public string HtmlTitle { get; set; }

        /// <summary>
        /// CSS class found on the control.
        /// </summary>
        public string HtmlCssClass { get; set; }
        
        // Make sure we save the elements only if they have a value
        public bool ShouldSerializeHtmlId() { return !String.IsNullOrWhiteSpace(HtmlId); }
        public bool ShouldSerializeHtmlName() { return !String.IsNullOrWhiteSpace(HtmlName); }
        public bool ShouldSerializeHtmlTitle() { return !String.IsNullOrWhiteSpace(HtmlTitle); }
        public bool ShouldSerializeHtmlCssClass() { return !String.IsNullOrWhiteSpace(HtmlCssClass); }

        #endregion


        #region Properties for code generation

        /// <summary>
        /// Defines how we will find this control in the HTML page
        /// </summary>
        public ControlIdentificationType IdentifiedBy
        {
            get; set;
        }


        /// <summary>
        /// Find the best way to identify this control in the page.
        /// </summary>
        /// <param name="allControls">List of existing controls.</param>
        /// <param name="preferredIdentificationMethods">Preferences for identifying controls.</param>
        internal void AssignIdentificationMethod(IQueryable<HtmlControlInfo> allControls, ControlIdentificationType[] preferredIdentificationMethods)
        {
            // Use only the preferred identification methods.
            // Since preferred order of use of the identification methods can be different per scenario, we need the loop to go over them.
            SupportsCodeGeneration = true; // Assume we can identify it
            foreach (var ident in preferredIdentificationMethods)
            {
                // Use the ID if no other control has that identifier
                if (ident==ControlIdentificationType.Id && String.IsNullOrEmpty(HtmlId) == false)
                {
                    if (allControls.Count(x => x.IdentifiedBy == ControlIdentificationType.Id && x.HtmlId == HtmlId)==0)
                        IdentifiedBy = ControlIdentificationType.Id;
                }

                if (ident == ControlIdentificationType.Name && String.IsNullOrEmpty(HtmlName) == false)
                {
                    if (allControls.Count(x => x.IdentifiedBy == ControlIdentificationType.Name && x.HtmlName == HtmlName) == 0)
                        IdentifiedBy = ControlIdentificationType.Name;
                }

                if (ident == ControlIdentificationType.LinkText && HtmlControlType == HtmlControlTypeEnum.Link && String.IsNullOrEmpty(InnerText) == false)
                {
                    if (allControls.Count(x => x.IdentifiedBy == ControlIdentificationType.LinkText && x.InnerText == InnerText) == 0)
                        IdentifiedBy = ControlIdentificationType.LinkText;
                }

                if (ident == ControlIdentificationType.Cssclass && String.IsNullOrEmpty(HtmlCssClass) == false)
                {
                    // Selenium cannot identify controls by CSS selectors they have a compound CSS expression (= multiple elements applied to it)
                    // So a control with class="blue fat" cannot be identified by its CSS expression since "blue fat" has more than one element.
                    if (HtmlCssClass.Contains(" "))
                        continue; // In that case, CSS is not usable as the identifier

                    if (allControls.Count(x => x.IdentifiedBy == ControlIdentificationType.Cssclass && x.HtmlCssClass == HtmlCssClass) == 0)
                        IdentifiedBy = ControlIdentificationType.Cssclass;
                }

                if (IdentifiedBy != ControlIdentificationType.None)
                {
                    Debug.WriteLine($"control {this.CodeControlName} will be identified by {this.IdentifiedBy}");
                    return;
                }
            }

            // If none of the clauses resulted in unique identification, it must be a duplicate identifier
            SupportsCodeGeneration = false;
            ReasonNoCodeGeneration = ExclusionCodeGenerationReasons.NoValidIdentifier;
        }

        /// <summary>
        /// XPath expression to address this item directly (will be unique for each control)
        /// </summary>
        public string HtmlXPath { get; set; }

        /// <summary>
        /// Content of the control.
        /// </summary>
        /// <remarks>InnerText property of the HTML element.</remarks>
        public string InnerText
        {
            get { return _innerText ?? ""; }
            set { _innerText = value; }
        }

        /// <summary>
        /// The the name for the control.
        /// </summary>
        /// <remarks>Based on the HtmlName, invalid characters will be removed from it.</remarks>
        private string codeControlName = null;
        public string CodeControlName
        {
            get
            {
                if (codeControlName == null)
                {
                    // Create the name for the field for this control in code, use the user-defined name for it
                    // Then add a suffix for the type of control
                    codeControlName = HtmlLoader.NormalizeAsControlName(UserDefinedName);

                    // Only append the type of control if it's not already in the name of the control
                    if (Regex.IsMatch(codeControlName, CodeControlType+"[0-9]*$",RegexOptions.IgnoreCase)==false)
                        codeControlName += CodeControlType;
                }
                return codeControlName;
            }
            // Allow to override the controlname. Used when same default name appears more than once. In that case we can add a number to make it unique.
            set { codeControlName = value; }
        }

        /// <summary>
        /// Name of the type of control in which the encapsulated HTML will be exposed.
        /// </summary>
        /// <example>Link</example>
        public string CodeControlType { get; set; }

        /// <summary>
        /// Type of HTML control
        /// </summary>
        public HtmlControlTypeEnum HtmlControlType { get; set; }

        #endregion
    }
}
