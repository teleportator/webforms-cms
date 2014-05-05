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
    public partial class EditHomePage :  StaticPage, IEditHomePageView
    {
        #region Fields
        private EditHomePagePresenter _presenter;
        private SiteNodeView _rootSiteNode;
        #endregion

        #region Members
        public string Id { get; set; }

        public ArticleView RootArticle
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

        public SiteNodeView RootSiteNode
        {
            set
            {
                _rootSiteNode = value;
                if (!IsPostBack)
                {
                    Page.Title = HttpUtility.HtmlDecode(value.Title);
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
            _presenter = new EditHomePagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(_rootSiteNode.Url);
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