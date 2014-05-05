using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Messages
{
    public class SaveNodeRequest
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ContentItemId { get; set; }
        public string SortOrder { get; set; }
        public bool DisplayOnSideMenu { get; set; }
        public bool DisplayOnMainMenu { get; set; }
        public bool IsActive { get; set; }
    }
}
