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

namespace SharpCMS.UI
{
    public partial class ArticlePage : DynamicPage, IArticlePageView
    {
        #region Fields
        private ArticlePagePresenter _presenter;
        private ArticleView _currentArticle;
        #endregion

        #region Members
        public string Id
        {
            get { return Page.Request.QueryString["Id"]; }
        }

        public ArticleView CurrentArticle
        {
            set
            {
                if (value != null)
                {
                    _currentArticle = value;

                    lblArticleTitle.Text = _currentArticle.Title;
                    lblArticleText.Text = _currentArticle.Text;
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
            _presenter = new ArticlePagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnDeleteArticle_Click(object sender, EventArgs e)
        {
            _presenter.DeleteArticle();
            Response.Redirect(_currentSiteNode.ParentNode.Url);
        }
        #endregion
    }
}