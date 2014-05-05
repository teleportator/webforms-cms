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
    public partial class NewsItem : DynamicPage, INewsItemPageView
    {
        #region Fields
        private INewsItemPagePresenter _presenter;
        private NewsView _currentNews;
        #endregion

        #region Members
        public string Id
        {
            get { return Request.QueryString["Id"]; }
        }

        public IEnumerable<CommentView> CurrentComments
        {
            set
            {
                if (value.Count() > 0)
                {
                    rptComments.DataSource = value;
                    rptComments.DataBind();
                    lblEmptyComments.Visible = false;
                    rptComments.Visible = true;
                }
                else
                {
                    lblEmptyComments.Visible = true;
                    rptComments.Visible = false;
                }
            }
        }

        public NewsView CurrentNews
        {
            set
            {
                if (value != null)
                {
                    _currentNews = value;

                    lblNewsTitle.Text = _currentNews.Title;
                    lblNewsDate.Text = _currentNews.PublishedDate;
                    lblNewsText.Text = _currentNews.Text;
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
            _presenter = new NewsItemPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();

            pnlAuthRequired.Visible = !User.Identity.IsAuthenticated;
            pnlCommentForm.Visible = !pnlAuthRequired.Visible;
        }

        protected void btnDeleteNewsItem_Click(object sender, EventArgs e)
        {
            _presenter.DeleteNewsItem();
            Response.Redirect(_currentSiteNode.ParentNode.Url);
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                _presenter.AddComment(txtCommentText.Text, User.Identity.Name);
                _presenter.Display();
                txtCommentText.Text = "";
            }
        }

        protected void rptComments_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commentId = e.CommandArgument.ToString();
            _presenter.DeleteComment(commentId);
            _presenter.Display();
        }
        #endregion
    }
}