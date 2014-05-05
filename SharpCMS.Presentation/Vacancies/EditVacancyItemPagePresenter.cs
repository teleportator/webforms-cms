using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public class EditVacancyItemPagePresenter : StaticPagePresenter, IEditVacancyItemPagePresenter
    {
        #region .Ctor
        public EditVacancyItemPagePresenter(IEditVacancyItemPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IEditVacancyItemPageView View
        {
            get { return (IEditVacancyItemPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.CurrentVacancy = GetCurrentVacancy();
            View.CurrentSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
        }

        public string SaveVacancyItem(string vacancyId, string vacancyTitle, string vacancyAbstract, string vacancyText,
            string vacancyKeywords, string vacancyDescription, string vacancyEditor, bool vacancyIsActive,
            string vacancyEmployer, string vacancyContact, string vacancyResponsibilities, string vacancyDemands,
            string vacancyConditions, string nodeSortOrder, bool nodeDisplayOnMainMenu, bool nodeDisplayOnSideMenu)
        {
            SaveVacancyRequest request = new SaveVacancyRequest()
            {
                Abstract = vacancyAbstract,
                Description = vacancyDescription,
                Editor = vacancyEditor,
                Id = vacancyId,
                IsActive = vacancyIsActive,
                Keywords = vacancyKeywords,
                Text = vacancyText,
                Title = vacancyTitle,
                Employer = vacancyEmployer,
                Contact = vacancyContact,
                Responsibilities = vacancyResponsibilities,
                Demands = vacancyDemands,
                Conditions = vacancyConditions,
                DisplayOnMainMenu = nodeDisplayOnMainMenu,
                DisplayOnSideMenu = nodeDisplayOnSideMenu,
                SortOrder = nodeSortOrder
            };
            SaveVacancyResponse response = _contentService.SaveVacancy(request);

            return response.VacancyUrl;
        }

        private SiteNodeView GetCurrentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.Id, All = false };
            return _contentService.FindNode(request).NodeFound;
        }

        private VacancyView GetCurrentVacancy()
        {
            FindVacancyRequest request = new FindVacancyRequest() { Id = View.Id };
            return _contentService.FindVacancy(request).VacancyFound;
        }
        #endregion
    }
}
