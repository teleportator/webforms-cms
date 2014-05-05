using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Presentation
{
    public interface IPageBaseView
    {
        bool AllowFullAccess { get; }
    }
}
