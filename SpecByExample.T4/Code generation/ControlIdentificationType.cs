using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.T4
{
    /// <summary>
    /// Defines the ways we can identify a control.
    /// </summary>
    public enum ControlIdentificationType
    {
        None,           // Default option
        Id,             // Find the item by its ID
        Name,           // Find the item by its name
        Cssclass        // Find the item by its CSS class
    }
}
