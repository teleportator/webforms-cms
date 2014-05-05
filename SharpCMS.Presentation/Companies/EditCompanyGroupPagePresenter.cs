using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;

namespace SharpCMS.Presentation
{
    public class EditCompanyGroupPagePresenter : EditArticlePageBasePresenter, IEditArticlePagePresenter
    {
        #region .Ctor
        public EditCompanyGroupPagePresenter(IEditArticlePageView view, ContentService contentService)
            : base(view, contentService) { }
        #endregion
    }
}
