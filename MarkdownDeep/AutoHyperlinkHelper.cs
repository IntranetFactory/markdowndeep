using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MarkdownDeep
{
    internal class AutoHyperlinkHelper
    {
        /// <summary>
        /// This functions encloses hyperlinks in < (less than) and > (greather than) symbols 
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        internal static string PreProcessEncloseHyperlinksInGtLt(string inputText)
        {
            string result = inputText;

            Regex urlRegex = new Regex(@"(.?)(https?|ftp):\/\/[^'\"">\\\s]+");

            if (urlRegex.IsMatch(inputText))
            {
                result = urlRegex.Replace(inputText, urlMathEvaluator);
            }

            Regex mailtoRegex = new Regex(@"[\w\.]+@[\w\.]+\.[\w\.]+");
            if (mailtoRegex.IsMatch(inputText))
            {
                result = mailtoRegex.Replace(inputText, mailtoMatchEvaluator);
            }

            return result;
        }

        private static string mailtoMatchEvaluator(Match match)
        {
            string result = string.Empty;
            result = string.Format("<{0}>", match.Value.Trim());
            return result;
        }

        private static string urlMathEvaluator(Match match)
        {
            string result = string.Empty;
            if (!(match.Groups.Count > 2 && (match.Groups[1].Value == "(") || match.Groups[1].Value == "<"))
            {
                string value = match.Value.Trim();
                result = string.Format(" <{0}>", value);
            }
            else
            {
                result = match.Groups[0].Value;
            }

            return result;
        }
    }
}
