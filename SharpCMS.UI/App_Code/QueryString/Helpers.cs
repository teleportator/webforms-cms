using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Xml;
using System.Linq;
using System.Collections.Generic;

namespace SharpCMS.UI.QueryString
{
    internal enum QueryStringParamTypes : int
    {
        Text = 1,
        Int = 2,
        Bool = 3,
        Guid = 4
    }

    internal class QueryStringDescriptor
    {
        public string Url;
        public bool AbortOnError;
        public Collection<QueryStringParameter> Parameters;
    }

    internal class QueryStringParameter
    {
        public string Name;
        public QueryStringParamTypes Type;
        public int Length;
        public bool Optional;
        public bool CaseSensitive;
    }

    [Flags()]
    public enum QueryStringErrorCodes
    {
        NoError = 0,
        TooManyParameters = 1,
        InvalidQueryParameter = 2,
        MissingRequiredParameter = 4,
        InvalidContent = 8
    }

    public class QueryStringHelper
    {
        #region Fields
        protected static QueryStringErrorCodes _errorCode = QueryStringErrorCodes.NoError;
        public const string QUERYSTRINGVALIDATIONSTATUS = "QueryStringValidationStatus";
        #endregion

        #region Members
        static internal QueryStringErrorCodes ErrorCode
        {
            get { return _errorCode; }
        }
        #endregion

        #region Methods
        static internal Hashtable LoadFromFile(string fileName)
        {
            Hashtable qsTable = new Hashtable();

            // Load the document and get the root node
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            // Visit the <page> nodes
            XmlNodeList pages = doc.SelectNodes("querystring/page");
            foreach (XmlNode page in pages)
            {
                string url = page.Attributes["url"].Value.ToLower();
                bool abortOnError = true;
                XmlAttribute attrib = page.Attributes["abortOnError"];
                if ((attrib != null))
                {
                    string pv = attrib.Value;
                    if (string.Equals(pv, "false", StringComparison.OrdinalIgnoreCase))
                    {
                        abortOnError = false;
                    }
                }

                // Create the descriptor object
                QueryStringDescriptor qsDesc = new QueryStringDescriptor();
                qsDesc.Url = url;
                qsDesc.AbortOnError = abortOnError;

                // Get the object to collect param info objects
                Collection<QueryStringParameter> qsParamColl = new Collection<QueryStringParameter>();
                qsDesc.Parameters = qsParamColl;

                // Extract the parameters information
                XmlNodeList paramNodeList = page.SelectNodes("param");

                foreach (XmlNode paramNode in paramNodeList)
                {
                    QueryStringParameter queryStringParameter = new QueryStringParameter();
                    XmlAttribute paramAttrib = default(XmlAttribute);

                    // Extract the name of the n-th parameter
                    queryStringParameter.Name = string.Empty;
                    paramAttrib = paramNode.Attributes["name"];
                    if ((paramAttrib != null))
                    {
                        queryStringParameter.Name = paramAttrib.Value;
                    }

                    // Extract the optional length of the n-th parameter
                    queryStringParameter.Length = -1;
                    paramAttrib = paramNode.Attributes["length"];
                    if ((paramAttrib != null))
                    {
                        queryStringParameter.Length = Convert.ToInt32(paramAttrib.Value);
                    }

                    // Extract the type of the n-th parameter
                    queryStringParameter.Type = QueryStringParamTypes.Text;
                    paramAttrib = paramNode.Attributes["type"];
                    if ((paramAttrib != null))
                    {                        
                        queryStringParameter.Type =
                            (QueryStringParamTypes)Enum.Parse(typeof(QueryStringParamTypes), paramAttrib.Value);
                    }

                    // Extract the optional status of the n-th parameter
                    queryStringParameter.Optional = false;
                    paramAttrib = paramNode.Attributes["optional"];
                    if ((paramAttrib != null))
                    {
                        if (string.Equals(paramAttrib.Value, "true", StringComparison.OrdinalIgnoreCase))
                        {
                            queryStringParameter.Optional = true;
                        }
                    }

                    // Extract the case-sensitivity mode of the n-th parameter
                    queryStringParameter.CaseSensitive = false;
                    paramAttrib = paramNode.Attributes["casesensitive"];
                    if ((paramAttrib != null))
                    {
                        if (string.Equals(paramAttrib.Value, "true", StringComparison.OrdinalIgnoreCase))
                        {
                            queryStringParameter.CaseSensitive = true;
                        }
                    }

                    // Add parameter information to the collection
                    qsParamColl.Add(queryStringParameter);
                }

                // Add the descriptor to the global hash table
                qsTable.Add(url, qsDesc);
            }

            return qsTable;
        }

