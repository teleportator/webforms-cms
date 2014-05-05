using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;
using SharpCMS.UI.Mvc.Models.Announcements;

namespace SharpCMS.UI.Mvc.Controllers
{
    public class AnnouncementController : ControllerBase
    {
        [Authorize(Roles = "Administrators")]
        public ActionResult Create(Guid id)
        {
            SiteNodeView parentSiteNode = GetSiteNode(id);
            var model = new AnnouncementCreateModel
                            {
                                ParentTitle = parentSiteNode.Title,
                                ParentUrl = parentSiteNode.Url,
                                StartingDate = DateTime.Now.Date,
                                ExpiryDate = DateTime.Now.Date,
                                SortOrder = 500,
                                IsActive = true,
                                Title = "Акция"
                            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrators")]
        public ActionResult Create(Guid id, AnnouncementCreateModel model)
        {
            SiteNodeView parentSiteNode = GetSiteNode(id);
            if (!ModelState.IsValid)
                return View(model);

            string announcementUrl =
                CreateAnnouncement(id, model.Title, model.Abstract, model.Text, model.Keywords, model.Description,
                                   User.Identity.Name, model.IsActive, model.StartingDate, model.ExpiryDate, model.Venue,
                                   model.StartingTime, model.Organizer, model.Contact, model.SortOrder,
                                   model.DisplayOnMainMenu,
                                   parentSiteNode.Id, model.DisplayOnSideMenu);

            return Redirect(announcementUrl);
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Delete(Guid id)
        {
            SiteNodeView parentNode = GetSiteNode(id).ParentNode;
            DeleteAnnouncement(id);
            return Redirect(parentNode.Url);
        }

        public ActionResult Display(Guid id)
        {
            AnnouncementView announcement = GetAnnouncement(id);
            var model = new AnnouncementDisplayModel
                            {
                                Id = id,
                                Contact = announcement.Contact,
                                Date = announcement.StartingDate == announcement.ExpiryDate
                                           ? announcement.StartingDate
                                           : announcement.StartingDate + " - " + announcement.ExpiryDate,
                                Organizer = announcement.Organizer,
                                Text = announcement.Text,
                                Time = announcement.StartingTime,
                                Title = announcement.Title,
                                Venue = announcement.Venue
                            };
            return View(model);
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(Guid id)
        {
            SiteNodeView currentNode = GetSiteNode(id);
            AnnouncementView announcement = GetAnnouncement(id);

            var model = new AnnouncementEditModel
                            {
                                Abstract = announcement.Abstract,
                                Contact = announcement.Contact,
                                CurrentUrl = currentNode.Url,
                                Description = announcement.Description,
                                DisplayOnMainMenu = currentNode.DisplayOnMainMenu,
                                DisplayOnSideMenu = currentNode.DisplayOnSideMenu,
                                ExpiryDate = DateTime.Parse(announcement.ExpiryDate),
                                IsActive = announcement.IsActive,
                                Keywords = announcement.Keywords,
                                Organizer = announcement.Organizer,
                                SortOrder = int.Parse(currentNode.SortOrder),
                                StartingDate = DateTime.Parse(announcement.StartingDate),
                                StartingTime = announcement.StartingTime,
                                Text = announcement.Text,
                                Title = announcement.Title,
                                Venue = announcement.Venue
                            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(Guid id, AnnouncementEditModel model)
        {
            SiteNodeView currentNode = GetSiteNode(id);
            if (!ModelState.IsValid)
                return View(model);

            SaveAnnouncement(id, model.Title, model.Abstract, model.Text, model.Keywords, model.Description,
                             User.Identity.Name, model.IsActive, model.StartingDate, model.ExpiryDate, model.Venue,
                             model.StartingTime, model.Organizer, model.Contact, model.SortOrder,
                             model.DisplayOnMainMenu, model.DisplayOnSideMenu);

            return Redirect(currentNode.Url);
        }

        public ActionResult List(Guid id)
        {
            var model = new AnnouncementListModel
                            {
                                Announcements = GetAnnouncementList(id),
                                Id = id
                            };
            return View(model);
        }

        private string CreateAnnouncement(Guid parentItemId, string title, string @abstract, string text,
                                          string keywords, string description, string editor, bool isActive,
                                          DateTime startingDate, DateTime expiryDate, string venue, string startingTime,
                                          string organizer, string contact, int sortOrder, bool displayOnMainMenu,
                                          string parentNodeId, bool displayOnSideMenu)
        {
            var request = new AddAnnouncementRequest
                              {
                                  Abstract = @abstract,
                                  CreatedBy = editor,
                                  Description = description ?? String.Empty,
                                  IsActive = isActive,
                                  Keywords = keywords ?? String.Empty,
                                  ParentId = parentItemId.ToString(),
                                  Text = text,
                                  Title = title,
                                  StartingDate = startingDate.ToShortDateString(),
                                  ExpiryDate = expiryDate.ToShortDateString(),
                                  Venue = venue,
                                  StartingTime = startingTime,
                                  Organizer = organizer,
                                  Contact = contact,
                                  DisplayOnMainMenu = displayOnMainMenu,
                                  DisplayOnSideMenu = displayOnSideMenu,
                                  ParentNodeId = parentNodeId,
                                  SortOrder = sortOrder.ToString(),
                                  UrlPattern = "/announcement/display/{0}"
                              };
            AddAnnouncementResponse response = ContentService.AddAnnouncement(request);

            return response.AnnouncementUrl;
        }

        private void DeleteAnnouncement(Guid id)
        {
            var deleteAnnouncementRequest = new DeleteAnnouncementRequest {Id = id.ToString()};
            ContentService.DeleteAnnouncement(deleteAnnouncementRequest);
        }

        private string SaveAnnouncement(Guid id, string title, string @abstract, string text, string keywords,
                                        string description, string editor, bool isActive, DateTime startingDate,
                                        DateTime expiryDate, string venue, string startingTime, string organizer,
                                        string contact, int sortOrder, bool displayOnMainMenu, bool displayOnSideMenu)
        {
            var request = new SaveAnnouncementRequest
                              {
                                  Abstract = @abstract,
                                  Description = description ?? String.Empty,
                                  Editor = editor,
                                  Id = id.ToString(),
                                  IsActive = isActive,
                                  Keywords = keywords ?? String.Empty,
                                  Text = text,
                                  Title = title,
                                  StartingDate = startingDate.ToShortDateString(),
                                  ExpiryDate = expiryDate.ToShortDateString(),
                                  Venue = venue,
                                  StartingTime = startingTime,
                                  Organizer = organizer,
                                  Contact = contact,
                                  DisplayOnMainMenu = displayOnMainMenu,
                                  DisplayOnSideMenu = displayOnSideMenu,
                                  SortOrder = sortOrder.ToString()
                              };
            SaveAnnouncementResponse response = ContentService.SaveAnnouncement(request);

            return response.AnnouncementUrl;
        }

        private AnnouncementView GetAnnouncement(Guid id)
        {
            var request = new FindAnnouncementRequest {Id = id.ToString()};
            return ContentService.FindAnnouncement(request).AnnouncementFound;
        }

        private IEnumerable<AnnouncementView> GetAnnouncementList(Guid id)
        {
            var request = new FindAnnouncementsRequest
                              {
                                  ShowInactive = AllowFullAccess,
                                  ParentId = id.ToString()
                              };
            return ContentService.FindAnnouncements(request).AnnouncementsFound;
        }
    }
}