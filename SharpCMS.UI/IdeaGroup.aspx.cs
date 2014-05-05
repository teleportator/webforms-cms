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
    public partial class IdeaGroupPage : DynamicPage, IIdeaGroupPageView
    {
        #region Fields
        private IdeaGroupPagePresenter _presenter;
        private ArticleView _currentArticle;
        #endregion

        #region Members
        public string Id
        {
            get { return Request.QueryString["Id"]; }
        }

        public IEnumerable<IdeaView> Ideas
        {
            set
            {
                if (value.Count() > 0)
                {
                    rptIdeas.DataSource = value;
                    rptIdeas.DataBind();
                    lblEmptyIdeas.Visible = false;
                    rptIdeas.Visible = true;
                }
                else
                {
                    lblEmptyIdeas.Visible = true;
                    rptIdeas.Visible = false;
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
            _presenter = new IdeaGroupPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnDeleteIdeaGroup_Click(object sender, EventArgs e)
        {
            _presenter.DeleteIdeaGroup();
            Response.Redirect(_currentSiteNode.ParentNode.Url);
        }
        #endregion
    }
}