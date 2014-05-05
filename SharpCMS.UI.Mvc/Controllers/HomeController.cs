using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;
using SharpCMS.UI.Mvc.Infrastructure;
using SharpCMS.UI.Mvc.Models;

namespace SharpCMS.UI.Mvc.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            var model = new HomeModel
                            {
                                Id = GetHomePageArticleId(),
                                LatestNews = GetLatestNews(),
                                AnnouncementGroups = GetAnnouncementGroups(),
                                Companies = GetCompanies()
                            };

            model.HomePageArticle = GetHomePageArticle(model.Id);

            return View(model);
        }

		public string Reconstruction()
		{
			return "Under Construction";
		}

        private IEnumerable<ArticleView> GetAnnouncementGroups()
        {
            var request = new FindChildArticlesRequest
                              {
                                  ParentId = "1d8ffab0-0485-47fe-8f53-cbac3c9af423",
                                  ShowInactive = AllowFullAccess
                              };
            return ContentService.FindArticles(request).ArticlesFound;
        }

        private IEnumerable<CompanyView> GetCompanies()
        {
            var request = new FindCompaniesRequest
                              {
                                  ParentId = "cf3e7ba9-df4f-4ab3-9fe4-1a1a9ed974ed",
                                  ShowInactive = AllowFullAccess
                              };
            return ContentService.FindCompanies(request).CompaniesFound.TakeRandom(4);
        }

        private ArticleView GetHomePageArticle(string id)
        {
            var request = new FindArticleRequest {Id = id};
            return ContentService.FindArticle(request).ArticleFound;
        }

        private string GetHomePageArticleId()
        {
            var request = new FindChildArticlesRequest
                              {
                                  ParentId = Guid.Empty.ToString(),
                                  ShowInactive = false
                              };

            return ContentService.FindArticles(request).ArticlesFound.First().Id;
        }

        private IEnumerable<NewsView> GetLatestNews()
        {
            var request = new FindNewsCollectionRequest
                              {
                                  ParentId = "13a2cfb5-dc64-49a5-8ab9-2f494bb0f85b",
                                  ShowUnpublished = AllowFullAccess
                              };
            return ContentService.FindNewsCollection(request).NewsFound.Take(4);
        }
    }
}