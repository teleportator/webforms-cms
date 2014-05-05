using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Model;

namespace SharpCMS.Repository.Stub
{
    public class StubArticleRepository : IArticleRepository
    {
        public void Add(Article article)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid articleId)
        {
            throw new NotImplementedException();
        }

        public void Save(Article article)
        {
            throw new NotImplementedException();
        }

        public Article FindBy(Guid id, bool showInactive)
        {
            return DataContext.Articles.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Article> FindChildArticles(Guid id, bool showInactive)
        {
            return DataContext.Articles.Where(a => a.ParentId == id);
        }
    }
}
