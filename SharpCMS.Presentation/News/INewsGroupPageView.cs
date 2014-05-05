using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public interface INewsGroupPageView : IPageBaseView, IMainMenuNodesContainer
    {
        string Id { get; }
        IEnumerable<NewsView> NewsCollection { set; }
        ArticleView CurrentArticle { set; }
        SiteNodeView CurrentSiteNode { set; }
    }
}
