using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public class AddCompanyItemPagePresenter : StaticPagePresenter, IAddCompanyItemPagePresenter
    {
        #region .Ctor
        public AddCompanyItemPagePresenter(IAddCompanyItemPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IAddCompanyItemPageView View
        {
            get { return (IAddCompanyItemPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.ParentSiteNode = GetParentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
        }

        public string CreateCompanyItem(string companyTitle, string companyAbstract, string companyText, string companyKeywords,
            string companyDescription, string companyEditor, bool companyIsActive, string companyAddress, string companyEmail,
            string companyHyperlink, string companyLogo, string companyPhoneNumber, string nodeSortOrder,
            bool nodeDisplayOnMainMenu, string nodeParentId, bool nodeDisplayOnSideMenu)
        {
            AddCompanyRequest request = new AddCompanyRequest()
            {
                Abstract = companyAbstract,
                CreatedBy = companyEditor,
                Description = companyDescription,
                IsActive = companyIsActive,
                Keywords = companyKeywords,
                ParentId = View.ParentId,
                Text = companyText,
                Title = companyTitle,
                Address = companyAddress,
                Email = companyEmail,
                Hyperlink = companyHyperlink,
                Logo = companyLogo,
                PhoneNumber = companyPhoneNumber,
                DisplayOnMainMenu = nodeDisplayOnMainMenu,
                DisplayOnSideMenu = nodeDisplayOnSideMenu,
                ParentNodeId = nodeParentId,
                SortOrder = nodeSortOrder,
                UrlPattern = "/CompanyItem.aspx?Id={0}"
            };
            AddCompanyResponse response = _contentService.AddCompany(request);

            return response.CompanyUrl;
        }

        private SiteNodeView GetParentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.ParentId, All = false };
            return _contentService.FindNode(request).NodeFound;
        }
        #endregion
    }
}
