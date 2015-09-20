using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;

namespace SpecByExample.T4
{
    public static class HtmlLoader
    {
        static HtmlLoader()
        {
            DefaultOptions = new SpecByExample.T4.ParsingOptions();
            DefaultOptions.PreferredIdentifications = new ControlIdentificationType[] {
                    ControlIdentificationType.Id, 
                    ControlIdentificationType.Name,
                    ControlIdentificationType.LinkText,
                    ControlIdentificationType.Cssclass };
        }

        /// <summary>
        /// Load a document from a string of HTML
        /// </summary>
        /// <param name="html">Full HTML of a document</param>
        /// <returns>An HtmlDocument wrapping the given HTML.</returns>
        public static HtmlDocument LoadDocumentFromHtml(string html)
        {
            var document = new HtmlAgilityPack.HtmlDocument();

            // Load a file from HTML text
            using (StringReader sr = new StringReader(html))
            {
                document.Load(sr);
                return document;
            }
        }


        /// <summary>
        /// Load a document from an url or a file
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static HtmlDocument LoadDocumentFromUrl(string url)
        {
            var document = new HtmlAgilityPack.HtmlDocument();

            // Load a file from disk or from an url
            if (System.IO.File.Exists(url))
                document.Load(url);
            else
            {
                // Attempt to load it from the web
                bool canBeLoaded; // = false;
                try
                {
                    using (var response = CreateRequest(url).GetResponse())
                    {
                        canBeLoaded = true;
                    }
                }
                catch (Exception)
                {
                    // Return an error
                    return null;
                }

	            // Use the WebBrowser control to load the page and render it, this ensures all JavaScript will be executed as well.
                // Then feed the HTML to the HtmlAgilityPack document.
                var webbrowser = new System.Windows.Forms.WebBrowser();
                webbrowser.Navigate(new Uri(url));
                while (webbrowser.ReadyState != System.Windows.Forms.WebBrowserReadyState.Complete)
                {
                    // Dirty but the most easy way to wait for it synchroneously
                    System.Threading.Thread.Sleep(100);
                    System.Windows.Forms.Application.DoEvents();
                }

                // At this point, the HTML is loaded completely
                string html = webbrowser.DocumentText;
                document = HtmlLoader.LoadDocumentFromHtml(html);
            }

            return document;
        }


        /// <summary>
        /// Default options to apply when parsing the HTML.
        /// </summary>
        public static ParsingOptions DefaultOptions
        {
            get;
            set;
        }


        /// <summary>
        /// Extract info from the document.
        /// </summary>
        /// <param name="doc">Html document to parse</param>
        /// <param name="registeredControls">List of all registered controls</param>
        /// <param name="returnExcludedItems">When true, the result will also include the items that were EXCLUDED by the call to ExcludeItems. Default=false, do not return any excluded items</param>
        /// <param name="options">Defines how to parse</param>
        /// <param name="rootXPath">XPath expression to define the element that's the scope for finding the HTML controls. Only search of items within that container.</param>
        /// <returns>A list of entities with info about the controls.</returns>
        public static List<HtmlControlInfo> GetHtmlControls(HtmlDocument doc, IEnumerable<ControlTypeRegistration> registeredControls, ParsingOptions options, string rootXPath = null)
        {
            HtmlNode rootNode = doc.DocumentNode;

            // Process all XPath expressions for the registered controls.
            // This will result in a list of controls to be used.
            var controls = new List<HtmlControlInfo>();
            foreach (var ctrl in registeredControls)
            {
                controls.AddRange(FindControls(rootNode, ctrl.XPath, ctrl.FieldSuffix, ctrl.HtmlControlType, options));
            }

            // Filter the list by the XPath expression
            if (String.IsNullOrEmpty(rootXPath)==false)
            {
                for (int i = controls.Count - 1; i >= 0; i--)
                    if (controls[i].HtmlXPath.StartsWith(rootXPath) == false)
                        controls.RemoveAt(i);
            }
            return controls;
        }

        /// <summary>
        /// Get details about the page itself.
        /// </summary>
        /// <param name="doc">HTML document</param>
        /// <returns>Info from the page.</returns>
        public static PageInfo GetPageInfo(HtmlDocument doc)
        {
            PageInfo info = new PageInfo();

            var titleNode = doc.DocumentNode.SelectSingleNode("//head/title");
            if (titleNode != null) info.PageTitle = titleNode.InnerText.Trim();

            info.PageEncoding = doc.Encoding;
            return info;
        }

