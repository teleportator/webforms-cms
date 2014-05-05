using System;
using System.Collections.Generic;
using SharpCMS.Service.Views;

namespace SharpCMS.UI.Mvc.Models.Companies
{
	public class CompanyListModel
	{
		public Guid Id { get; set; }
		public IEnumerable<CompanyView> Companies { get; set; }
	}
}