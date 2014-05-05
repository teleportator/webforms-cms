using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Messages
{
    public class SaveCompanyRequest
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Text { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string Editor { get; set; }
        public bool IsActive { get; set; }
        public string Logo { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Hyperlink { get; set; }

        public string SortOrder { get; set; }
        public bool DisplayOnSideMenu { get; set; }
        public bool DisplayOnMainMenu { get; set; }
    }
}
