using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public class AddIdeaItemPagePresenter : StaticPagePresenter, IAddIdeaItemPagePresenter
    {
        #region Fields
        private string[] _categories = new string[] { "Детский дом", "Инвалиды", "Пожилые люди", "Пропаганда ЗОЖ",
            "Творчество", "Экология", "Другое" };
        #endregion

        #region .Ctor
        public AddIdeaItemPagePresenter(IAddIdeaItemPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IAddIdeaItemPageView View
        {
            get { return (IAddIdeaItemPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.ParentSiteNode = GetParentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
            View.CategoryList = GetCategoryList();
        }

        public string CreateIdeaItem(string newsTitle, string newsAbstract, string newsText, string newsKeywords,
            string newsDescription, string newsEditor, bool newsIsActive, string ideaCategory, string ideaRating,
            string nodeSortOrder, bool nodeDisplayOnMainMenu, string nodeParentId, bool nodeDisplayOnSideMenu)
        {
            AddIdeaRequest request = new AddIdeaRequest()
            {
                Abstract = newsAbstract,
                CreatedBy = newsEditor,
                Description = newsDescription,
                IsActive = newsIsActive,
                Keywords = newsKeywords,
                ParentId = View.ParentId,
                Text = newsText,
                Title = newsTitle,
                Category = ideaCategory,
                Rating = ideaRating,
                DisplayOnMainMenu = nodeDisplayOnMainMenu,
                DisplayOnSideMenu = nodeDisplayOnSideMenu,
                ParentNodeId = nodeParentId,
                SortOrder = nodeSortOrder,
                UrlPattern = "/IdeaItem.aspx?Id={0}"
            };
            AddIdeaResponse response = _contentService.AddIdea(request);

            return response.IdeaUrl;
        }

        private SiteNodeView GetParentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.ParentId, All = false };
            return _contentService.FindNode(request).NodeFound;
        }

        private IDictionary<int, string> GetCategoryList()
        {
            Dictionary<int, string> categories = new Dictionary<int, string>();
            for (int i = 0; i < _categories.Count(); i++)
            {
                categories.Add(i, _categories[i]);
            }
            return categories;
        }
        #endregion
    }
}
