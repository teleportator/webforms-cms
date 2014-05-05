using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SharpCMS.Service.Views;
using SharpCMS.UI.Shared.Master;
using SharpCMS.Presentation;
using SharpCMS.Presentation.IoC;

namespace SharpCMS.UI.Admin
{
    public partial class AddArticlePage : StaticPage, IAddArticlePageView
    {
        #region Fields
        private IAddArticlePagePresenter _presenter;
        private SiteNodeView _parentSiteNode;
        #endregion

        #region Members
        public string ParentId
        {
            get { return Page.Request.QueryString["ParentId"]; }
        }

        public string PageType
        {
            get { return Page.Request.QueryString["PageType"]; }
        }

        public SiteNodeView ParentSiteNode
        {
            set
            {
                _parentSiteNode = value;
                if (!IsPostBack)
                {
                    Page.Title += " / " + "Новый раздел";
                    txtParentArticleTitle.Text = HttpUtility.HtmlDecode(value.Title);
                }
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = PresenterFactory.CreateAddArticlePagePresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnCreateArticle_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string articleUrl = _presenter.CreateArticle(HttpUtility.HtmlEncode(txtArticleTitle.Text),
                    HttpUtility.HtmlEncode(txtArticleAbstract.Text), txtArticleText.Value,
                    txtArticleKeywords.Text, txtArticleDescription.Text, User.Identity.Name, chkArticleIsActive.Checked,
                    chkArticleDisplayOnMainMenu.Checked, chkArticleDisplayOnSideMenu.Checked, _parentSiteNode.Id,
                    txtArticleSortOrder.Text);
                if (articleUrl != null)
                    Response.Redirect(articleUrl);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(_parentSiteNode.Url);
        }
        #endregion
    }
}