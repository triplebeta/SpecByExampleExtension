using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.Common
{
    /// <summary>
    /// Supported types of browsers
    /// </summary>
    public enum SeleniumBrowerType
    {
        InternetExplorer,
        Firefox,
        Chrome
    }


    /// <summary>
    /// Defines all types of INPUT elements recognised.
    /// </summary>
    public enum HtmlInputType
    {
        Link,
        Button,
        Label,
        Textbox,
        Checkbox,
        Textarea,
        Combobox,
        Table,
        TableRow,
        TableCell,
    }
}
