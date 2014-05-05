using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public interface IIdeaGroupPageView : IPageBaseView, IMainMenuNodesContainer
    {
        string Id { get; }
        IEnumerable<IdeaView> Ideas { set; }
        ArticleView CurrentArticle { set; }
        SiteNodeView CurrentSiteNode { set; }
    }
}
