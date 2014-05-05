using System;
using System.Web.Mvc;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;
using SharpCMS.UI.Mvc.Infrastructure;
using SharpCMS.UI.Mvc.Infrastructure.Abstract;
using SharpCMS.UI.Mvc.Models.Articles;

namespace SharpCMS.UI.Mvc.Controllers
{
	public class ArticleController : ControllerBase
	{
		private readonly IUrlPatternFactory _urlPatternFactory;

		public ArticleController()
		{
			_urlPatternFactory = new UrlPatternFactory();
		}

		public ActionResult Display(Guid id)
		{
			ArticleView article = GetArticle(id);
			var model = new ArticleDisplayModel
			            	{
			            		Title = article.Title,
			            		Text = article.Text
			            	};
			return View(model);
		}

        [Authorize(Roles = "Administrators")]
		public ActionResult Create(Guid id, string type)
		{
			SiteNodeView parentSiteNode = GetSiteNode(id);
			var model = new ArticleCreateModel
			            	{
			            		DisplayOnSideMenu = true,
			            		IsActive = true,
			            		ParentTitle = parentSiteNode.Title,
			            		ParentUrl = parentSiteNode.Url,
			            		SortOrder = 500,
			            		Title = "Новая страница"
			            	};
			return View(model);
		}

		[HttpPost]
        [Authorize(Roles = "Administrators")]
		public ActionResult Create(Guid id, string type, ArticleCreateModel model)
		{
			SiteNodeView parentNode = GetSiteNode(id);
			model.ParentTitle = parentNode.Title;
			model.ParentUrl = parentNode.Url;

			if (!ModelState.IsValid)
				return View(model);

			var addArticleRequest = new AddArticleRequest
			                        	{
			                        		Abstract = model.Abstract,
			                        		CreatedBy = User.Identity.Name,
			                        		Description = model.Description ?? String.Empty,
			                        		IsActive = model.IsActive,
			                        		Keywords = model.Keywords ?? String.Empty,
			                        		ParentId = id.ToString(),
			                        		Text = model.Text,
			                        		Title = model.Title,
			                        		DisplayOnMainMenu = model.DisplayOnMainMenu,
			                        		DisplayOnSideMenu = true,
			                        		ParentNodeId = parentNode.Id,
			                        		SortOrder = model.SortOrder.ToString(),
			                        		UrlPattern = _urlPatternFactory.GetUrlPatternFor(type.ToLower())
			                        	};
			string articleUrl = ContentService.AddArticle(addArticleRequest).ArticleUrl;

			return Redirect(articleUrl);
		}

        [Authorize(Roles = "Administrators")]
		public ActionResult Delete(Guid id)
		{
			SiteNodeView parentNode = GetSiteNode(id).ParentNode;
			DeleteArticle(id);
			return Redirect(parentNode.Url);
		}

        [Authorize(Roles = "Administrators")]
		public ActionResult Edit(Guid id, string type)
		{
			SiteNodeView currentNode = GetSiteNode(id);
			var article = GetArticle(id);
			var model = new ArticleEditModel
			            	{
								Abstract = article.Abstract,
								CurrentUrl = currentNode.Url,
								Description = article.Description,
								DisplayOnMainMenu = currentNode.DisplayOnMainMenu,
			            		DisplayOnSideMenu = currentNode.DisplayOnSideMenu,
			            		IsActive = article.IsActive,
								Keywords = article.Keywords,
			            		SortOrder = int.Parse(currentNode.SortOrder),
								Text = article.Text,
			            		Title = article.Title
			            	};
			return View(model);
		}

		[HttpPost]
        [Authorize(Roles = "Administrators")]
		public ActionResult Edit(Guid id, string type, ArticleEditModel model)
		{
			model.CurrentUrl = GetSiteNode(id).Url;
			if (!ModelState.IsValid)
				return View(model);
			var request = new SaveArticleRequest
			              	{
			              		Abstract = model.Abstract,
			              		Description = model.Description ?? String.Empty,
			              		Editor = User.Identity.Name,
			              		Id = id.ToString(),
			              		IsActive = model.IsActive,
								Keywords = model.Keywords ?? String.Empty,
			              		Text = model.Text,
			              		Title = model.Title,
			              		DisplayOnMainMenu = model.DisplayOnMainMenu,
			              		DisplayOnSideMenu = true,
			              		SortOrder = model.SortOrder.ToString()
			              	};
			var articleUrl = ContentService.SaveArticle(request).ArticleUrl;

			return Redirect(articleUrl);
		}

		private void DeleteArticle(Guid id)
		{
			var deleteArticleRequest = new DeleteArticleRequest {Id = id.ToString()};
			ContentService.DeleteArticle(deleteArticleRequest);
		}

		private ArticleView GetArticle(Guid id)
		{
			var request = new FindArticleRequest {Id = id.ToString()};
			return ContentService.FindArticle(request).ArticleFound;
		}
	}
}