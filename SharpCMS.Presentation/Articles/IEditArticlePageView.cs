using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public interface IEditArticlePageView : IPageBaseView, IMainMenuNodesContainer
    {
        string Id { get; }
        string PageType { get; }
        ArticleView CurrentArticle { set; }
        SiteNodeView CurrentSiteNode { set; }
    }
}
