using System;
using System.Web.UI;
using SharpCMS.Presentation;
using SharpCMS.Presentation.IoC;
using SharpCMS.UI.Shared.Master;

namespace SharpCMS.UI
{
    public partial class Login : StaticPage, ILoginPageView
    {
        #region Fields
        private ILoginPagePresenter _presenter;
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new LoginPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            _presenter.ValidateUser(txtUserEmail.Text, txtUserPassword.Text);
        }
        #endregion
    }
}