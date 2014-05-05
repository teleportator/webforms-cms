using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;
using SharpCMS.Service;

namespace SharpCMS.Presentation
{
    public class ArticlePagePresenter : StaticPagePresenter, IArticlePagePresenter
    {
        #region .Ctor
        public ArticlePagePresenter(IArticlePageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IArticlePageView View
        {
            get { return (IArticlePageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.CurrentArticle = GetCurrentArticle();
            View.CurrentSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
        }

        public void DeleteArticle()
        {
            DeleteArticleRequest deleteArticleRequest = new DeleteArticleRequest() { Id = View.Id };
            _contentService.DeleteArticle(deleteArticleRequest);
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
