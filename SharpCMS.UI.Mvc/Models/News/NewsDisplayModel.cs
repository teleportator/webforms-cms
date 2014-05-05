using System;

namespace SharpCMS.UI.Mvc.Models.News
{
	public class NewsDisplayModel
	{
	    public Guid Id { get; set; }
	    public string NewsTitle { get; set; }
	    public string NewsPublishedDate { get; set; }
	    public string NewsText { get; set; }
	}
}