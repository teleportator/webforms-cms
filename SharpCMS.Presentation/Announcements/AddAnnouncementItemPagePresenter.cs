using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public class AddAnnouncementItemPagePresenter : StaticPagePresenter, IAddAnnouncementItemPagePresenter
    {
        #region .Ctor
        public AddAnnouncementItemPagePresenter(IAddAnnouncementItemPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IAddAnnouncementItemPageView View
        {
            get { return (IAddAnnouncementItemPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.ParentSiteNode = GetParentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
        }

        public string CreateAnnouncementItem(string announcementTitle, string announcementAbstract, string announcementText,
            string announcementKeywords, string announcementDescription, string announcementEditor,
            bool announcementIsActive, string announcementStartingDate, string announcementExpiryDate, string announcementVenue,
            string announcementStartingTime, string announcementOrganizer, string announcementContact, string nodeSortOrder,
            bool nodeDisplayOnMainMenu, string nodeParentId, bool nodeDisplayOnSideMenu)
        {
            AddAnnouncementRequest request = new AddAnnouncementRequest()
            {
                Abstract = announcementAbstract,
                CreatedBy = announcementEditor,
                Description = announcementDescription,
                IsActive = announcementIsActive,
                Keywords = announcementKeywords,
                ParentId = View.ParentId,
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
                ParentNodeId = nodeParentId,
                SortOrder = nodeSortOrder,
                UrlPattern = "/AnnouncementItem.aspx?Id={0}"
            };
            AddAnnouncementResponse response = _contentService.AddAnnouncement(request);

            return response.AnnouncementUrl;
        }

        private SiteNodeView GetParentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.ParentId, All = false };
            return _contentService.FindNode(request).NodeFound;
        }
        #endregion
    }
}
