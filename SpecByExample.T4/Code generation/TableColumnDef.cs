using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.T4
{
    /// <summary>
    /// Defines the properties of a column of a table so we can use them to generate code for it.
    /// </summary>
    [Serializable]
    public class TableColumnDef
    {
        public TableColumnDef(int position, string title, string fieldname, string datatype)
        {
            ColumnPosition = position;
            ColumnTitle = title;
            CodeFieldname = fieldname;
            Datatype = datatype;
        }

//        public bool IncludeField;           // true to generate code for it
        public int ColumnPosition { get; set; }
        public string ColumnTitle { get; set; }

        /// <summary>
        /// String representation of the Enum item for this column.
        /// Does not include the name of the Enum itself, just the name of the item.
        /// </summary>
        public string CodeEnumItem
        {
            get
            {
                // Compose the name using the CodeFieldname
                return EnsureFirstIsCapital(CodeFieldname);
            }
        }
        
        /// <summary>
        /// Fieldname for this column to use in code (normalized to remove invalid characters)
        /// </summary>
        private string codeFieldname;
        public string CodeFieldname
        {
            get { return codeFieldname; }
            set
            {
                // TODO Check for duplicate identifiers and correct for it. Move this to the caller
                string identifier = CleanName(value);
                codeFieldname = identifier;
            }
        }

        /// <summary>
        /// Datatype for this column
        /// </summary>
        public string Datatype { get; set; }

        /// <summary>
        /// Datatype for this column
        /// </summary>
        public string CodeFieldDatatype
        {
            get
            {
                // Return the typename to use in code
                switch(Datatype.ToUpper())
                {
                    case "STRING": return "string";
                    case "DATETIME": return "DateTime";
                    case "INTEGER": return "int";
                    case "URL": return "string";
                    case "FLOAT": return "float";
                    case "DOUBLE": return "double";
                    case "BOOLEAN": return "bool";
                    default: throw new InvalidOperationException("Datatype cannot be converted to valid C# datatype.");
                }
            }
        }


        /// <summary>
        /// Return the string ensuring the first character is a capital. If not yet it will make it a capital.
        /// </summary>
        /// <param name="input">Text to transform.</param>
        /// <returns>First character is a capital</returns>
        private static string EnsureFirstIsCapital(string input)
        {
            if (String.IsNullOrEmpty(input) || Char.IsUpper(input, 0))
                return input;
            else
                return Char.ToUpper(input[0]) + input.Substring(1);
        }


        /// <summary>
        /// Compose an identifier to use in code
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string CleanName(string name)
        {
            // Compliant with item 2.4.2 of the C# specification
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Nl}\p{Mn}\p{Mc}\p{Cf}\p{Pc}\p{Lm}]");
            string ret = regex.Replace(name, "");

            // The identifier must start with a character or a "_"
            if (!char.IsLetter(ret, 0) || !Microsoft.CSharp.CSharpCodeProvider.CreateProvider("C#").IsValidIdentifier(ret))
                    ret = string.Concat("_", ret);
            return ret;
        }
    }
}
