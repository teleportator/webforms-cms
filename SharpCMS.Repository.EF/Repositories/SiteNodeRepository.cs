using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Model;
using SharpCMS.Infrastructure;

namespace SharpCMS.Repository.EF.Repositories
{
    public class SiteNodeRepository : Repository<SiteNode, Guid>, ISiteNodeRepository
    {
        #region .Ctor
        public SiteNodeRepository(IUnitOfWork uow)
            : base(uow)
        { }
        #endregion

        #region Methods
        public override IQueryable<SiteNode> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().SiteNodes;
        }

        public override string GetEntitySetName()
        {
            return "SiteNodes";
        }

        public override SiteNode FindBy(Guid Id)
        {
            return GetObjectSet().FirstOrDefault<SiteNode>(s => s.Id == Id);
        }
        #endregion
    }
}
