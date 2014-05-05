using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public class AnnouncementItemPagePresenter : StaticPagePresenter, IAnnouncementItemPagePresenter
    {
        #region .Ctor
        public AnnouncementItemPagePresenter(IAnnouncementItemPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IAnnouncementItemPageView View
        {
            get { return (IAnnouncementItemPageView)_view; }
        }
        #endregion

        #region Methods
        public void DeleteAnnouncementItem()
        {
            DeleteAnnouncementRequest deleteAnnouncementRequest = new DeleteAnnouncementRequest() { Id = View.Id };
            _contentService.DeleteAnnouncement(deleteAnnouncementRequest);
        }

        public void Display()
        {
            View.CurrentAnnouncement = GetCurrentAnnouncement();
            View.CurrentSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
        }

        private AnnouncementView GetCurrentAnnouncement()
        {
            FindAnnouncementRequest request = new FindAnnouncementRequest() { Id = View.Id };
            return _contentService.FindAnnouncement(request).AnnouncementFound;
        }

        private SiteNodeView GetCurrentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.Id, All = false };
            return _contentService.FindNode(request).NodeFound;
        }
        #endregion
    }
}
