using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Messages
{
    public class SaveArticleRequest
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Text { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string Editor { get; set; }
        public bool IsActive { get; set; }

        public string SortOrder { get; set; }
        public bool DisplayOnSideMenu { get; set; }
        public bool DisplayOnMainMenu { get; set; }
    }
}
