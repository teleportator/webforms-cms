using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public interface IEditIdeaItemPageView : IPageBaseView, IMainMenuNodesContainer
    {
        string Id { get; }
        IdeaView CurrentIdea { set; }
        SiteNodeView CurrentSiteNode { set; }
        IDictionary<int, string> CategoryList { set; }
    }
}
