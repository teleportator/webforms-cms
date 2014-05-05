using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.UI.Shared.Controls;

namespace SharpCMS.UI.Shared.Master
{
    public interface ISideMenuContainer
    {
        SideMenuControl SideMenu { get; }
    }
}
