using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpCMS.UI.QueryString
{
    static internal class QueryStringParameterExtensions
    {
        static internal bool Contains(this IList<QueryStringParameter> collection, string name)
        {
            try
            {
                collection.First<QueryStringParameter>(p => (p.CaseSensitive) ? string.Equals(p.Name, name,
                    StringComparison.Ordinal) : string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        static internal QueryStringParameter Find(this IList<QueryStringParameter> collection, string name)
        {
            try
            {
                return collection.First<QueryStringParameter>(p => string.Equals(p.Name, name,
                    StringComparison.OrdinalIgnoreCase));
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }
}