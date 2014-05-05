using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SharpCMS.UI.Shared.Controls;

namespace SharpCMS.UI.Shared.Master
{
    public partial class PageMasterPage : System.Web.UI.MasterPage, IFooterMenuContainer, ITopMenuContainer, ISideMenuContainer,
        IEditorMenuContainer
    {
        public MainMenuControl MainMenuFooter
        {
            get { return ((IFooterMenuContainer)this.Master).MainMenuFooter; }
        }

        public MainMenuControl MainMenuTop
        {
            get { return ((ITopMenuContainer)this.Master).MainMenuTop; }
        }

        public SideMenuControl SideMenu
        {
            get { return this.mnuSideMenu; }
        }

        public bool ShowEditorMenu
        {
            set { EditorPlaceHolder.Visible = value; }
        }
    }
}