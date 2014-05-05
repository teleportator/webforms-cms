using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using System.Web.Security;

namespace SharpCMS.Presentation
{
    public class LoginPagePresenter : StaticPagePresenter, ILoginPagePresenter
    {
        #region .Ctor
        public LoginPagePresenter(ILoginPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private ILoginPageView View
        {
            get { return (ILoginPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.MainMenuNodes = GetMainMenuNodes();
        }

        public void ValidateUser(string email, string password)
        {
            string login = Membership.GetUserNameByEmail(email);
            if (Membership.ValidateUser(login, password))
                FormsAuthentication.RedirectFromLoginPage(login, false);
        }
        #endregion
    }
}
