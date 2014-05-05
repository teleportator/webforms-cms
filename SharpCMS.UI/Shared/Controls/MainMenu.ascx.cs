using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SharpCMS.Service.Views;

namespace SharpCMS.UI.Shared.Controls
{
    public partial class MainMenuControl : System.Web.UI.UserControl
    {
        public void SetMenuNodesToDisplay(SiteNodeViewCollection nodes)
        {
            rptMainMenu.DataSource = nodes;
            rptMainMenu.DataBind();
        }
    }
}