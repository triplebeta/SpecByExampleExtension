using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecByExample.T4
{
    /// <summary>
    /// All capabilities of the CodeGenerationSettings
    /// </summary>
    public interface ICodeGenerationSettings
    {
        string PageName { get; set; }
        string PageTitle { get; set; }
        string Url { get; set; }
        string HtmlRootNodeXPath { get; set; }

        bool CreateSpecFlowStepsFile { get; set; }
        bool CreateSpecFlowFeatureFile { get; set; }


        string ClassName { get; set; }

        /// <summary>
        /// List of the controls
        /// </summary>
        IEnumerable<HtmlControlViewModel> HtmlControls { get; }
    }
}
