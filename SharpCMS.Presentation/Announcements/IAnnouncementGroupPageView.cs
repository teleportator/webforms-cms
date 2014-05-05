using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public interface IAnnouncementGroupPageView : IPageBaseView, IMainMenuNodesContainer
    {
        string Id { get; }
        IEnumerable<AnnouncementView> Announcements { set; }
        ArticleView CurrentArticle { set; }
        SiteNodeView CurrentSiteNode { set; }
    }
}
