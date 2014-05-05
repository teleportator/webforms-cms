using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;
using SharpCMS.UI.Mvc.Infrastructure;
using SharpCMS.UI.Mvc.Models.Ideas;

namespace SharpCMS.UI.Mvc.Controllers
{
    public class IdeaController : ControllerBase
    {
        private readonly Dictionary<int, string> _categories = new Dictionary<int, string>
                                                                   {
                                                                       {0, "Детский дом"},
                                                                       {1, "Инвалиды"},
                                                                       {2, "Пожилые люди"},
                                                                       {3, "Пропаганда ЗОЖ"},
                                                                       {4, "Творчество"},
                                                                       {5, "Экология"},
                                                                       {6, "Другое"}
                                                                   };

        [Authorize(Roles = "Administrators")]
        public ActionResult Create(Guid id)
        {
            SiteNodeView parentNode = GetSiteNode(id);
            var model = new IdeaCreateModel
                            {
                                Categories = _categories,
                                ParentId = id,
                                ParentUrl = parentNode.Url,
                                ParentTitle = parentNode.Title,
                                Title = "Идея",
                                IsActive = true,
                                SortOrder = 500
                            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrators")]
        public ActionResult Create(Guid id, IdeaCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categories;
                return View(model);
            }

            SiteNodeView parentNode = GetSiteNode(id);
            string url = CreateIdea(id, model.Title, model.Abstract, model.Text, model.Keywords ?? String.Empty,
                                    model.Description ?? String.Empty, User.Identity.Name, model.IsActive,
                                    _categories[model.CategoryId], "0", model.SortOrder, model.DisplayOnMainMenu,
                                    parentNode.Id, model.DisplayOnSideMenu);

            return Redirect(url);
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Delete(Guid id)
        {
            SiteNodeView parentNode = GetSiteNode(id).ParentNode;
            DeleteIdea(id);
            return Redirect(parentNode.Url);
        }

        public ActionResult Display(Guid id)
        {
            IdeaView idea = GetIdea(id);
            var model = new IdeaDisplayModel
                            {
                                Id = id,
                                Created = idea.Created,
                                CreatedBy = idea.CreatedBy,
                                Text = idea.Text,
                                Title = idea.Title
                            };
            return View(model);
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(Guid id)
        {
            SiteNodeView currentNode = GetSiteNode(id);
            IdeaView idea = GetIdea(id);
            var model = new IdeaEditModel
                            {
                                Abstract = idea.Abstract,
                                Categories = _categories,
                                CategoryId = _categories.FirstOrDefault(c => c.Value == idea.Category).Key,
                                CurrentUrl = currentNode.Url,
                                Description = idea.Description,
                                DisplayOnMainMenu = currentNode.DisplayOnMainMenu,
                                DisplayOnSideMenu = currentNode.DisplayOnSideMenu,
                                IsActive = idea.IsActive,
                                Keywords = idea.Keywords,
                                SortOrder = Int32.Parse(currentNode.SortOrder),
                                Text = idea.Text,
                                Title = idea.Title
                            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(Guid id, IdeaEditModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categories;
                return View(model);
            }

            SiteNodeView currentNode = GetSiteNode(id);
            var request = new SaveIdeaRequest
                              {
                                  Abstract = model.Abstract,
                                  Category = _categories[model.CategoryId],
                                  Description = model.Description ?? String.Empty,
                                  DisplayOnMainMenu = model.DisplayOnMainMenu,
                                  DisplayOnSideMenu = model.DisplayOnSideMenu,
                                  Editor = User.Identity.Name,
                                  Id = id.ToString(),
                                  IsActive = model.IsActive,
                                  Keywords = model.Keywords ?? String.Empty,
                                  SortOrder = model.SortOrder.ToString(),
                                  Text = model.Text,
                                  Title = model.Title
                              };
            ContentService.SaveIdea(request);

            return Redirect(currentNode.Url);
        }

        public ActionResult List(Guid id)
        {
            var model = new IdeaListModel
                            {
                                Id = id,
                                Ideas = GetIdeaList(id)
                            };
            return View(model);
        }

        public ActionResult Propose(Guid id)
        {
            var model = new IdeaProposeModel
                            {
                                Categories = _categories
                            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Propose(Guid id, IdeaProposeModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!ModelState.IsValid)
                {
                    model.Categories = _categories;
                    return View(model);
                }

                var findNodesRequest = new FindNodesRequest {ContentItemId = id.ToString(), All = false};
                SiteNodeView parentNode = ContentService.FindNode(findNodesRequest).NodeFound;

                CreateIdea(id, model.Title, model.Abstract, InputDataUtilities.TextAreaHtmlEncode(model.Text),
                           String.Empty,
                           String.Empty, User.Identity.Name, false, _categories[model.CategoryId], "0", 500, false,
                           parentNode.Id, false);

                var ideaCreatedModel = new IdeaSuccessfullyCreatedModel {ParentId = id};
                return View("IdeaCreated", ideaCreatedModel);
            }

            model.Categories = _categories;
            return View(model);
        }

        private string CreateIdea(Guid parentId, string title, string @abstract, string text, string keywords,
                                  string description, string editor, bool isActive, string category, string rating,
                                  int sortOrder, bool displayOnMainMenu, string parentNodeId, bool displayOnSideMenu)
        {
            var request = new AddIdeaRequest
                              {
                                  Abstract = @abstract,
                                  CreatedBy = editor,
                                  Description = description,
                                  IsActive = isActive,
                                  Keywords = keywords,
                                  ParentId = parentId.ToString(),
                                  Text = text,
                                  Title = title,
                                  Category = category,
                                  Rating = rating,
                                  DisplayOnMainMenu = displayOnMainMenu,
                                  DisplayOnSideMenu = displayOnSideMenu,
                                  ParentNodeId = parentNodeId,
                                  SortOrder = sortOrder.ToString(),
                                  UrlPattern = "/idea/display/{0}"
                              };
            AddIdeaResponse response = ContentService.AddIdea(request);

            return response.IdeaUrl;
        }

        private void DeleteIdea(Guid id)
        {
            var request = new DeleteIdeaRequest {Id = id.ToString()};
            ContentService.DeleteIdea(request);
        }

        private IdeaView GetIdea(Guid id)
        {
            var request = new FindIdeaRequest {Id = id.ToString()};
            return ContentService.FindIdea(request).IdeaFound;
        }

        private IEnumerable<IdeaView> GetIdeaList(Guid id)
        {
            var request = new FindIdeasRequest
                              {
                                  ShowInactive = AllowFullAccess,
                                  ParentId = id.ToString()
                              };
            return ContentService.FindIdeas(request).IdeasFound;
        }
    }
}