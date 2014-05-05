using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Model;
using SharpCMS.Infrastructure;

namespace SharpCMS.Repository.EF.Repositories
{
    public class IdeaRepository : Repository<Idea, Guid>, IIdeaRepository
    {
        #region .Ctor
        public IdeaRepository(IUnitOfWork uow)
            : base(uow) { }
        #endregion

        #region Methods
        public override IQueryable<Idea> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().Ideas;
        }

        public override string GetEntitySetName()
        {
            return "Ideas";
        }

        public override Idea FindBy(Guid id)
        {
            return GetObjectSet().FirstOrDefault<Idea>(a => a.Id == id);
        }

        public IEnumerable<Idea> FindAll(Guid parentId)
        {
            return GetObjectSet().Where(a => a.ParentId == parentId).ToList();
        }

        public IEnumerable<Idea> FindAllPublished(Guid parentId)
        {
            return GetObjectSet().Where(a => (a.ParentId == parentId) && (a.IsActive == true)).ToList();
        }
        #endregion
    }
}
