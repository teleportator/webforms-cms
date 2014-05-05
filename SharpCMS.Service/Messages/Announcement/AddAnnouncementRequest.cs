using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Messages
{
    public class AddAnnouncementRequest
    {
        public string Abstract { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Keywords { get; set; }
        public string ParentId { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public string StartingDate { get; set; }
        public string ExpiryDate { get; set; }
        public string Venue { get; set; }
        public string StartingTime { get; set; }
        public string Organizer { get; set; }
        public string Contact { get; set; }
        public bool DisplayOnMainMenu { get; set; }
        public bool DisplayOnSideMenu { get; set; }
        public string ParentNodeId { get; set; }
        public string SortOrder { get; set; }
        public string UrlPattern { get; set; }
    }
}
