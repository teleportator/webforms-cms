using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public class CompanyItemPagePresenter : StaticPagePresenter, ICompanyItemPagePresenter
    {
        #region .Ctor
        public CompanyItemPagePresenter(ICompanyItemPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private ICompanyItemPageView View
        {
            get { return (ICompanyItemPageView)_view; }
        }
        #endregion

        #region Methods
        public void DeleteCompanyItem()
        {
            DeleteCompanyRequest request = new DeleteCompanyRequest() { Id = View.Id };
            _contentService.DeleteCompany(request);
        }

        public void Display()
        {
            View.CurrentCompany = GetCurrentCompany();
            View.CurrentSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
        }

        private CompanyView GetCurrentCompany()
        {
            FindCompanyRequest request = new FindCompanyRequest() { Id = View.Id };
            return _contentService.FindCompany(request).CompanyFound;
        }

        private SiteNodeView GetCurrentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.Id, All = false };
            return _contentService.FindNode(request).NodeFound;
        }
        #endregion
    }
}
