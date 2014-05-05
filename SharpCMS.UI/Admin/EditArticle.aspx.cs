using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SharpCMS.Presentation;
using SharpCMS.Service.Views;
using SharpCMS.Presentation.IoC;
using SharpCMS.UI.Shared.Master;

namespace SharpCMS.UI.Admin
{
    public partial class EditArticlePage : StaticPage, IEditArticlePageView
    {
        #region Fields
        private IEditArticlePagePresenter _presenter;
        private SiteNodeView _currentSiteNode;
        #endregion

        #region Members
        public string Id
        {
            get { return Page.Request.QueryString["Id"]; }
        }

        public string PageType
        {
            get { return Page.Request.QueryString["PageType"]; }
        }

        public ArticleView CurrentArticle
        {
            set
            {
                if (!IsPostBack)
                {
                    txtArticleTitle.Text = HttpUtility.HtmlDecode(value.Title);
                    txtArticleText.Value = value.Text;
                    txtArticleAbstract.Text = HttpUtility.HtmlDecode(value.Abstract);
                    chkArticleIsActive.Checked = value.IsActive;
                    txtArticleKeywords.Text = value.Keywords;
                    txtArticleDescription.Text = value.Description;
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
                    txtParentArticleTitle.Text = HttpUtility.HtmlDecode(value.ParentNode.Title);
                    txtArticleSortOrder.Text = value.SortOrder;
                    chkArticleDisplayOnMainMenu.Checked = value.DisplayOnMainMenu;
                    chkArticleDisplayOnSideMenu.Checked = value.DisplayOnSideMenu;
                }
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = PresenterFactory.CreateEditArticlePagePresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(_currentSiteNode.Url);
        }

        protected void btnSaveArticle_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string articleUrl = _presenter.SaveArticle(this.Id, HttpUtility.HtmlEncode(txtArticleTitle.Text),
                    HttpUtility.HtmlEncode(txtArticleAbstract.Text), txtArticleText.Value, txtArticleKeywords.Text,
                    txtArticleDescription.Text, User.Identity.Name, chkArticleIsActive.Checked, txtArticleSortOrder.Text,
                    chkArticleDisplayOnMainMenu.Checked, chkArticleDisplayOnSideMenu.Checked);
                Response.Redirect(articleUrl);
            }
        }
        #endregion
    }
}