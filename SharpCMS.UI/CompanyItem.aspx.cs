using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SharpCMS.Service.Views;
using SharpCMS.Presentation;
using SharpCMS.Presentation.IoC;
using SharpCMS.UI.Shared.Master;

namespace SharpCMS.UI
{
    public partial class CompanyItem : DynamicPage, ICompanyItemPageView
    {
        #region Fields
        private CompanyItemPagePresenter _presenter;
        private CompanyView _currentCompany;
        public const string _path = @"/Shared/Images/no-image.jpg";
        #endregion

        #region Members
        public string Id
        {
            get { return Request.QueryString["Id"]; }
        }

        public CompanyView CurrentCompany
        {
            set
            {
                if (value != null)
                {
                    _currentCompany = value;

                    lblCompanyTitle.Text = _currentCompany.Title;
                    lblCompanyText.Text = _currentCompany.Text;
                    imgCompanyLogo.ImageUrl = _currentCompany.Logo == "" ? _path : _currentCompany.Logo;
                    imgCompanyLogo.AlternateText = imgCompanyLogo.ToolTip = _currentCompany.Title;
                    lblCompanyAddress.Text = _currentCompany.Address;
                    lnkCompanyEmail.Text = _currentCompany.Email;
                    lnkCompanyEmail.NavigateUrl = "mailto:" + _currentCompany.Email;
                    lnkCompanyHyperlink.Text = _currentCompany.Hyperlink;
                    lnkCompanyHyperlink.NavigateUrl = @"http://" + _currentCompany.Hyperlink;
                    lblCompanyPhoneNumber.Text = _currentCompany.PhoneNumber;
                }
                else
                {
                    TransferToErrorPage(StatusCode.FileNotFound);
                }
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new CompanyItemPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnDeleteCompanyItem_Click(object sender, EventArgs e)
        {
            _presenter.DeleteCompanyItem();
            Response.Redirect(_currentSiteNode.ParentNode.Url);
        }
        #endregion
    }
}