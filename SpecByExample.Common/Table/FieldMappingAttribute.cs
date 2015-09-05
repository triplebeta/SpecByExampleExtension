using System;
using System.Reflection;
using System.Diagnostics;  
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace SpecByExample.Common
{
    /// <summary>
    /// Attribute to map fields of a DataRow to a field of a class.
    /// </summary>
    /// <remarks>
    /// Original code comes from: http://www.eggheadcafe.com/articles/20040221.asp
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class FieldMappingAttribute : System.Attribute
    {        /// <summary>
        /// Constructor.
        /// </summary>
        public FieldMappingAttribute()
        {
            this.ColumnName = null;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dataTableColumnname">Optional: name of the column in the dataset. If not set, the fieldname will be used instead.</param>
        public FieldMappingAttribute(string dataTableColumnname)
        {
            this.ColumnName = dataTableColumnname;
        }
        

        /// <summary>
        /// Name of the column in the dataset.
        /// </summary>
        public string ColumnName
        {
            get;
            set;
        }
    }
}
