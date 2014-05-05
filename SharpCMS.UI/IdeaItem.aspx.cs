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

namespace SharpCMS.UI
{
    public partial class IdeaItemPage : DynamicPage, IIdeaItemPageView
    {
        #region Fields
        private IIdeaItemPagePresenter _presenter;
        private IdeaView _currentIdea;
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

        public IdeaView CurrentIdea
        {
            set
            {
                if (value != null)
                {
                    _currentIdea = value;

                    lblIdeaTitle.Text = _currentIdea.Title;
                    lblIdeaText.Text = _currentIdea.Text;
                    lblIdeaCreated.Text = _currentIdea.Created;
                    lblIdeaAuthor.Text = _currentIdea.CreatedBy;
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
            _presenter = new IdeaItemPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();

            pnlAuthRequired.Visible = !User.Identity.IsAuthenticated;
            pnlCommentForm.Visible = !pnlAuthRequired.Visible;
        }

        protected void btnDeleteIdeaItem_Click(object sender, EventArgs e)
        {
            _presenter.DeleteIdeaItem();
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