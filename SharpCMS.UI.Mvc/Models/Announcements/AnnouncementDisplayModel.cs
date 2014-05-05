using System;

namespace SharpCMS.UI.Mvc.Models.Announcements
{
	public class AnnouncementDisplayModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public string Venue { get; set; }
        public string Time { get; set; }
        public string Organizer { get; set; }
        public string Contact { get; set; }
    }
}