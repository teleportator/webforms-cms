using System;
using System.Collections.Generic;
using SharpCMS.Service.Views;

namespace SharpCMS.UI.Mvc.Models.Announcements
{
	public class AnnouncementListModel
	{
		public Guid Id { get; set; }
		public IEnumerable<AnnouncementView> Announcements { get; set; }
	}
}