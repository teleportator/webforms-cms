using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Messages
{
    public class SaveAnnouncementResponse : ResponseBase
    {
        public string AnnouncementUrl { get; set; }
    }
}
