using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;
using SharpCMS.UI.Mvc.Models.News;

namespace SharpCMS.UI.Mvc.Controllers
{
    public class NewsController : ControllerBase
    {
        [Authorize(Roles = "Administrators")]
        public ActionResult Create(Guid id)
        {
            SiteNodeView parentNode = GetSiteNode(id);
            var model = new NewsCreateModel
                            {
                                ParentUrl = parentNode.Url,
                                ParentTitle = parentNode.Title,
                                Title = "Новость",
                                PublishDate = DateTime.Now.Date,
                                IsActive = true,
                                SortOrder = 500
                            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrators")]
        public ActionResult Create(Guid id, NewsCreateModel model)
        {
            SiteNodeView parentNode = GetSiteNode(id);
            if (!ModelState.IsValid)
            {
                model.ParentUrl = parentNode.Url;
                model.ParentTitle = parentNode.Title;
                return View(model);
            }

            string url = CreateNews(id, model.Title, model.Abstract, model.Text, model.Keywords ?? String.Empty,
                                    model.Description ?? String.Empty, User.Identity.Name, model.IsActive,
                                    model.PublishDate, model.SortOrder, model.DisplayOnMainMenu, parentNode.Id,
                                    model.DisplayOnSideMenu);

            return Redirect(url);
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Delete(Guid id)
        {
            SiteNodeView parentNode = GetSiteNode(id).ParentNode;
            DeleteNews(id);
            return Redirect(parentNode.Url);
        }

        public ActionResult Display(Guid id)
        {
            NewsView newsItem = GetNewsItem(id);
            var model = new NewsDisplayModel
                            {
                                Id = id,
                                NewsTitle = newsItem.Title,
                                NewsText = newsItem.Text,
                                NewsPublishedDate = newsItem.PublishedDate
                            };

            return View(model);
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(Guid id)
        {
            SiteNodeView currentNode = GetSiteNode(id);
            NewsView currentNews = GetNewsItem(id);
            var model = new NewsEditModel
                            {
                                Abstract = currentNews.Abstract,
                                CurrentUrl = currentNode.Url,
                                Description = currentNews.Description,
                                DisplayOnMainMenu = currentNode.DisplayOnMainMenu,
                                DisplayOnSideMenu = currentNode.DisplayOnSideMenu,
                                IsActive = currentNews.IsActive,
                                Keywords = currentNews.Keywords,
                                PublishDate = DateTime.Parse(currentNews.PublishedDate),
                                SortOrder = Int32.Parse(currentNode.SortOrder),
                                Text = currentNews.Text,
                                Title = currentNews.Title
                            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(Guid id, NewsEditModel model)
        {
            SiteNodeView currentNode = GetSiteNode(id);
            if (!ModelState.IsValid)
            {
                model.CurrentUrl = currentNode.Url;
                return View(model);
            }

            SaveNews(id, model.Title, model.Abstract, model.Text, model.Keywords ?? String.Empty,
                     model.Description ?? String.Empty, User.Identity.Name, model.IsActive, model.PublishDate,
                     model.SortOrder, model.DisplayOnMainMenu, model.DisplayOnSideMenu);

            return Redirect(currentNode.Url);
        }

        public ActionResult List(Guid id)
        {
            var model = new NewsListModel
                            {
                                Id = id,
                                News = GetNewsList(id)
                            };
            return View(model);
        }

        private string CreateNews(Guid parentId, string title, string @abstract, string text, string keywords,
                                  string description, string editor, bool isActive, DateTime publishedDate,
                                  int sortOrder,
                                  bool displayOnMainMenu, string parentNodeId, bool displayOnSideMenu)
        {
            var request = new AddNewsRequest
                              {
                                  Abstract = @abstract,
                                  CreatedBy = editor,
                                  Description = description,
                                  IsActive = isActive,
                                  Keywords = keywords,
                                  ParentId = parentId.ToString(),
                                  Text = text,
                                  Title = title,
                                  PublishedDate = publishedDate.ToShortDateString(),
                                  DisplayOnMainMenu = displayOnMainMenu,
                                  DisplayOnSideMenu = displayOnSideMenu,
                                  ParentNodeId = parentNodeId,
                                  SortOrder = sortOrder.ToString(),
                                  UrlPattern = "/news/display/{0}"
                              };
            AddNewsResponse response = ContentService.AddNews(request);

            return response.NewsUrl;
        }

        private void DeleteNews(Guid id)
        {
            var deleteNewsRequest = new DeleteNewsRequest {Id = id.ToString()};
            ContentService.DeleteNews(deleteNewsRequest);
        }

        private NewsView GetNewsItem(Guid id)
        {
            var request = new FindNewsRequest {Id = id.ToString()};
            return ContentService.FindNews(request).NewsFound;
        }

        private IEnumerable<NewsView> GetNewsList(Guid id)
        {
            var request = new FindNewsCollectionRequest
                              {
                                  ShowUnpublished = AllowFullAccess,
                                  ParentId = id.ToString()
                              };
            return ContentService.FindNewsCollection(request).NewsFound;
        }

        private string SaveNews(Guid id, string title, string @abstract, string text, string keywords,
                                string description, string editor, bool isActive, DateTime publishedDate, int sortOrder,
                                bool displayOnMainMenu, bool displayOnSideMenu)
        {
            var request = new SaveNewsRequest
                              {
                                  Abstract = @abstract,
                                  Description = description,
                                  Editor = editor,
                                  Id = id.ToString(),
                                  IsActive = isActive,
                                  Keywords = keywords,
                                  Text = text,
                                  Title = title,
                                  PublishedDate = publishedDate.ToShortDateString(),
                                  DisplayOnMainMenu = displayOnMainMenu,
                                  DisplayOnSideMenu = displayOnSideMenu,
                                  SortOrder = sortOrder.ToString()
                              };
            SaveNewsResponse response = ContentService.SaveNews(request);

            return response.NewsUrl;
        }
    }
}