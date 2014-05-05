using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Messages
{
    public class AddCompanyRequest
    {
        public string Abstract { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Keywords { get; set; }
        public string ParentId { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public string Logo { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Hyperlink { get; set; }

        public bool DisplayOnMainMenu { get; set; }
        public bool DisplayOnSideMenu { get; set; }
        public string ParentNodeId { get; set; }
        public string UrlPattern { get; set; }
        public string SortOrder { get; set; }
    }
}
