﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.T4
{
    /// <summary>
    /// Entity for collecting information about the controls in the webpage for which we will be generating a class.
    /// This will be used as a ViewModel.
    /// </summary>
    [Serializable]
    public sealed class HtmlControlInfo
    {
        private bool _generateCodeForThisItem = false;

        public HtmlControlInfo()
        {
            IdentifiedBy = ControlIdentificationType.None;
            SupportsCodeGeneration = false;   // Assume worst case
            ReasonNoCodeGeneration = ExclusionCodeGenerationReasons.None;
        }

        /// <summary>
        /// Defines if we can actually generate code for this item.
        /// Will be false if e.g. the control cannot be identified uniquely.
        /// If not, the ReasonNoCodeGeneration field describes why.
        /// </summary>
        public bool SupportsCodeGeneration { get; private set; }

        /// <summary>
        /// Flag to define if we need to generate code for this item.
        /// Can only be set to True if SupportsCodeGeneration is true.
        /// </summary>
        public bool GenerateCodeForThisItem
        {
            get { return _generateCodeForThisItem; }
            set
            {
                // Do not allow setting to true if SupportsCodeGeneration is false
                if (!value || SupportsCodeGeneration)
                    _generateCodeForThisItem = value;
            }
        }

        /// <summary>
        /// Reason why it's excluded. Only used when GenerateCodeForThisItem is false. None otherwise.
        /// </summary>
        public ExclusionCodeGenerationReasons ReasonNoCodeGeneration { get; private set; }


        /// <summary>
        /// The name assigned to this control (so it's NOT the html name attribute, that would be the HtmlName)
        /// </summary>
        public string UserDefinedName
        {
            get
            {
                // Find a default for the name of the control which might be customized lateron
                if (String.IsNullOrEmpty(Description) == false)
                    return HtmlLoader.NormalizeAsControlName(Description);
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
        
        #endregion


        #region Properties for code generation

        /// <summary>
        /// Defines how we will find this control in the HTML page
        /// </summary>
        public ControlIdentificationType IdentifiedBy
        {
            get; private set;
        }


        /// <summary>
        /// Find the best way to identify this control in the page.
        /// </summary>
        /// <param name="allControls">List of existing controls.</param>
        /// <param name="preferredIdentificationMethods">Preferences for identifying controls.</param>
        internal void AssignIdentificationMethod(IQueryable<HtmlControlInfo> allControls, ControlIdentificationType[] preferredIdentificationMethods)
        {
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

                if (ident == ControlIdentificationType.LinkText && HtmlControlType == HtmlControlTypeEnum.Link && String.IsNullOrEmpty(Description) == false)
                {
                    if (allControls.Count(x => x.IdentifiedBy == ControlIdentificationType.Name && x.Description == Description) == 0)
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
                    SupportsCodeGeneration = true;
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
        /// The control.
        /// </summary>
        /// <remarks>Based on the HtmlName, invalid characters will be removed from it.</remarks>
        public string Description { get; set; }

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
                    codeControlName = CreateCodeControlName();
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


        #region Private support code

        /// <summary>
        /// Create a valid identifier to create a field in the class.
        /// </summary>
        private string CreateCodeControlName()
        {
            // Create the name for the field for this control in code, use the user-defined name for it
            // Then add a suffix for the type of control
            string name = UserDefinedName;
            if (String.IsNullOrEmpty(name) == false)
            {
                name = HtmlName;
                if (String.IsNullOrEmpty(name) == false) name = HtmlId;
                if (String.IsNullOrEmpty(name))
                {
                    // Just return a time
                }
            }

            string controlNamePart = HtmlLoader.NormalizeAsControlName(UserDefinedName);
            if (CodeControlType.ToUpper() == "WEBTABLE")
                return controlNamePart + "Table";
            else
                return controlNamePart + CodeControlType;
        }

        #endregion
    }
}
