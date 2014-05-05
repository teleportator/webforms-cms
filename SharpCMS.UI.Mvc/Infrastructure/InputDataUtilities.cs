using System;
using System.Text;
using System.Web;

namespace SharpCMS.UI.Mvc.Infrastructure
{
    public static class InputDataUtilities
    {
        public static string TextAreaHtmlEncode(string inputText)
        {
            var result = new StringBuilder();
            const string paragraphPattern = "<p>{0}</p>";
            string encodedText = HttpUtility.HtmlEncode(inputText);
            string[] paragraphs = encodedText.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string paragraph in paragraphs)
            {
                result.Append(String.Format(paragraphPattern, paragraph));
            }
            return result.ToString();
        }
    }
}