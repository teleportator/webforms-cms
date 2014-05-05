using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Model;
using SharpCMS.Infrastructure;

namespace SharpCMS.Repository.EF.Repositories
{
    public class NewsRepository : Repository<News, Guid>, INewsRepository
    {
        #region .Ctor
        public NewsRepository(IUnitOfWork uow)
            : base(uow)
        { }
        #endregion

        #region Methods
        public override IQueryable<News> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().NewsCollection;
        }

        public override string GetEntitySetName()
        {
            return "NewsCollection";
        }

        public override News FindBy(Guid Id)
        {
            return GetObjectSet().FirstOrDefault<News>(n => n.Id == Id);
        }


        public IEnumerable<News> FindAll(Guid newsGroupId)
        {
            return GetObjectSet().Where(n => n.ParentId == newsGroupId).ToList();
        }

        public IEnumerable<News> FindAllPublished(Guid newsGroupId)
        {
            return GetObjectSet().Where(n => (n.PublishedDate < DateTime.Now) && (n.IsActive == true) &&
                (n.ParentId == newsGroupId)).ToList();
        }

        public IEnumerable<News> FindLatestPublished(Guid newsGroupId, int count)
        {
            return GetObjectSet().Where(n => (n.PublishedDate < DateTime.Now) && (n.IsActive == true) &&
                (n.ParentId == newsGroupId)).Take(count).ToList();
        }
        #endregion
    }
}
