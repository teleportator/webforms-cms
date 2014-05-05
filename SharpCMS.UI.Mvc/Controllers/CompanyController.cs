using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Web.Mvc;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;
using SharpCMS.UI.Mvc.Infrastructure;
using SharpCMS.UI.Mvc.Infrastructure.Abstract;
using SharpCMS.UI.Mvc.Models.Companies;

namespace SharpCMS.UI.Mvc.Controllers
{
	public class CompanyController : ControllerBase
	{
		private readonly ILogoManager _logoManager;

		public CompanyController()
		{
			_logoManager = new LogoManager();
		}

        [Authorize(Roles = "Administrators")]
		public ActionResult Create(Guid id)
		{
			SiteNodeView parentSiteNode = GetSiteNode(id);
			var model = new CompanyCreateModel
			            	{
			            		DisplayOnSideMenu = true,
			            		IsActive = true,
			            		LogoUrl = _logoManager.GetPath(String.Empty),
			            		ParentTitle = parentSiteNode.Title,
			            		ParentUrl = parentSiteNode.Url,
			            		SortOrder = 500,
			            		Title = "Новая организация"
			            	};
			return View(model);
		}

		[HttpPost]
        [Authorize(Roles = "Administrators")]
		public ActionResult Create(Guid id, CompanyCreateModel model)
		{
			SiteNodeView parentNode = GetSiteNode(id);

			if (!ModelState.IsValid)
			{
				model.ParentTitle = parentNode.Title;
				model.ParentUrl = parentNode.Url;
				return View(model);
			}

			var request = new AddCompanyRequest
			              	{
			              		Abstract = model.Abstract,
			              		CreatedBy = User.Identity.Name,
			              		Description = model.Description ?? String.Empty,
			              		IsActive = model.IsActive,
			              		Keywords = model.Keywords ?? String.Empty,
			              		ParentId = id.ToString(),
			              		Text = model.Text ?? String.Empty,
			              		Title = model.Title,
			              		Address = model.Address ?? String.Empty,
			              		Email = model.Email ?? String.Empty,
			              		Hyperlink = model.Hyperlink ?? String.Empty,
								Logo = _logoManager.GetFileName(model.LogoUrl),
			              		PhoneNumber = model.PhoneNumber ?? String.Empty,
			              		DisplayOnMainMenu = model.DisplayOnMainMenu,
			              		DisplayOnSideMenu = model.DisplayOnSideMenu,
			              		ParentNodeId = parentNode.Id,
			              		SortOrder = model.SortOrder.ToString(),
			              		UrlPattern = "/company/display/{0}"
			              	};
			AddCompanyResponse response = ContentService.AddCompany(request);

			return Redirect(response.CompanyUrl);
		}

        [Authorize(Roles = "Administrators")]
		public ActionResult Delete(Guid id)
		{
			SiteNodeView parentNode = GetSiteNode(id).ParentNode;

			var request = new DeleteCompanyRequest {Id = id.ToString()};
			ContentService.DeleteCompany(request);

			return Redirect(parentNode.Url);
		}

		public ActionResult Display(Guid id)
		{
			CompanyView company = GetCompany(id);
			var model = new CompanyDisplayModel
			            	{
			            		Id = id,
			            		Address = company.Address,
			            		Email = company.Email,
			            		Hyperlink = company.Hyperlink,
								LogoUrl = _logoManager.GetPath(company.Logo),
			            		Phone = company.PhoneNumber,
			            		Text = company.Text,
			            		Title = company.Title
			            	};
			return View(model);
		}

        [Authorize(Roles = "Administrators")]
		public ActionResult Edit(Guid id)
		{
			CompanyView company = GetCompany(id);
			SiteNodeView currentNode = GetSiteNode(id);
			var model = new CompanyEditModel
			            	{
			            		Abstract = company.Abstract,
			            		CurrentUrl = currentNode.Url,
			            		Description = company.Description,
			            		IsActive = company.IsActive,
			            		Keywords = company.Keywords,
			            		Text = company.Text,
			            		Title = company.Title,
			            		Address = company.Address,
			            		Email = company.Email,
			            		Hyperlink = company.Hyperlink,
								LogoUrl = _logoManager.GetPath(company.Logo),
			            		PhoneNumber = company.PhoneNumber,
			            		DisplayOnMainMenu = currentNode.DisplayOnMainMenu,
			            		DisplayOnSideMenu = currentNode.DisplayOnSideMenu,
			            		SortOrder = Int32.Parse(currentNode.SortOrder)
			            	};
			return View(model);
		}

		[HttpPost]
        [Authorize(Roles = "Administrators")]
		public ActionResult Edit(Guid id, CompanyEditModel model)
		{
			SiteNodeView currentNode = GetSiteNode(id);

			if (!ModelState.IsValid)
			{
				model.CurrentUrl = currentNode.Url;
				return View(model);
			}

			var request = new SaveCompanyRequest
			              	{
			              		Abstract = model.Abstract,
			              		Description = model.Description ?? String.Empty,
			              		Editor = User.Identity.Name,
			              		Id = id.ToString(),
			              		IsActive = model.IsActive,
			              		Keywords = model.Keywords ?? String.Empty,
			              		Text = model.Text,
			              		Title = model.Title,
			              		Address = model.Address ?? String.Empty,
			              		Email = model.Email ?? String.Empty,
			              		Hyperlink = model.Hyperlink ?? String.Empty,
								Logo = _logoManager.GetFileName(model.LogoUrl),
			              		PhoneNumber = model.PhoneNumber ?? String.Empty,
			              		DisplayOnMainMenu = model.DisplayOnMainMenu,
			              		DisplayOnSideMenu = model.DisplayOnSideMenu,
			              		SortOrder = model.SortOrder.ToString()
			              	};
			SaveCompanyResponse response = ContentService.SaveCompany(request);

			return Redirect(response.CompanyUrl);
		}

		public ActionResult List(Guid id)
		{
			var model = new CompanyListModel
			            	{
			            		Id = id,
			            		Companies = GetCompanyList(id)
			            	};
			return View(model);
		}

		[HttpPost]
        [Authorize(Roles = "Administrators")]
		public ActionResult Upload()
		{
			if (Request.Files.Count > 0)
			{
				try
				{
					HttpPostedFileBase file = Request.Files[0];
					string fileUrl = _logoManager.GetPath("img" + DateTime.Now.Ticks + ".jpg");

					var image = new Bitmap(file.InputStream);
					image = image.Resize(150, 1024);
					image.SaveJpeg(Server.MapPath(fileUrl), 90);

					return Json(new {imageUrl = fileUrl});
				}
				catch (Exception)
				{
				}
			}

			return Json(new {imageUrl = _logoManager.GetPath(String.Empty)});
		}

		private CompanyView GetCompany(Guid id)
		{
			var request = new FindCompanyRequest {Id = id.ToString()};
			return ContentService.FindCompany(request).CompanyFound;
		}

		private IEnumerable<CompanyView> GetCompanyList(Guid id)
		{
			var request = new FindCompaniesRequest
			              	{
			              		ParentId = id.ToString(),
			              		ShowInactive = AllowFullAccess
			              	};
			return ContentService.FindCompanies(request).CompaniesFound;
		}
	}
}