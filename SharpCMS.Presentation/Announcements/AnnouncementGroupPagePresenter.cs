using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public class AnnouncementGroupPagePresenter : StaticPagePresenter, IAnnouncementGroupPagePresenter
    {
        #region .Ctor
        public AnnouncementGroupPagePresenter(IAnnouncementGroupPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IAnnouncementGroupPageView View
        {
            get { return (IAnnouncementGroupPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.CurrentArticle = GetCurrentArticle();
            View.CurrentSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
            View.Announcements = GetAllAnnouncements();
        }

        private IEnumerable<AnnouncementView> GetAllAnnouncements()
        {
            FindAnnouncementsRequest request = new FindAnnouncementsRequest()
            {
                ShowInactive = View.AllowFullAccess,
                ParentId = View.Id
            };
            return _contentService.FindAnnouncements(request).AnnouncementsFound;
        }

        private ArticleView GetCurrentArticle()
        {
            FindArticleRequest request = new FindArticleRequest() { Id = View.Id };
            return _contentService.FindArticle(request).ArticleFound;
        }
        
        private SiteNodeView GetCurrentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.Id, All = false };
            return _contentService.FindNode(request).NodeFound;
        }

        public void DeleteAnnouncementGroup()
        {
            DeleteArticleRequest request = new DeleteArticleRequest() { Id = View.Id };
            _contentService.DeleteArticle(request);
        }
        #endregion
    }
}
