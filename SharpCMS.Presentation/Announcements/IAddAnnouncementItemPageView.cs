﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public interface IAddAnnouncementItemPageView : IPageBaseView, IMainMenuNodesContainer
    {
        string ParentId { get; }
        SiteNodeView ParentSiteNode { set; }
    }
}
