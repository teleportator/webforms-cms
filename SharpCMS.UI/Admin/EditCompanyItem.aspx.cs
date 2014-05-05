using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SharpCMS.Presentation;
using SharpCMS.Service.Views;
using SharpCMS.UI.Shared.Master;
using SharpCMS.Presentation.IoC;

namespace SharpCMS.UI.Admin
{
    public partial class EditCompanyItem : StaticPage, IEditCompanyPageView
    {
        #region Fields
        private EditCompanyPagePresenter _presenter;
        private CompanyView _currentCompany;
        private SiteNodeView _currentSiteNode;
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
                _currentCompany = value;
                if (!IsPostBack)
                {
                    txtСompanyItemTitle.Text = HttpUtility.HtmlDecode(value.Title);
                    txtCompanyItemText.Value = value.Text;
                    txtCompanyItemAbstract.Text = HttpUtility.HtmlDecode(value.Abstract);
                    chkCompanyItemIsActive.Checked = value.IsActive;
                    txtCompanyItemAddress.Text = HttpUtility.HtmlDecode(value.Address);
                    txtCompanyItemEmail.Text = value.Email;
                    txtCompanyItemHyperlink.Text = value.Hyperlink;
                    iupCompanyLogo.CurrentImagePath = value.Logo;
                    txtCompanyItemPhoneNumber.Text = HttpUtility.HtmlDecode(value.PhoneNumber);
                    txtCompanyItemKeywords.Text = value.Keywords;
                    txtCompanyItemDescription.Text = value.Description;
                }
            }
        }

        public SiteNodeView CurrentSiteNode
        {
            set
            {
                _currentSiteNode = value;
                if (!IsPostBack)
                {
                    Page.Title += " / " + value.Title;
                    txtParentCompanyGroupTitle.Text = HttpUtility.HtmlDecode(value.ParentNode.Title);
                    txtCompanyItemSortOrder.Text = value.SortOrder;
                    chkCompanyItemDisplayOnMainMenu.Checked = value.DisplayOnMainMenu;
                    chkCompanyItemDisplayOnSideMenu.Checked = value.DisplayOnSideMenu;
                }
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new EditCompanyPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnSaveCompanyItem_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string companyUrl = _presenter.SaveCompanyItem(this.Id, HttpUtility.HtmlEncode(txtСompanyItemTitle.Text),
                    HttpUtility.HtmlEncode(txtCompanyItemAbstract.Text), txtCompanyItemText.Value, txtCompanyItemKeywords.Text,
                    txtCompanyItemDescription.Text, User.Identity.Name, chkCompanyItemIsActive.Checked,
                    HttpUtility.HtmlEncode(txtCompanyItemAddress.Text), txtCompanyItemEmail.Text,
                    txtCompanyItemHyperlink.Text, iupCompanyLogo.CurrentImagePath,
                    HttpUtility.HtmlEncode(txtCompanyItemPhoneNumber.Text), txtCompanyItemSortOrder.Text,
                    chkCompanyItemDisplayOnMainMenu.Checked, chkCompanyItemDisplayOnSideMenu.Checked);
                iupCompanyLogo.DeleteInitImage();
                Response.Redirect(companyUrl);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(_currentSiteNode.Url);
        }
        #endregion
    }
}