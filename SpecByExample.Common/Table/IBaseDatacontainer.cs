using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.Common
{
    /// <summary>
    /// Defines the capabilities of a data container.
    /// </summary>
    /// <typeparam name="TRowItem"></typeparam>
    public interface IBaseDatacontainer<TRowItem>
    {
        /// <summary>
        /// Creates a new instance of the appropriate BaseDataRow subclass for this container.
        /// </summary>
        /// <returns>An instance wrapping an empty datarow of the container.</returns>
        /// <remarks>
        /// The datarow is already added to the table.
        /// </remarks>
        TRowItem NewRowEntity();

        /// <summary>
        /// Adds the item to the container.
        /// </summary>
        void AddRowEntity(TRowItem entity);
    }
}
