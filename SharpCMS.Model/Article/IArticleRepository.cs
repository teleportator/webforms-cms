using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Model
{
    public interface IArticleRepository
    {
        void Add(Article article);
        void Remove(Article article);
        void Save(Article article);

        Article FindBy(Guid Id);
        IEnumerable<Article> FindAll();

        IEnumerable<Article> FindAll(Guid parentId);
        IEnumerable<Article> FindAllPublished(Guid parentId);
    }
}
