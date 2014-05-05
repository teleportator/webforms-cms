using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public class EditAnnouncementItemPagePresenter : StaticPagePresenter, IEditAnnouncementItemPagePresenter
    {
        #region .Ctor
        public EditAnnouncementItemPagePresenter(IEditAnnouncementItemPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IEditAnnouncementItemPageView View
        {
            get { return (IEditAnnouncementItemPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.CurrentAnnouncement = GetCurrentAnnouncement();
            View.CurrentSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
        }

        public string SaveAnnouncementItem(string announcementId, string announcementTitle, string announcementAbstract,
            string announcementText, string announcementKeywords, string announcementDescription, string announcementEditor,
            bool announcementIsActive, string announcementStartingDate, string announcementExpiryDate, string announcementVenue,
            string announcementStartingTime, string announcementOrganizer, string announcementContact, string nodeSortOrder,
            bool nodeDisplayOnMainMenu, bool nodeDisplayOnSideMenu)
        {
            SaveAnnouncementRequest request = new SaveAnnouncementRequest()
            {
                Abstract = announcementAbstract,
                Description = announcementDescription,
                Editor = announcementEditor,
                Id = announcementId,
                IsActive = announcementIsActive,
                Keywords = announcementKeywords,
                Text = announcementText,
                Title = announcementTitle,
                StartingDate = announcementStartingDate,
                ExpiryDate = announcementExpiryDate,
                Venue = announcementVenue,
                StartingTime = announcementStartingTime,
                Organizer = announcementOrganizer,
                Contact = announcementContact,
                DisplayOnMainMenu = nodeDisplayOnMainMenu,
                DisplayOnSideMenu = nodeDisplayOnSideMenu,
                SortOrder = nodeSortOrder
            };
            SaveAnnouncementResponse response = _contentService.SaveAnnouncement(request);

            return response.AnnouncementUrl;
        }

        private SiteNodeView GetCurrentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.Id, All = false };
            return _contentService.FindNode(request).NodeFound;
        }

        private AnnouncementView GetCurrentAnnouncement()
        {
            FindAnnouncementRequest request = new FindAnnouncementRequest() { Id = View.Id };
            return _contentService.FindAnnouncement(request).AnnouncementFound;
        }
        #endregion
    }
}
