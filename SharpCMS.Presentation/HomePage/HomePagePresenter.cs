using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;
using SharpCMS.Repository.EF.Repositories;

namespace SharpCMS.Presentation
{
    public class HomePagePresenter : StaticPagePresenter, IHomePagePresenter
    {
        #region .Ctor
        public HomePagePresenter(IHomePageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IHomePageView View
        {
            get { return (IHomePageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.Id = GetHomePageArticleId();
            View.MainMenuNodes = GetMainMenuNodes();
            View.HomePageArticle = GetHomePageArticle();
            View.LatestNews = GetLatestNews();
            View.AnnouncementGroups = GetAnnouncementGroups();
            View.Companies = GetCompanies();
        }

        private string GetHomePageArticleId()
        {
            FindChildArticlesRequest request = new FindChildArticlesRequest()
            {
                ParentId = Guid.Empty.ToString(),
                ShowInactive = false
            };
            ArticleView rootArticle = _contentService.FindArticles(request).ArticlesFound.First();

            return rootArticle.Id;
        }

        private IEnumerable<CompanyView> GetCompanies()
        {
            FindCompaniesRequest request = new FindCompaniesRequest()
            {
                ParentId = "cf3e7ba9-df4f-4ab3-9fe4-1a1a9ed974ed",
                ShowInactive = View.AllowFullAccess
            };
            return _contentService.FindCompanies(request).CompaniesFound.TakeRandom(4);
        }

        private IEnumerable<ArticleView> GetAnnouncementGroups()
        {
            FindChildArticlesRequest request = new FindChildArticlesRequest()
            {
                ParentId = "1d8ffab0-0485-47fe-8f53-cbac3c9af423",
                ShowInactive = View.AllowFullAccess
            };
            return _contentService.FindArticles(request).ArticlesFound;
        }

        private IEnumerable<NewsView> GetLatestNews()
        {
            FindNewsCollectionRequest request = new FindNewsCollectionRequest()
            {
                ParentId = "13a2cfb5-dc64-49a5-8ab9-2f494bb0f85b",
                ShowUnpublished = View.AllowFullAccess
            };
            return _contentService.FindNewsCollection(request).NewsFound.Take(3);
        }

        private ArticleView GetHomePageArticle()
        {
            FindArticleRequest request = new FindArticleRequest() { Id = View.Id };
            return _contentService.FindArticle(request).ArticleFound;
        }
        #endregion
    }
}
