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
    public partial class AnnouncementGroupPage : DynamicPage, IAnnouncementGroupPageView
    {
        #region Fields
        private IAnnouncementGroupPagePresenter _presenter;
        private ArticleView _currentArticle;
        #endregion

        #region Members
        public string Id
        {
            get { return Request.QueryString["Id"]; }
        }

        public IEnumerable<AnnouncementView> Announcements
        {
            set
            {
                if (value.Count() > 0)
                {
                    rptAnnouncements.DataSource = value;
                    rptAnnouncements.DataBind();
                    lblEmptyAnnouncements.Visible = false;
                    rptAnnouncements.Visible = true;
                }
                else
                {
                    lblEmptyAnnouncements.Visible = true;
                    rptAnnouncements.Visible = false;
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
            _presenter = new AnnouncementGroupPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnDeleteAnnouncementGroup_Click(object sender, EventArgs e)
        {
            _presenter.DeleteAnnouncementGroup();
            Response.Redirect(_currentSiteNode.ParentNode.Url);
        }
        #endregion
    }
}