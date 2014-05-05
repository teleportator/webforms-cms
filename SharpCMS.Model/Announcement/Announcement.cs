using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Infrastructure;

namespace SharpCMS.Model
{
    public class Announcement : ContentItem, IAggregateRoot
    {
        public DateTime StartingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Venue { get; set; }
        public string StartingTime { get; set; }
        public string Organizer { get; set; }
        public string Contact { get; set; }
    }
}
