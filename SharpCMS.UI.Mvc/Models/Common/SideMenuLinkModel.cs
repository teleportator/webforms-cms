namespace SharpCMS.UI.Mvc.Models.Common
{
	public class SideMenuLinkModel
	{
		public SideMenuCollectionModel Childs { get; set; }
		public bool IsCurrent { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
	}
}