using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.Common
{
    /// <summary>
    /// Defines the responsibilities of a Table Mapping Definition class
    /// which is used to convert between HTML names and enumerator items.
    /// </summary>
    public interface ITableMappingDefinition<TTableEnum>
    {
        /// <summary>
        /// Provides the mapping between the HTML names and the column enumerator items for a specific enum.
        /// </summary>
        Dictionary<TTableEnum, string> HtmlColumnNames
        {
            get;
        }


        /// <summary>
        /// Returns a dictionary which defines how each enumerator item maps to the database
        /// </summary>
        /// <returns>The mapping table.</returns>
        Dictionary<TEnum, string> GetHtmlColumnMapping<TEnum>(string tableName);
    }
}

