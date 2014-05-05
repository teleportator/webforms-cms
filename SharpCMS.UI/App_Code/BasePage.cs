using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpCMS.Presentation;
using SharpCMS.UI.QueryString;
using System.IO;

namespace SharpCMS.UI
{
    public class BasePage : System.Web.UI.Page, IPageBaseView
    {
        #region Members
        public bool AllowFullAccess
        {
            get { return (User.IsInRole("Administrators")) ? true : false; }
        }

        public QueryStringErrorCodes QueryStringErrorCode
        {
            get { return (QueryStringErrorCodes)HttpContext.Current.Items[QueryStringHelper.QUERYSTRINGVALIDATIONSTATUS]; }
            set { HttpContext.Current.Items[QueryStringHelper.QUERYSTRINGVALIDATIONSTATUS] = value; }
        }
        #endregion

        #region Methods
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (QueryStringErrorCode != QueryStringErrorCodes.NoError)
            {
                TransferToErrorPage(StatusCode.FileNotFound);
            }
        }

        public void Page_Error(object sender, EventArgs e)
        {
            TransferToErrorPage(StatusCode.InternalError);
        }

        public void TransferToErrorPage(StatusCode statusCode)
        {
            Response.StatusCode = (int)statusCode;
            QueryStringErrorCode = QueryStringErrorCodes.NoError;
            Server.Transfer("/Error.aspx");
        }
        #endregion
    }
}