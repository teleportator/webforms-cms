using System.Collections.Generic;
using SharpCMS.Service.Views;

namespace SharpCMS.UI.Mvc.Models.Comments
{
	public class CommentsListModel
	{
		public IEnumerable<CommentView> Comments { get; set; }
	}
}