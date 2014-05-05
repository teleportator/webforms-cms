using System;

namespace SharpCMS.UI.Mvc.Models.Companies
{
	public class CompanyDisplayModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string LogoUrl { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Hyperlink { get; set; }
        public string Phone { get; set; }
    }
}