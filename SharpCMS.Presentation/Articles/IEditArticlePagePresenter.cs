using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Presentation
{
    public interface IEditArticlePagePresenter
    {
        void Display();
        string SaveArticle(string articleId, string articleTitle, string articleAbstract, string articleText,
            string articleKeywords, string articleDescription, string articleEditor, bool articleIsActive,
            string nodeSortOrder, bool nodeDisplayOnMainMenu, bool nodeDisplayOnSideMenu);
    }
}
