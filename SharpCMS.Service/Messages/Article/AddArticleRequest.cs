using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Messages
{
    public class AddArticleRequest
    {
        public string ParentId { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Text { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }

        public bool DisplayOnMainMenu { get; set; }
        public bool DisplayOnSideMenu { get; set; }
        public string ParentNodeId { get; set; }
        public string UrlPattern { get; set; }
        public string SortOrder { get; set; }

    }
}
