using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public class IdeaGroupPagePresenter : StaticPagePresenter, IIdeaGroupPagePresenter
    {
        #region .Ctor
        public IdeaGroupPagePresenter(IIdeaGroupPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IIdeaGroupPageView View
        {
            get { return (IIdeaGroupPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.CurrentArticle = GetCurrentArticle();
            View.CurrentSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
            View.Ideas = GetAllIdeas();
        }

        private IEnumerable<IdeaView> GetAllIdeas()
        {
            FindIdeasRequest request = new FindIdeasRequest()
            {
                ShowInactive = View.AllowFullAccess,
                ParentId = View.Id
            };
            return _contentService.FindIdeas(request).IdeasFound;
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

        public void DeleteIdeaGroup()
        {
            DeleteArticleRequest request = new DeleteArticleRequest() { Id = View.Id };
            _contentService.DeleteArticle(request);
        }
        #endregion
    }
}
