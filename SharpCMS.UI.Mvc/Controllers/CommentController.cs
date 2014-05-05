using System;
using System.Web.Mvc;
using System.Web.Routing;
using SharpCMS.Service.Messages;
using SharpCMS.UI.Mvc.Infrastructure;
using SharpCMS.UI.Mvc.Models.Comments;

namespace SharpCMS.UI.Mvc.Controllers
{
    public class CommentController : ControllerBase
    {
        public ActionResult Create(Guid id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Guid id, CommentCreateModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                var request = new AddCommentRequest
                                  {
                                      ParentId = id.ToString(),
                                      Text = InputDataUtilities.TextAreaHtmlEncode(model.CommentText),
                                      CreatedBy = User.Identity.Name,
                                      IsActive = true
                                  };
                ContentService.AddComment(request);
                return RedirectToAction("List", new RouteValueDictionary {{"id", id}});
            }

            return RedirectToAction("List", new RouteValueDictionary { { "id", id } });
        }

        public ActionResult List(Guid id)
        {
            var model = new CommentsListModel();
            var request = new FindCommentsRequest
                              {
                                  ParentId = id.ToString(),
                                  ShowInactive = AllowFullAccess
                              };
            model.Comments = ContentService.FindComments(request).CommentsFound;
            return View(model);
        }

        [Authorize]
        public ActionResult Remove(Guid id, Guid contentItemId)
        {
            if (AllowFullAccess)
            {
                var request = new DeleteCommentRequest {Id = id.ToString()};
                ContentService.DeleteComment(request);
            }
            return RedirectToAction("List", new RouteValueDictionary {{"id", contentItemId}});
        }
    }
}