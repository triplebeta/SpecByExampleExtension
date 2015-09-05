using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.T4
{
    /// <summary>
    /// Defines reasons why an element was excludes from code generation.
    /// </summary>
    public enum ExclusionReasonType
    {
        // One of the requested identifiers was found but its value also appears with another node,
        // so we cannot reliably identify this node by using it.
        DuplicateIdentifier,

        // None of the requested identifiers was found for this node
        NoValidIdentifier,
        None
    }
}
