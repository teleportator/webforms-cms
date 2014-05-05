using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;
using SharpCMS.Service;

namespace SharpCMS.Presentation
{
    public interface IStaticPagePresenter
    {
        SiteNodeViewCollection GetMainMenuNodes();
    }
}
