using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SharpCMS.Presentation;
using SharpCMS.Presentation.IoC;
using SharpCMS.UI.Shared.Master;
using System.Web.Security;

namespace SharpCMS.UI
{
    public partial class RegisterPage : StaticPage, IRegisterPageView
    {
        #region Fields
        private IRegisterPagePresenter _presenter;
        #endregion

        #region Members
        public string[] Errors
        {
            set
            {
                if (value.Count() > 0)
                {
                    rptErrors.Visible = true;
                    rptErrors.DataSource = value;
                    rptErrors.DataBind();
                }
                else
                {
                    rptErrors.Visible = true;
                }
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new RegisterPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            bool success = _presenter.CreateUser(txtUserEmail.Text, txtUserName.Text, txtPassword.Text);
            if (success)
            {
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, false);
            }
        }
        #endregion
    }
}