using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public class EditIdeaItemPagePresenter : StaticPagePresenter, IEditIdeaItemPagePresenter
    {
        #region Fields
        private string[] _categories = new string[] { "Детский дом", "Инвалиды", "Пожилые люди", "Пропаганда ЗОЖ",
            "Творчество", "Экология", "Другое" };
        #endregion

        #region .Ctor
        public EditIdeaItemPagePresenter(IEditIdeaItemPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IEditIdeaItemPageView View
        {
            get { return (IEditIdeaItemPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.CurrentIdea = GetCurrentIdea();
            View.CurrentSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
            View.CategoryList = GetCategoryList();
        }

        public string SaveIdeaItem(string ideaId, string ideaTitle, string ideaAbstract, string ideaText, string ideaKeywords,
            string ideaDescription, string ideaEditor, bool ideaIsActive, string ideaCategory, string nodeSortOrder,
            bool nodeDisplayOnMainMenu, bool nodeDisplayOnSideMenu)
        {
            SaveIdeaRequest request = new SaveIdeaRequest()
            {
                Abstract = ideaAbstract,
                Description = ideaDescription,
                Editor = ideaEditor,
                Id = ideaId,
                IsActive = ideaIsActive,
                Keywords = ideaKeywords,
                Text = ideaText,
                Title = ideaTitle,
                Category = ideaCategory,
                DisplayOnMainMenu = nodeDisplayOnMainMenu,
                DisplayOnSideMenu = nodeDisplayOnSideMenu,
                SortOrder = nodeSortOrder
            };
            SaveIdeaResponse response = _contentService.SaveIdea(request);

            return response.IdeaUrl;
        }

        private SiteNodeView GetCurrentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.Id, All = false };
            return _contentService.FindNode(request).NodeFound;
        }

        private IdeaView GetCurrentIdea()
        {
            FindIdeaRequest request = new FindIdeaRequest() { Id = View.Id };
            return _contentService.FindIdea(request).IdeaFound;
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
