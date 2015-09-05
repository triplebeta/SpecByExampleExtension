using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.T4
{
    /// <summary>
    /// Options for the parser
    /// </summary>
    [Serializable]
    public class ParsingOptions
    {
        // TODO Add a ParsingOption to allow including the DIVs in the AllHtmlElements
        public ParsingOptions()
        {
            ExcludeNonUniqueControls = true;
        }

        public ControlIdentificationType[] PreferredIdentifications;

        /// <summary>
        /// When true, do not generate code for the items for which we cannot find a unique identifier
        /// </summary>
        public bool ExcludeNonUniqueControls { get; set; }
    }
}
