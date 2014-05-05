using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpCMS.Presentation;
using SharpCMS.Service.Views;
using SharpCMS.UI.Shared.Master;
using SharpCMS.UI.QueryString;

namespace SharpCMS.UI
{
    public class StaticPage : BasePage, IMainMenuNodesContainer
    {
        public SiteNodeViewCollection MainMenuNodes
        {
            set
            {
                ((ITopMenuContainer)Page.Master).MainMenuTop.SetMenuNodesToDisplay(value);
                ((IFooterMenuContainer)Page.Master).MainMenuFooter.SetMenuNodesToDisplay(value);
            }
        }
    }
}