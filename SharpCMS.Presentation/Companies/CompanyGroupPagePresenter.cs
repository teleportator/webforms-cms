using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public class CompanyGroupPagePresenter : StaticPagePresenter, ICompanyGroupPagePresenter
    {
        #region .Ctor
        public CompanyGroupPagePresenter(ICompanyGroupPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private ICompanyGroupPageView View
        {
            get { return (ICompanyGroupPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.CurrentArticle = GetCurrentArticle();
            View.CurrentSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
            View.Companies = GetAllCompanies();
        }

        private IEnumerable<CompanyView> GetAllCompanies()
        {
            FindCompaniesRequest request = new FindCompaniesRequest()
            {
                ParentId = View.Id,
                ShowInactive = View.AllowFullAccess
            };
            return _contentService.FindCompanies(request).CompaniesFound;
        }

        public void DeleteCompanyGroup()
        {
            DeleteArticleRequest request = new DeleteArticleRequest() { Id = View.Id };
            _contentService.DeleteArticle(request);

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
        #endregion
    }
}
