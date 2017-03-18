using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.Common
{
    /// <summary>
    /// Extention methods for the Container
    /// </summary>
    public static class ContainerExtensionMethods
    {
        /// <summary>
        /// Extension method to add a new item to the list.
        /// </summary>
        /// <param name="list">The list to work on.</param>
        /// <typeparam name="TEnum">Type of the enumerator.</typeparam>
        /// <param name="key">Enumerator item to work with.</param>
        /// <param name="value">Value to assign to it.</param>
        public static void AddItem<TEnum>(this List<KeyValuePair<TEnum, string>> list, TEnum key, string value)
        {
            list.Add(new KeyValuePair<TEnum, string>(key, value));
        }

        /// <summary>
        /// Extension method to check if a key appears in a list.
        /// </summary>
        /// <param name="list">The list to work on.</param>
        /// <typeparam name="TEnum">Type of the enumerator.</typeparam>
        /// <param name="key">Enumerator item to work with.</param>
        public static bool ContainsKey<TEnum>(this List<KeyValuePair<TEnum, string>> list, TEnum key)
        {
            return (list.Where(x => x.Key.Equals(key)).Count() > 0);
        }
    }
}
