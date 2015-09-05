using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.Common
{
    /// <summary>
    /// Shared parts of the definition:
    /// contains the conversion table for all parts of the definition that are common.
    /// </summary>
    public abstract class BaseTableMappingDefinition<TTableEnum> : ITableMappingDefinition<TTableEnum>
    {
        /// <summary>
        /// Provides the mapping between the HTML names and the column enumerator items for an HTML table-row.
        /// </summary>
        public abstract Dictionary<TTableEnum, string> HtmlColumnNames
        {
            get;
        }

        /// <summary>
        /// Returns a dictionary which defines how each enumerator item maps to the database
        /// </summary>
        /// <returns>The mapping table.</returns>
        public virtual Dictionary<TEnum, string> GetHtmlColumnMapping<TEnum>(string tableName)
        {
            string msg = "Table Mapping Definition {0} does not implement a column mapping for enumerator {1} and table {2}.";
            throw new NotSupportedException(String.Format(msg, this.GetType().Name, typeof(TEnum).Name, tableName));
        }
    }
}

