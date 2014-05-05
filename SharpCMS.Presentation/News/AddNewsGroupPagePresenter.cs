using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public class AddNewsGroupPagePresenter : AddArticlePageBasePresenter, IAddArticlePagePresenter
    {
        #region .Ctor
        public AddNewsGroupPagePresenter(IAddArticlePageView view, ContentService contentService)
            : base(view, contentService) { }
        #endregion

        #region Members
        public override string PageUrlPattern
        {
            get { return "/NewsGroup.aspx?Id={0}"; }
        }
        #endregion
    }
}
