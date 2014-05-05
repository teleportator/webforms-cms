using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public abstract class EditArticlePageBasePresenter : StaticPagePresenter
    {
        #region .Ctor
        public EditArticlePageBasePresenter(IEditArticlePageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IEditArticlePageView View
        {
            get { return (IEditArticlePageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.CurrentArticle = GetCurrentArticle();
            View.CurrentSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
        }

        public string SaveArticle(string articleId, string articleTitle, string articleAbstract, string articleText,
            string articleKeywords, string articleDescription, string articleEditor, bool articleIsActive,
            string nodeSortOrder, bool nodeDisplayOnMainMenu, bool nodeDisplayOnSideMenu)
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

        private SiteNodeView GetCurrentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.Id, All = false };
            return _contentService.FindNode(request).NodeFound;
        }

        private ArticleView GetCurrentArticle()
        {
            FindArticleRequest request = new FindArticleRequest() { Id = View.Id };
            return _contentService.FindArticle(request).ArticleFound;
        }
        #endregion
    }
}
