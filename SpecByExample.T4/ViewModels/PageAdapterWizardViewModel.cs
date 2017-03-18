using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SpecByExample.T4
{
    /// <summary>
    /// Container for the settings to be entered in the form.
    /// </summary>
    /// <remarks>This will be saved as a .webmodel file, capturing the characteristics of the page.</remarks>
    [Serializable]
    public class PageAdapterWizardViewModel : MarshalByRefObject
    {
        public PageAdapterWizardViewModel()
        {
            Options = new ParsingOptions();
            Options.ExcludeNonUniqueControls = true;
            Options.PreferredIdentifications = new ControlIdentificationType[] {
                ControlIdentificationType.Id, 
                ControlIdentificationType.Name,
                ControlIdentificationType.LinkText,
                ControlIdentificationType.Cssclass };
            PageInfo = new PageInfo();

            CreateSpecFlowFeatureFile = false;            
            IsCancelled = false;
        }

        [XmlElement]
        public PageInfo PageInfo { get; set; }

        /// <summary>
        /// Define how to parse the HTML
        /// </summary>
        [XmlElement]
        public ParsingOptions Options { get; set; }

        
        /// <summary>
        /// True to create a new SpecFlow Feature file.
        /// </summary>
        /// <remarks>
        /// Used only for the wizard since the custom tool will not update the Feature file.
        /// </remarks>
        [XmlIgnore]
        public bool CreateSpecFlowFeatureFile { get; set; }

        /// <summary>
        /// For internal use by the Wizard to indicate that it was closed without the use of the Finish button.
        /// </summary>
        [XmlIgnore]
        public bool IsCancelled { get; set; }
    }
}
