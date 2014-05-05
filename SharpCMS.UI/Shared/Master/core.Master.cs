using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SharpCMS.UI.Shared.Controls;

namespace SharpCMS.UI.Shared.Master
{
    public partial class CoreMasterPage : System.Web.UI.MasterPage, IFooterMenuContainer, ITopMenuContainer, IEditorMenuContainer
    {
        public MainMenuControl MainMenuFooter
        {
            get { return this.mnuFooterMenu; }
        }

        public MainMenuControl MainMenuTop
        {
            get { return this.mnuTopMenu; }
        }

        public bool ShowEditorMenu
        {
            set { EditorPlaceHolder.Visible = value; }
        }
    }
}