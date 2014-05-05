using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;
using SharpCMS.Model;

namespace SharpCMS.Service.Mappers
{
    public static class NewsExtensions
    {
        public static NewsView ConvertToNewsView(this News news)
        {
            if (news == null)
            {
                throw new ArgumentNullException();
            }
            return new NewsView()
            {
                Id = news.Id.ToString(),
                Title = news.Title,
                ParentId = news.ParentId.ToString(),
                Abstract = news.Abstract,
                Created = news.Created.ToString(),
                CreatedBy = news.CreatedBy,
                Description = news.Description,
                IsActive = news.IsActive,
                Keywords = news.Keywords,
                Text = news.Text,
                Updated = news.Updated.ToString(),
                UpdatedBy = news.UpdatedBy,
                PublishedDate = news.PublishedDate.ToString("dd/MM/yyyy")
            };
        }

        public static IEnumerable<NewsView> ConvertToNewsViewCollection(this IEnumerable<News> newsList)
        {
            List<NewsView> newsViews = new List<NewsView>();
            foreach (News news in newsList)
            {
                newsViews.Add(news.ConvertToNewsView());
            }
            return newsViews;
        }
    }
}
