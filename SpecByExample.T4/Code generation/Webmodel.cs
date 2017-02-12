using SpecByExample.T4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecByExample.WebmodelEditor
{
    /// <summary>
    /// Model for the editor to work on. This is a representation of a .webmodel file in code.
    /// Since the model is serialized as a CodeGenerationSettings class, we just inherit from it.
    /// Over time it should evolve into a cleaner separation between the code generation and the model.
    /// </summary>
    [Serializable]
    public class Webmodel : CodeGenerationSettings
    {
        // Model to capture the content of the .webmodel XML files
        
    }
}
