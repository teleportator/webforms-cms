using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Presentation
{
    public interface IAddIdeaItemPagePresenter
    {
        void Display();
        string CreateIdeaItem(string ideaTitle, string ideaAbstract, string ideaText, string ideaKeywords,
            string ideaDescription, string ideaEditor, bool ideaIsActive, string ideaCategory, string ideaRating,
            string nodeSortOrder, bool nodeDisplayOnMainMenu, string nodeParentId, bool nodeDisplayOnSideMenu);
    }
}
