using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;
using SharpCMS.Model;

namespace SharpCMS.Service.Mappers
{
    public static class ArticleExtensions
    {
        public static ArticleView ConvertToArticleView(this Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException();
            }
            return new ArticleView()
            {
                Id = article.Id.ToString(),
                Title = article.Title,
                ParentId = article.ParentId.ToString(),
                Abstract = article.Abstract,
                Created = article.Created.ToString(),
                CreatedBy = article.CreatedBy,
                Description = article.Description,
                IsActive = article.IsActive,
                Keywords = article.Keywords,
                Text = article.Text,
                Updated = article.Updated.ToString(),
                UpdatedBy = article.UpdatedBy
            };
        }

        public static IEnumerable<ArticleView> ConvertToArticleViewCollection(this IEnumerable<Article> articles)
        {
            List<ArticleView> articleViewCollection = new List<ArticleView>();
            foreach (Article article in articles)
            {
                articleViewCollection.Add(article.ConvertToArticleView());
            }
            return articleViewCollection;
        }
    }
}
