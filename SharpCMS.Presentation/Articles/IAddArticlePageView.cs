using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public interface IAddArticlePageView : IPageBaseView, IMainMenuNodesContainer
    {
        string ParentId { get; }
        string PageType { get; }
        SiteNodeView ParentSiteNode { set; }
    }
}
