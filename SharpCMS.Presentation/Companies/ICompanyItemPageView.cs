using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public interface ICompanyItemPageView : IPageBaseView, IMainMenuNodesContainer
    {
        string Id { get; }
        CompanyView CurrentCompany { set; }
        SiteNodeView CurrentSiteNode { set; }
    }
}
