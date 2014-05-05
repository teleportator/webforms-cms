using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public class EditHomePagePresenter : StaticPagePresenter, IEditHomePagePresenter
    {
        #region .Ctor
        public EditHomePagePresenter(IEditHomePageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IEditHomePageView View
        {
            get { return (IEditHomePageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.Id = GetHomePageArticleId();
            View.RootArticle = GetHomePageArticle();
            View.RootSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
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

        private SiteNodeView GetCurrentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.Id, All = false };
            return _contentService.FindNode(request).NodeFound;
        }

        private ArticleView GetHomePageArticle()
        {
            FindArticleRequest request = new FindArticleRequest() { Id = View.Id };
            return _contentService.FindArticle(request).ArticleFound;
        }

        public string SaveArticle(string articleId, string articleTitle, string articleAbstract, string articleText,
            string articleKeywords, string articleDescription, string articleEditor, bool articleIsActive, string nodeSortOrder,
            bool nodeDisplayOnMainMenu, bool nodeDisplayOnSideMenu)
        {
            SaveArticleRequest request = new SaveArticleRequest()
            {
                Abstract = articleAbstract,
                Description = articleDescription,
                Editor = articleEditor,
                Id = articleId,
                IsActive = articleIsActive,
                Keywords = articleKeywords,
                Text = articleText,
                Title = articleTitle,
                DisplayOnMainMenu = nodeDisplayOnMainMenu,
                DisplayOnSideMenu = nodeDisplayOnSideMenu,
                SortOrder = nodeSortOrder
            };
            SaveArticleResponse response = _contentService.SaveArticle(request);

            return response.ArticleUrl;
        }
        #endregion
    }
}
