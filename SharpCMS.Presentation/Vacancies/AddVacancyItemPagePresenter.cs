using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public class AddVacancyItemPagePresenter : StaticPagePresenter, IAddVacancyItemPagePresenter
    {
        #region .Ctor
        public AddVacancyItemPagePresenter(IAddVacancyItemPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IAddVacancyItemPageView View
        {
            get { return (IAddVacancyItemPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.ParentSiteNode = GetParentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
        }

        public string CreateVacancyItem(string vacancyTitle, string vacancyAbstract, string vacancyText, string vacancyKeywords,
            string vacancyDescription, string vacancyEditor, bool vacancyIsActive, string vacancyEmployer,
            string vacancyResponsibilities, string vacancyContact, string vacancyDemands, string vacancyConditions,
            string nodeSortOrder, bool nodeDisplayOnMainMenu, string nodeParentId, bool nodeDisplayOnSideMenu)
        {
            AddVacancyRequest request = new AddVacancyRequest()
            {
                Abstract = vacancyAbstract,
                CreatedBy = vacancyEditor,
                Description = vacancyDescription,
                IsActive = vacancyIsActive,
                Keywords = vacancyKeywords,
                ParentId = View.ParentId,
                Text = vacancyText,
                Title = vacancyTitle,
                Employer = vacancyEmployer,
                Responsibilities = vacancyResponsibilities,
                Contact = vacancyContact,
                Demands = vacancyDemands,
                Conditions = vacancyConditions,
                DisplayOnMainMenu = nodeDisplayOnMainMenu,
                DisplayOnSideMenu = nodeDisplayOnSideMenu,
                ParentNodeId = nodeParentId,
                SortOrder = nodeSortOrder,
                UrlPattern = "/VacancyItem.aspx?Id={0}"
            };
            AddVacancyResponse response = _contentService.AddVacancy(request);

            return response.VacancyUrl;
        }

        private SiteNodeView GetParentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.ParentId, All = false };
            return _contentService.FindNode(request).NodeFound;
        }
        #endregion
    }
}
