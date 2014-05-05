using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Model;
using SharpCMS.Infrastructure;

namespace SharpCMS.Repository.EF.Repositories
{
    public class CompanyRepository : Repository<Company, Guid>, ICompanyRepository
    {
        #region .Ctor
        public CompanyRepository(IUnitOfWork uow)
            : base(uow)
        { }
        #endregion

        #region Methods
        public override IQueryable<Company> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().Companies;
        }

        public override string GetEntitySetName()
        {
            return "Companies";
        }

        public override Company FindBy(Guid Id)
        {
            return GetObjectSet().FirstOrDefault<Company>(c => c.Id == Id);
        }

        public IEnumerable<Company> FindAll(Guid parentId)
        {
            return GetObjectSet().Where(c => c.ParentId == parentId).ToList();
        }

        public IEnumerable<Company> FindAllPublished(Guid parentId)
        {
            return GetObjectSet().Where(c => (c.ParentId == parentId) && (c.IsActive == true)).ToList();
        }
        #endregion
    }
}
