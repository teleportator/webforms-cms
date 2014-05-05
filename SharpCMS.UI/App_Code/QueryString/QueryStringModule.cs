using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections;

namespace SharpCMS.UI.QueryString
{
    public class QueryStringModule : IHttpModule
    {
        #region Fields
        private HttpApplication _app;
        private Hashtable _queryStringData;
        #endregion

        #region Methods
        public void Init(System.Web.HttpApplication context)
        {
            _app = context;
            _app.BeginRequest += OnEnter;

            // Load and cache the XML querystring file
            string fileName = HttpContext.Current.Server.MapPath("/Web.querystring");
            _queryStringData = QueryStringHelper.LoadFromFile(fileName);

        }

        public void Dispose() { }
        #endregion

        #region Helpers
        private void OnEnter(object source, EventArgs e)
        {
            // Retrieve the query string data structure for the current page
            string currentPage = HttpContext.Current.Request.Path.ToLower();
            QueryStringDescriptor qsDesc = (QueryStringDescriptor)_queryStringData[currentPage];

            // Abort the request if validation fails
            if (!QueryStringHelper.Validate(HttpContext.Current.Request.QueryString, qsDesc))
            {
                if (qsDesc.AbortOnError)
                {
                    //Throw New InvalidDataException()
                    HttpContext.Current.Response.StatusCode = 500;
                    HttpContext.Current.Response.StatusDescription = "Invalid query string";
                    HttpContext.Current.Response.End();
                }
            }

            // Add information for the page to the Context.Items collection
            HttpContext.Current.Items[QueryStringHelper.QUERYSTRINGVALIDATIONSTATUS] = QueryStringHelper.ErrorCode;
        }
        #endregion
    }
}