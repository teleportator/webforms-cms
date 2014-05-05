using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public class EditArticlePagePresenter : EditArticlePageBasePresenter, IEditArticlePagePresenter
    {
        #region .Ctor
        public EditArticlePagePresenter(IEditArticlePageView view, ContentService contentService)
            : base(view, contentService) { }
        #endregion
    }
}
