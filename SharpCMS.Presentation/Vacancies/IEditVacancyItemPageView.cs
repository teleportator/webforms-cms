using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public interface IEditVacancyItemPageView : IPageBaseView, IMainMenuNodesContainer
    {
        string Id { get; }
        VacancyView CurrentVacancy { set; }
        SiteNodeView CurrentSiteNode { set; }
    }
}
