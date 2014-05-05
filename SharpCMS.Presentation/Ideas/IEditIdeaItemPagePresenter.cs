using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Presentation
{
    public interface IEditIdeaItemPagePresenter
    {
        void Display();
        string SaveIdeaItem(string ideaId, string ideaTitle, string ideaAbstract, string ideaText, string ideaKeywords,
            string ideaDescription, string ideaEditor, bool ideaIsActive, string ideaCategory, string nodeSortOrder,
            bool nodeDisplayOnMainMenu, bool nodeDisplayOnSideMenu);
    }
}
