using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Model;
using System.Data;

namespace SharpCMS.Repository
{
    public abstract class ArticleProvider : DataAccess, IArticleRepository
    {
        public abstract void Add(Article article);
        public abstract void Remove(Guid articleId);
        public abstract void Save(Article article);
        public abstract Article FindBy(Guid Id, bool showInactive);
        public abstract IEnumerable<Article> FindChildArticles(Guid Id, bool showInactive);

        protected virtual IEnumerable<Article> GetArticleCollectionFromReader(IDataReader reader)
        {
            return GetArticleCollectionFromReader(reader, true);
        }
        protected virtual IEnumerable<Article> GetArticleCollectionFromReader(IDataReader reader, bool readBody)
        {
            List<Article> articles = new List<Article>();
            while (reader.Read())
                articles.Add(GetArticleFromReader(reader, readBody));
            return articles;
        }

        protected virtual Article GetArticleFromReader(IDataReader reader)
        {
            return GetArticleFromReader(reader, false);
        }
        protected virtual Article GetArticleFromReader(IDataReader reader, bool readBody)
        {
            Article article = new Article()
            {
               Id = (Guid)reader["Id"],
               Created = (DateTime)reader["Created"],
               CreatedBy = reader["CreatedBy"].ToString(),
               Description = reader["Description"].ToString(),
               Abstract = reader["Abstract"].ToString(),
               IsActive = (bool)reader["IsActive"],
               Keywords = reader["Keywords"].ToString(),
               ParentId = (Guid)reader["ParentId"],
               Title = reader["Title"].ToString(),
               Updated = (DateTime)reader["Updated"],
               UpdatedBy = reader["UpdatedBy"].ToString()
            };

            if (readBody)
                article.Text = reader["Text"].ToString();

            return article;
        }
    }
}
