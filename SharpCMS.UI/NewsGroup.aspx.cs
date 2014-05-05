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
    public partial class NewsGroupPage : DynamicPage, INewsGroupPageView
    {
        #region Fields
        private NewsGroupPagePresenter _presenter;
        private ArticleView _currentArticle;
        #endregion

        #region Members
        public string Id
        {
            get { return Request.QueryString["Id"]; }
        }

        public IEnumerable<NewsView> NewsCollection
        {
            set
            {
                if (value.Count() > 0)
                {
                    rptNewsList.DataSource = value;
                    rptNewsList.DataBind();
                    lblEmptyNews.Visible = false;
                    rptNewsList.Visible = true;
                }
                else
                {
                    lblEmptyNews.Visible = true;
                    rptNewsList.Visible = false;
                }
            }
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
            _presenter = new NewsGroupPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnDeleteArticle_Click(object sender, EventArgs e)
        {
            _presenter.DeleteNewsGroup();
            Response.Redirect(_currentSiteNode.ParentNode.Url);
        }
        #endregion
    }
}