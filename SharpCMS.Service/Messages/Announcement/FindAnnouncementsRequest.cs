using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Messages
{
    public class FindAnnouncementsRequest
    {
        public bool ShowInactive { get; set; }
        public string ParentId { get; set; }
    }
}
