using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public class AddNewsItemPagePresenter : StaticPagePresenter, IAddNewsItemPagePresenter
    {
        #region .Ctor
        public AddNewsItemPagePresenter(IAddNewsItemPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IAddNewsItemPageView View
        {
            get { return (IAddNewsItemPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.ParentSiteNode = GetParentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
        }

        public string CreateNewsItem(string newsTitle, string newsAbstract, string newsText, string newsKeywords,
            string newsDescription, string newsEditor, bool newsIsActive, string newsPublishedDate, string nodeSortOrder,
            bool nodeDisplayOnMainMenu, string nodeParentId, bool nodeDisplayOnSideMenu)
        {
            AddNewsRequest request = new AddNewsRequest()
            {
                Abstract = newsAbstract,
                CreatedBy = newsEditor,
                Description = newsDescription,
                IsActive = newsIsActive,
                Keywords = newsKeywords,
                ParentId = View.ParentId,
                Text = newsText,
                Title = newsTitle,
                PublishedDate = newsPublishedDate,
                DisplayOnMainMenu = nodeDisplayOnMainMenu,
                DisplayOnSideMenu = nodeDisplayOnSideMenu,
                ParentNodeId = nodeParentId,
                SortOrder = nodeSortOrder,
                UrlPattern = "/NewsItem.aspx?Id={0}"
            };
            AddNewsResponse response = _contentService.AddNews(request);

            return response.NewsUrl;
        }

        private SiteNodeView GetParentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.ParentId, All = false };
            return _contentService.FindNode(request).NodeFound;
        }
        #endregion
    }
}
