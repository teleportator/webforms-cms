using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;

namespace SharpCMS.Presentation
{
    public class EditIdeaGroupPagePresenter : EditArticlePageBasePresenter, IEditArticlePagePresenter
    {
        #region .Ctor
        public EditIdeaGroupPagePresenter(IEditArticlePageView view, ContentService contentService)
            : base(view, contentService) { }
        #endregion
    }
}
