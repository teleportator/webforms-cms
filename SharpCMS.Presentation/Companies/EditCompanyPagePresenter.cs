using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public class EditCompanyPagePresenter : StaticPagePresenter, IEditCompanyPagePresenter
    {
        #region .Ctor
        public EditCompanyPagePresenter(IEditCompanyPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IEditCompanyPageView View
        {
            get { return (IEditCompanyPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.CurrentCompany = GetCurrentCompany();
            View.CurrentSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
        }

        public string SaveCompanyItem(string companyId, string companyTitle, string companyAbstract, string companyText,
            string companyKeywords, string companyDescription, string companyEditor, bool companyIsActive, string companyAddress,
            string companyEmail, string companyHyperlink, string companyLogo, string companyPhoneNumber, string nodeSortOrder,
            bool nodeDisplayOnMainMenu, bool nodeDisplayOnSideMenu)
        {
            SaveCompanyRequest request = new SaveCompanyRequest()
            {
                Abstract = companyAbstract,
                Description = companyDescription,
                Editor = companyEditor,
                Id = companyId,
                IsActive = companyIsActive,
                Keywords = companyKeywords,
                Text = companyText,
                Title = companyTitle,
                Address = companyAddress,
                Email = companyEmail,
                Hyperlink = companyHyperlink,
                Logo = companyLogo,
                PhoneNumber = companyPhoneNumber,
                DisplayOnMainMenu = nodeDisplayOnMainMenu,
                DisplayOnSideMenu = nodeDisplayOnSideMenu,
                SortOrder = nodeSortOrder
            };
            SaveCompanyResponse response = _contentService.SaveCompany(request);

            return response.CompanyUrl;
        }

        private SiteNodeView GetCurrentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.Id, All = false };
            return _contentService.FindNode(request).NodeFound;
        }

        private CompanyView GetCurrentCompany()
        {
            FindCompanyRequest request = new FindCompanyRequest() { Id = View.Id };
            return _contentService.FindCompany(request).CompanyFound;
        }
        #endregion
    }
}
