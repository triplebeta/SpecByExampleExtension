using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SpecByExample.Common
{
    /// <summary>
    /// Defines the responsibilities of a BaseDataRow.
    /// </summary>
    public interface IBaseDataRow
    {
        /// <summary>
        /// Initializes the row by using a data row.
        /// </summary>
        /// <param name="row"></param>
        void Initialize(DataRow row);

        /// <summary>
        /// Exposes the data row wrapped by this entity.
        /// </summary>
        DataRow CurrentRow { get; }

        /// <summary>
        /// Gets the type of the field marked with the given enumerator item.
        /// </summary>
        /// <typeparam name="TEnumType">Type of enumerator.</typeparam>
        /// <param name="enumItem">Item of the enumerator TEnumType.</param>
        /// <returns>Type of the field.</returns>
        Type GetFieldType<TEnumType>(TEnumType enumItem);

        /// <summary>
        /// Assigns a value to the field that has the given enumerator assigned to it.
        /// </summary>
        /// <typeparam name="TEnumType">Type of enumerator.</typeparam>
        /// <param name="enumItem">Item of the enumerator TEnumType.</param>
        /// <param name="value">Value to assign to it.</param>
        void SetValue<TEnumType>(TEnumType enumItem, object value);
    }
}