        static internal bool Validate(NameValueCollection postedQueryString, QueryStringDescriptor supportedQueryString)
        {
            _errorCode = QueryStringErrorCodes.NoError;

            if (supportedQueryString != null)
            {
                if (!ValidateParametersCount(postedQueryString, supportedQueryString)) { return false; }
                if (!ValidateSupportedParameters(postedQueryString, supportedQueryString)) { return false; }
                if (!ValidateParametersType(postedQueryString, supportedQueryString)) { return false; }
            }

            return true;
        }

        private static bool ValidateParametersType(NameValueCollection postedQueryString,
            QueryStringDescriptor supportedQueryString)
        {
            foreach (QueryStringParameter parameter in supportedQueryString.Parameters)
            {
                string name = parameter.Name;
                string postedValue = postedQueryString[name];

                // Check if the posted query string lack a mandatory parameter
                if (parameter.Optional == false)
                {
                    if (postedValue == null)
                    {
                        _errorCode = _errorCode | QueryStringErrorCodes.MissingRequiredParameter;
                        return false;
                    }

                    if (!CheckParamValue(parameter, postedValue))
                    {
                        _errorCode = _errorCode | QueryStringErrorCodes.InvalidContent;
                        return false;
                    }
                }
                else
                {
                    if ((postedValue != null))
                    {
                        if (!CheckParamValue(parameter, postedValue))
                        {
                            _errorCode = _errorCode | QueryStringErrorCodes.InvalidContent;
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private static bool ValidateSupportedParameters(NameValueCollection postedQueryString,
            QueryStringDescriptor supportedQueryString)
        {
            foreach (string name in postedQueryString.Keys)
            {
                if (!supportedQueryString.Parameters.Contains(name))
                {
                    _errorCode = _errorCode | QueryStringErrorCodes.InvalidQueryParameter;
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateParametersCount(NameValueCollection postedQueryString,
            QueryStringDescriptor supportedQueryString)
        {
            if (postedQueryString.Count > supportedQueryString.Parameters.Count)
            {
                _errorCode = _errorCode | QueryStringErrorCodes.TooManyParameters;
                return false;
            }

            return true;
        }

        static internal bool CheckParamValue(QueryStringParameter parameter, string parameterValue)
        {
            QueryStringParamTypes parameterType = parameter.Type;

            // parameter is never NULL at this point

            // Type is Guid
            if (parameterType == QueryStringParamTypes.Guid)
            {
                Guid result = Guid.Empty;
                if (!Guid.TryParse(parameterValue, out result))
                {
                    return false;
                }
            }

            // Type is Text
            // Check the length of the string matches the specified length
            if (parameterType == QueryStringParamTypes.Text)
            {
                if (parameter.Length > -1)
                {
                    if (parameterValue.Length > parameter.Length)
                    {
                        return false;
                    }
                }
            }

            // Type is Int
            if (parameterType == QueryStringParamTypes.Int)
            {
                int result;
                bool done = Int32.TryParse(parameterValue, out result);
                if (!done)
                {
                    return false;
                }
            }

            // Type is Bool
            if (parameterType == QueryStringParamTypes.Bool)
            {
                bool result;
                if (!Boolean.TryParse(parameterValue, out result))
                {
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}