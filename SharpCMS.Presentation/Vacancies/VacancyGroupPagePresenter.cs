using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public class VacancyGroupPagePresenter : StaticPagePresenter, IVacancyGroupPagePresenter
    {
        #region .Ctor
        public VacancyGroupPagePresenter(IVacancyGroupPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IVacancyGroupPageView View
        {
            get { return (IVacancyGroupPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.CurrentArticle = GetCurrentArticle();
            View.CurrentSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
            View.Vacancies = GetAllVacancies();
        }

        private IEnumerable<VacancyView> GetAllVacancies()
        {
            FindVacanciesRequest request = new FindVacanciesRequest()
            {
                ShowInactive = View.AllowFullAccess,
                ParentId = View.Id
            };
            return _contentService.FindVacancies(request).VacanciesFound;
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

        public void DeleteVacancyGroup()
        {
            DeleteArticleRequest request = new DeleteArticleRequest() { Id = View.Id };
            _contentService.DeleteArticle(request);
        }
        #endregion
    }
}
