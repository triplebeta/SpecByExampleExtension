using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SpecByExample.Common;

namespace SpecByExample.Common
{
    /// <summary>
    /// Extension methods to work with DataTable or DataRow
    /// </summary>
    public static class DataExtensions
    {
        /// <summary>
        /// Returns an instance of the given Control, by wrapping the IWebElement.
        /// </summary>
        /// <typeparam name="TControl">An instance to get back</typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public static TTypedDataRow As<TTypedDataRow>(this DataRow row) where TTypedDataRow : IBaseDataRow, new()
        {
            var control = new TTypedDataRow();
            control.Initialize(row);
            return control;
        }
    }
}
