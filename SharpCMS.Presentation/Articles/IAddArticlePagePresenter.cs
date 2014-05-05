using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public interface IAddArticlePagePresenter
    {
        void Display();
        string CreateArticle(string articleTitle, string articleAbstract, string articleText, string articleKeywords,
            string articleDescription, string articleCreatedBy, bool articleIsActive, bool nodeDisplayOnMainMenu,
            bool nodeDisplayOnSideMenu, string nodeParentId, string nodeSortOrder);
    }
}
