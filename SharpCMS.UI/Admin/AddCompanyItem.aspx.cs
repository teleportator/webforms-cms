using System;
using System.Web.UI;
using SharpCMS.Presentation;
using SharpCMS.Presentation.IoC;
using SharpCMS.Service.Views;
using SharpCMS.UI.Shared.Master;
using System.Web;

namespace SharpCMS.UI.Admin
{
    public partial class AddCompanyItem : StaticPage, IAddCompanyItemPageView
    {
        #region Fields
        private IAddCompanyItemPagePresenter _presenter;
        private SiteNodeView _parentSiteNode;
        #endregion

        #region Members
        public string ParentId
        {
            get { return Request.QueryString["ParentId"]; }
        }

        public SiteNodeView ParentSiteNode
        {
            set
            {
                _parentSiteNode = value;
                if (!IsPostBack)
                {
                    Page.Title += " / " + "Новый элемент";
                    txtParentCompanyGroupTitle.Text = HttpUtility.HtmlDecode(value.Title);
                }
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new AddCompanyItemPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnSaveNewsItem_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string companyUrl = _presenter.CreateCompanyItem(HttpUtility.HtmlEncode(txtСompanyItemTitle.Text),
                    HttpUtility.HtmlEncode(txtCompanyItemAbstract.Text), txtCompanyItemText.Value, txtCompanyItemKeywords.Text, txtCompanyItemDescription.Text, User.Identity.Name,
                    chkCompanyItemIsActive.Checked, HttpUtility.HtmlEncode(txtCompanyItemAddress.Text),
                    txtCompanyItemEmail.Text, txtCompanyItemHyperlink.Text, iupCompanyLogo.CurrentImagePath,
                    HttpUtility.HtmlEncode(txtCompanyItemPhoneNumber.Text), txtCompanyItemSortOrder.Text,
                    chkCompanyItemDisplayOnMainMenu.Checked, _parentSiteNode.Id, chkCompanyItemDisplayOnSideMenu.Checked);
                Response.Redirect(companyUrl);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(_parentSiteNode.Url);
        }
        #endregion
    }
}