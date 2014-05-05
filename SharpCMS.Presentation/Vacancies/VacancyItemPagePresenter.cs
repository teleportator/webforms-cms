using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public class VacancyItemPagePresenter : StaticPagePresenter, IVacancyItemPagePresenter
    {
        #region .Ctor
        public VacancyItemPagePresenter(IVacancyItemPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IVacancyItemPageView View
        {
            get { return (IVacancyItemPageView)_view; }
        }
        #endregion

        #region Methods
        public void DeleteVacancyItem()
        {
            DeleteVacancyRequest deleteVacancyRequest = new DeleteVacancyRequest() { Id = View.Id };
            _contentService.DeleteVacancy(deleteVacancyRequest);
        }

        public void Display()
        {
            View.CurrentVacancy = GetCurrentVacancy();
            View.CurrentSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
        }

        private VacancyView GetCurrentVacancy()
        {
            FindVacancyRequest request = new FindVacancyRequest() { Id = View.Id };
            return _contentService.FindVacancy(request).VacancyFound;
        }

        private SiteNodeView GetCurrentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.Id, All = false };
            return _contentService.FindNode(request).NodeFound;
        }
        #endregion
    }
}
