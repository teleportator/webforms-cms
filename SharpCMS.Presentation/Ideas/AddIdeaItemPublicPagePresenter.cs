using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public class AddIdeaItemPublicPagePresenter : StaticPagePresenter, IAddIdeaItemPublicPagePresenter
    {
        #region Fields
        private string[] _categories = new string[] { "Детский дом", "Инвалиды", "Пожилые люди", "Пропаганда ЗОЖ",
            "Творчество", "Экология", "Другое" };
        #endregion

        #region .Ctor
        public AddIdeaItemPublicPagePresenter(IAddIdeaItemPublicPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IAddIdeaItemPublicPageView View
        {
            get { return (IAddIdeaItemPublicPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.ParentSiteNode = GetParentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
            View.CategoryList = GetCategoryList();
        }

        public string CreateIdeaItem(string ideaTitle, string ideaAbstract, string ideaText, string ideaEditor, string ideaCategory, string nodeParentId)
        {
            AddIdeaRequest request = new AddIdeaRequest()
            {
                Abstract = ideaAbstract.Trim(),
                CreatedBy = ideaEditor,
                Description = "",
                IsActive = false,
                Keywords = "",
                ParentId = View.ParentId,
                Text = InputDataUtilities.TextAreaHtmlEncode(ideaText.Trim()),
                Title = ideaTitle.Trim(),
                Category = ideaCategory,
                Rating = "0",
                DisplayOnMainMenu = false,
                DisplayOnSideMenu = false,
                ParentNodeId = nodeParentId,
                SortOrder = "500",
                UrlPattern = "/IdeaItem.aspx?Id={0}"
            };
            AddIdeaResponse response = _contentService.AddIdea(request);

            return response.IdeaUrl;
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

        private SiteNodeView GetParentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.ParentId, All = false };
            return _contentService.FindNode(request).NodeFound;
        }
        #endregion
    }
}
