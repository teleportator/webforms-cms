using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;

namespace SharpCMS.Presentation
{
    public class AddVacancyGroupPagePresenter : AddArticlePageBasePresenter, IAddArticlePagePresenter
    {
        #region .Ctor
        public AddVacancyGroupPagePresenter(IAddArticlePageView view, ContentService contentService)
            : base(view, contentService) { }
        #endregion

        #region Members
        public override string PageUrlPattern
        {
            get { return "/VacancyGroup.aspx?Id={0}"; }
        }
        #endregion
    }
}
