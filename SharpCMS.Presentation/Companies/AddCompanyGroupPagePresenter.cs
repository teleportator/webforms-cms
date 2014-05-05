using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;

namespace SharpCMS.Presentation
{
    public class AddCompanyGroupPagePresenter : AddArticlePageBasePresenter, IAddArticlePagePresenter
    {
        #region .Ctor
        public AddCompanyGroupPagePresenter(IAddArticlePageView view, ContentService contentService)
            : base(view, contentService) { }
        #endregion

        #region Members
        public override string PageUrlPattern
        {
            get { return "/CompanyGroup.aspx?Id={0}"; }
        }
        #endregion
    }
}
