using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;

namespace SharpCMS.Presentation
{
    public class ErrorPagePresenter : StaticPagePresenter, IErrorPagePresenter
    {
        #region .Ctor
        public ErrorPagePresenter(IErrorPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IErrorPageView View
        {
            get { return (IErrorPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.MainMenuNodes = GetMainMenuNodes();
        }
        #endregion
    }
}
