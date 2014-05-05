using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Model;
using SharpCMS.Infrastructure;

namespace SharpCMS.Repository.EF.Repositories
{
    public class ArticleRepository : Repository<Article, Guid>, IArticleRepository
    {
        #region .Ctor
        public ArticleRepository(IUnitOfWork uow)
            : base(uow)
        { }
        #endregion

        #region Methods
        public override IQueryable<Article> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().Articles;
        }

        public override string GetEntitySetName()
        {
            return "Articles";
        }

        public override Article FindBy(Guid id)
        {
            return GetObjectSet().FirstOrDefault<Article>(a => a.Id == id);
        }

        public IEnumerable<Article> FindAll(Guid parentId)
        {
            return GetObjectSet().Where(a => a.ParentId == parentId).ToList();
        }

        public IEnumerable<Article> FindAllPublished(Guid parentId)
        {
            return GetObjectSet().Where(a => (a.ParentId == parentId) && (a.IsActive == true)).ToList();
        }
        #endregion
    }
}
