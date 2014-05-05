using System;
using System.Web.Mvc;
using SharpCMS.Service;
using SharpCMS.Service.IoC;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;

namespace SharpCMS.UI.Mvc.Controllers
{
    public class ControllerBase : Controller
    {
        public ControllerBase()
        {
            ContentService = ServiceFactory.CreateContentService();
        }

        protected bool AllowFullAccess { get; private set; }
        protected ContentService ContentService { get; private set; }

        protected SiteNodeView GetSiteNode(Guid id)
        {
            var request = new FindNodesRequest {ContentItemId = id.ToString(), All = false};
            return ContentService.FindNode(request).NodeFound;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            AllowFullAccess = User.IsInRole("Administrators");
        }
    }
}