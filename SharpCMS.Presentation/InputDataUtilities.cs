using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SharpCMS.Presentation
{
    public static class InputDataUtilities
    {
        public static string TextAreaHtmlEncode(string inputText)
        {
            StringBuilder result = new StringBuilder();
            string paragraphPattern = "<p>{0}</p>";
            string encodedText = HttpUtility.HtmlEncode(inputText);
            string[] paragraphs = encodedText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string paragraph in paragraphs)
            {
                result.Append(String.Format(paragraphPattern, paragraph));
            }
            return result.ToString();
        }
    }
}
