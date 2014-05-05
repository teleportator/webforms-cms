using System;
using System.Collections.Generic;
using System.Web.UI;
using SharpCMS.Presentation;
using SharpCMS.Presentation.IoC;
using SharpCMS.Service.Views;
using SharpCMS.UI.Shared.Master;

namespace SharpCMS.UI
{
    public partial class HomePage : StaticPage, IHomePageView
    {
        #region Fields
        private IHomePagePresenter _presenter;
        public const string _path = @"/Shared/Images/no-image.jpg";
        #endregion
        
        #region Members
        public string Id { get; set; }

        public ArticleView HomePageArticle
        {
            set
            {
                if (value != null)
                {
                    lblHomePageArticleText.Text = value.Text;
                    lblHomePageArticleHeader.Text = value.Title;
                }
                else
                {
                    TransferToErrorPage(StatusCode.FileNotFound);
                }
            }
        }

        public IEnumerable<NewsView> LatestNews
        {
            set
            {
                rptLatestNews.DataSource = value;
                rptLatestNews.DataBind();
            }
        }

        public IEnumerable<ArticleView> AnnouncementGroups
        {
            set
            {
                rptAnnouncementGroups.DataSource = value;
                rptAnnouncementGroups.DataBind();
            }
        }

        public IEnumerable<CompanyView> Companies
        {
            set
            {
                rptCompanies.DataSource = value;
                rptCompanies.DataBind();
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new HomePagePresenter(this, ServiceFactory.CreateContentService());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }
        #endregion
    }
}