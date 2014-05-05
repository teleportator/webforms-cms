using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public interface ICompanyGroupPageView : IPageBaseView, IMainMenuNodesContainer
    {
        string Id { get; }
        ArticleView CurrentArticle { set; }
        SiteNodeView CurrentSiteNode { set; }
        IEnumerable<CompanyView> Companies { set; }
    }
}
