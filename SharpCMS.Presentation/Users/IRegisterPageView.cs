using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Presentation
{
    public interface IRegisterPageView : IPageBaseView, IMainMenuNodesContainer
    {
        string[] Errors { set; }
    }
}
