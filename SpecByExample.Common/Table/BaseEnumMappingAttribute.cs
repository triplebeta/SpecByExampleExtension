using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.Common
{
    /// <summary>
    /// Base class for all ...ColumnMappingAttribute classes
    /// </summary>
    /// <remarks>
    /// Original code comes from: http://www.eggheadcafe.com/articles/20040221.asp
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public abstract class BaseEnumMappingAttribute : System.Attribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="enumValue">Enumerator item to use.</param>
        public BaseEnumMappingAttribute()
            : base()
        {
            // Nothing to do here
        }

        /// <summary>
        /// The enumerator value represented by this instance of the attribute.
        /// </summary>
        protected Enum StoredEnumValue
        {
            get;
            set;
        }

        /// <summary>
        /// Checks if name of the enumerator-item is equal to enumValueName
        /// </summary>
        /// <param name="enumValue">The name of an item of the enumerator.</param>
        /// <returns>True if equal.</returns>
        public bool IsEnumValue<TEnum>(TEnum enumValue)
        {
            TEnum key = (TEnum)Enum.Parse(typeof(TEnum), StoredEnumValue.ToString());
            return (key.Equals(enumValue));
        }




        /// <summary>
        /// Checks if name of the enumerator-item is equal to enumValueName
        /// </summary>
        /// <param name="enumStringValue">The name of an item of the enumerator.</param>
        /// <returns>True if equal.</returns>
        public bool IsEnumValueString(string enumStringValue)
        {
            return (StoredEnumValue.ToString().Equals(enumStringValue));
        }         
    }
}
