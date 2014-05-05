using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public class EditNewsItemPagePresenter : StaticPagePresenter, IEditNewsItemPagePresenter
    {
        #region .Ctor
        public EditNewsItemPagePresenter(IEditNewsItemPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IEditNewsItemPageView View
        {
            get { return (IEditNewsItemPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.CurrentNews = GetCurrentNews();
            View.CurrentSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
        }

        public string SaveNewsItem(string newsId, string newsTitle, string newsAbstract, string newsText, string newsKeywords,
            string newsDescription, string newsEditor, bool newsIsActive, string newsPublishedDate, string nodeSortOrder,
            bool nodeDisplayOnMainMenu, bool nodeDisplayOnSideMenu)
        {
            SaveNewsRequest request = new SaveNewsRequest()
            {
                Abstract = newsAbstract,
                Description = newsDescription,
                Editor = newsEditor,
                Id = newsId,
                IsActive = newsIsActive,
                Keywords = newsKeywords,
                Text = newsText,
                Title = newsTitle,
                PublishedDate = newsPublishedDate,
                DisplayOnMainMenu = nodeDisplayOnMainMenu,
                DisplayOnSideMenu = nodeDisplayOnSideMenu,
                SortOrder = nodeSortOrder
            };
            SaveNewsResponse response = _contentService.SaveNews(request);

            return response.NewsUrl;
        }

        private SiteNodeView GetCurrentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.Id, All = false };
            return _contentService.FindNode(request).NodeFound;
        }

        private NewsView GetCurrentNews()
        {
            FindNewsRequest request = new FindNewsRequest() { Id = View.Id };
            return _contentService.FindNews(request).NewsFound;
        }
        #endregion
    }
}
