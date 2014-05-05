using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;
using SharpCMS.Model;

namespace SharpCMS.Service.Mappers
{
    public static class AnnouncementExtensions
    {
        public static AnnouncementView ConvertToAnnouncementView(this Announcement announcement)
        {
            if (announcement == null)
            {
                throw new ArgumentNullException();
            }
            return new AnnouncementView()
            {
                Id = announcement.Id.ToString(),
                Title = announcement.Title,
                ParentId = announcement.ParentId.ToString(),
                Abstract = announcement.Abstract,
                Created = announcement.Created.ToString("dd MMMM yyyy, HH:mm"),
                CreatedBy = announcement.CreatedBy,
                Description = announcement.Description,
                IsActive = announcement.IsActive,
                Keywords = announcement.Keywords,
                Text = announcement.Text,
                Updated = announcement.Updated.ToString(),
                UpdatedBy = announcement.UpdatedBy,
                StartingDate = announcement.StartingDate.ToString("dd MMMM yyyy"),
                ExpiryDate = announcement.ExpiryDate.ToString("dd MMMM yyyy"),
                Venue = announcement.Venue,
                StartingTime = announcement.StartingTime,
                Organizer = announcement.Organizer,
                Contact = announcement.Contact
            };
        }

        public static IEnumerable<AnnouncementView> ConvertToAnnouncementViewCollection(this IEnumerable<Announcement> announcements)
        {
            List<AnnouncementView> announcementViewCollection = new List<AnnouncementView>();
            foreach (Announcement announcement in announcements)
            {
                announcementViewCollection.Add(announcement.ConvertToAnnouncementView());
            }
            return announcementViewCollection;
        }
    }
}
