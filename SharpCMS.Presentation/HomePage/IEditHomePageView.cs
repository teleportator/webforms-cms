using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public interface IEditHomePageView : IPageBaseView, IMainMenuNodesContainer
    {
        string Id { get; set; }
        ArticleView RootArticle { set; }
        SiteNodeView RootSiteNode { set; }
    }
}
