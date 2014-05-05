﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public interface IAddIdeaItemPageView : IPageBaseView, IMainMenuNodesContainer
    {
        string ParentId { get; }
        SiteNodeView ParentSiteNode { set; }
        IDictionary<int, string> CategoryList { set; }
    }
}
