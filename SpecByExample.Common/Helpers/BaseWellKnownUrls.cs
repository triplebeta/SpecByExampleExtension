using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.Common
{
    /// <summary>
    /// Container for all well-known urls we can use to go to.
    /// </summary>
    /// <remarks>
    /// This partial class contains extra helper methods.
    /// </remarks>
    public class BaseWellKnownUrls
    {
        /// <summary>
        /// Create a customized version of an url by adding each parameter as a new part at the end of the url
        /// </summary>
        /// <param name="baseUrl">Standard url</param>
        /// <returns>Url composed of the base url with each parameter added as a part in the path.</returns>
        public static string GetCustomizedUrl(string baseUrl, params string[] extraParts)
        {
            StringBuilder sb = new StringBuilder(baseUrl);
            foreach (string part in extraParts)
                sb.AppendFormat("/{0}", part);
            return sb.ToString();
        }


        /// <summary>
        /// Create a customized version of an url by adding each option at the end of the url after a ?
        /// </summary>
        /// <param name="baseUrl">Standard url</param>
        /// <returns>Url composed of the base url with all options added to the url</returns>
        public static string GetCustomizedUrl(string baseUrl, Dictionary<string, object> options)
        {
            StringBuilder sb = new StringBuilder(baseUrl);
            var optionsList = options.Keys.ToList();
            for (int i = 0; i < options.Count; i++)
            {
                if (i == 0) sb.Append("?");
                if (i > 0) sb.Append(";");

                KeyValuePair<string, object> option = (KeyValuePair<string, object>)options[optionsList[i]];
                sb.AppendFormat("{0}={1}", option.Key, option.Value);
            }
            return sb.ToString();
        }
    }
}
