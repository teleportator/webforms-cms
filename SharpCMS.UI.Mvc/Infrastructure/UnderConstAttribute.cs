using System;
using System.Configuration;
using System.Web.Mvc;

namespace SharpCMS.UI.Mvc.Infrastructure
{
	public class UnderConstAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (Boolean.Parse(ConfigurationManager.AppSettings["UnderConst"]))
				filterContext.HttpContext.Response.Redirect("/index.html");
		}
	}
}