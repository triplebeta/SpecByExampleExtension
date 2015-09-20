using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.T4
{
    /// <summary>
    /// Defines reasons why an element was excludes from code generation.
    /// </summary>
    public enum ExclusionCodeGenerationReasons
    {
        // None of the requested identifiers was found for this node
        NoValidIdentifier,
        None
    }
}
