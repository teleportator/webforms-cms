using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Presentation
{
    public interface IAddAnnouncementItemPagePresenter
    {
        void Display();
        string CreateAnnouncementItem(string announcementTitle, string announcementAbstract, string announcementText,
            string announcementKeywords, string announcementDescription, string announcementEditor,
            bool announcementIsActive, string announcementStartingDate, string announcementExpiryDate, string announcementVenue,
            string announcementStartingTime, string announcementOrganizer, string announcementContact, string nodeSortOrder,
            bool nodeDisplayOnMainMenu, string nodeParentId, bool nodeDisplayOnSideMenu);
    }
}
