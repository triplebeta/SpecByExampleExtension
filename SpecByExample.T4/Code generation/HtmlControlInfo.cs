using System;
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
        public HtmlControlInfo()
        {
            IdentifiedBy = ControlIdentificationType.None;
            GenerateCodeForThisItem = true;
            ReasonForExclusion = ExclusionReasonType.None;
        }

        /// <summary>
        /// Flag to define if we need to generate code for this item
        /// </summary>
        public bool GenerateCodeForThisItem { get; set; }

        /// <summary>
        /// Reason why it's excluded. Only used when GenerateCodeForThisItem is false. None otherwise.
        /// </summary>
        public ExclusionReasonType ReasonForExclusion { get; set; }


        /// <summary>
        /// The name assigned to this control (so it's NOT the html name attribute, that would be the HtmlName)
        /// </summary>
        public string UserDefinedName { get; set; }

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
        public ControlIdentificationType IdentifiedBy;

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
