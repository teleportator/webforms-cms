using System.Web.Mvc;

namespace SharpCMS.UI.Mvc.Models.Comments
{
    public class CommentCreateModel
    {
		[AllowHtml]
        public string CommentText { get; set; }
    }
}
