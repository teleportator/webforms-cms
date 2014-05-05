using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Presentation
{
    public interface IAddNewsItemPagePresenter
    {
        void Display();
        string CreateNewsItem(string newsTitle, string newsAbstract, string newsText, string newsKeywords,
            string newsDescription, string newsEditor, bool newsIsActive, string newsPublishedDate, string nodeSortOrder,
            bool nodeDisplayOnMainMenu, string nodeParentId, bool nodeDisplayOnSideMenu);
    }
}
