using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public interface IEditAnnouncementItemPageView : IPageBaseView, IMainMenuNodesContainer
    {
        string Id { get; }
        AnnouncementView CurrentAnnouncement { set; }
        SiteNodeView CurrentSiteNode { set; }
    }
}
