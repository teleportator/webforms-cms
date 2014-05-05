using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public class NewsGroupPagePresenter : StaticPagePresenter, INewsGroupPagePresenter
    {
        #region .Ctor
        public NewsGroupPagePresenter(INewsGroupPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private INewsGroupPageView View
        {
            get { return (INewsGroupPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.CurrentArticle = GetCurrentArticle();
            View.CurrentSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
            View.NewsCollection = GetAllNews();
        }

        private IEnumerable<NewsView> GetAllNews()
        {
            FindNewsCollectionRequest request = new FindNewsCollectionRequest()
            {
                ShowUnpublished = View.AllowFullAccess,
                ParentId = View.Id
            };
            return _contentService.FindNewsCollection(request).NewsFound;
        }

        private ArticleView GetCurrentArticle()
        {
            FindArticleRequest request = new FindArticleRequest() { Id = View.Id };
            return _contentService.FindArticle(request).ArticleFound;
        }
        
        private SiteNodeView GetCurrentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.Id, All = false };
            return _contentService.FindNode(request).NodeFound;
        }

        public void DeleteNewsGroup()
        {
            DeleteArticleRequest request = new DeleteArticleRequest() { Id = View.Id };
            _contentService.DeleteArticle(request);
        }
        #endregion
    }
}
