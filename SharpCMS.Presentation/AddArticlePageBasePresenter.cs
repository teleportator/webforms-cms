using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public abstract class AddArticlePageBasePresenter : StaticPagePresenter
    {
        #region .Ctor
        public AddArticlePageBasePresenter(IAddArticlePageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        public abstract string PageUrlPattern { get; }
        
        private IAddArticlePageView View
        {
            get { return (IAddArticlePageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.ParentSiteNode = GetParentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
        }

        public string CreateArticle(string articleTitle, string articleAbstract, string articleText, string articleKeywords,
            string articleDescription, string articleCreatedBy, bool articleIsActive, bool nodeDisplayOnMainMenu,
            bool nodeDisplayOnSideMenu, string nodeParentId, string nodeSortOrder)
        {
            AddArticleRequest addArticleRequest = new AddArticleRequest()
            {
                Abstract = articleAbstract,
                CreatedBy = articleCreatedBy,
                Description = articleDescription,
                IsActive = articleIsActive,
                Keywords = articleKeywords,
                ParentId = View.ParentId,
                Text = articleText,
                Title = articleTitle,
                DisplayOnMainMenu = nodeDisplayOnMainMenu,
                DisplayOnSideMenu = nodeDisplayOnSideMenu,
                ParentNodeId = nodeParentId,
                SortOrder = nodeSortOrder,
                UrlPattern = PageUrlPattern
            };
            return _contentService.AddArticle(addArticleRequest).ArticleUrl;
        }

        private SiteNodeView GetParentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.ParentId, All = false };
            return _contentService.FindNode(request).NodeFound;
        }
        #endregion
    }
}
