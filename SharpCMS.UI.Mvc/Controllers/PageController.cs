using System;
using System.Web.Mvc;
using SharpCMS.UI.Mvc.Models.Pages;

namespace SharpCMS.UI.Mvc.Controllers
{
    public class PageController : Controller
    {
        public ActionResult Display(Guid id)
        {
        	var model = new PageDisplayModel {Id = id};
            return View(model);
        }

    }
}