        #region Private helpers

        /// <summary>
        /// Use an XPath expression to add controls of a specific type to the list
        /// </summary>
        /// <param name="rootNode">Rootnode for this search</param>
        /// <param name="xPath"></param>
        /// <param name="controlType"></param>
        private static IEnumerable<HtmlControlInfo> FindControls(HtmlNode rootNode, string xPath, string controlType, HtmlControlTypeEnum htmlControlType, ParsingOptions options)
        {
            if (options.PreferredIdentifications == null) throw new ArgumentException("Options do not defined the preferred indentification.");

            var controls = new List<HtmlControlInfo>();
            var nodes = rootNode.SelectNodes(xPath);
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    // Read basic info from the node
                    var ctrl = new HtmlControlInfo();
                    ctrl.HtmlId = node.Id;
                    ctrl.HtmlTitle = node.GetAttributeValue("title", "");
                    ctrl.HtmlName = node.GetAttributeValue("name", "");
                    ctrl.HtmlCssClass = node.GetAttributeValue("class", "");
                    ctrl.Description = node.InnerText.Trim();

                    // Then set the properties we will use for code
                    ctrl.CodeControlType = controlType;
                    ctrl.HtmlXPath = node.XPath;
                    ctrl.HtmlControlType = htmlControlType;

                    ctrl.AssignIdentificationMethod(controls.AsQueryable(), options.PreferredIdentifications);
                    controls.Add(ctrl);
                }
            }
            return controls;
        }


        /// <summary>
        /// Transforms the given text to a text that can be used as (part of) a method or property name in C#
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string NormalizeAsControlName(string text)
        {
            if (text == null)
                return "";

            // Remove any remaining encoded characters
            string newID = Regex.Replace(text, "&[a-zA-Z]+;", "");

            newID = Regex.Replace(newID, @"['\.,\$\#\~;:()\[\]=""\\\/@\!\`\*\{\}<>]", "");
            newID = newID.Replace("-", "_").Replace("+", "Plus").Replace("%", "Pct");
            newID = newID.Replace("&nbsp;", "");    // Remove HTML spaces

            // Check for names that start with a digit and add an underscore at the beginning.
            Regex re = new Regex(@"^\d+.$");
            var match = re.Match(newID);
            if (match.Success)
            {
                newID = "_" + newID;
            }

            // If starting with a number then prefix with an underscore
            if (Regex.IsMatch(newID, "^[0-9]"))
                newID = "_" + newID;

            // Make it pretty and properly normalized to Unicode format C
            newID = ConvertToCamelCase(newID).Normalize();
            newID = newID.Replace("\n", " ").Replace("\r", "").Replace("\t", "");
            newID = newID.Trim();

            // Ensure we do not create identifiers which are too long.
            if (newID.Length > 511) newID = newID.Substring(100);

            return newID;
        }

        private static string ConvertToCamelCase(string phrase)
        {
            string[] splittedPhrase = phrase.Split(' ', '-', '.');
            var sb = new StringBuilder();
            //sb.Append(splittedPhrase[0].ToLower());
            //splittedPhrase[0] = string.Empty;

            foreach (String s in splittedPhrase)
            {
                char[] splittedPhraseChars = s.ToCharArray();
                if (splittedPhraseChars.Length > 0)
                {
                    splittedPhraseChars[0] = ((new String(splittedPhraseChars[0], 1)).ToUpper().ToCharArray())[0];
                }
                sb.Append(new String(splittedPhraseChars));
            }
            return sb.ToString();
        }


        /// <summary>
        /// Create a request to retrieve a webpage
        /// </summary>
        /// <param name="url">Address of the page</param>
        /// <returns>Instance of the request.</returns>
        private static WebRequest CreateRequest(string url)
        {
            WebRequest request = null;
            try
            {
                request = WebRequest.Create(url);
                if (request is HttpWebRequest)
                {
                    request.Timeout = 5000;
                    ((HttpWebRequest)request).UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.5) Gecko/20091102 Firefox/3.5.5";
                }
            }
            catch (UriFormatException)
            {
                var fileRequest = FileWebRequest.Create(url);
            }
            return request;
        }
        
        #endregion

    }
}