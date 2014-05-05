using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Model;
using SharpCMS.Infrastructure;

namespace SharpCMS.Repository.EF.Repositories
{
    public class VacancyRepository : Repository<Vacancy, Guid>, IVacancyRepository
    {
        #region .Ctor
        public VacancyRepository(IUnitOfWork uow)
            : base(uow) { }
        #endregion

        #region Methods
        public override IQueryable<Vacancy> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().Vacancies;
        }

        public override string GetEntitySetName()
        {
            return "Vacancies";
        }

        public override Vacancy FindBy(Guid id)
        {
            return GetObjectSet().FirstOrDefault<Vacancy>(a => a.Id == id);
        }

        public IEnumerable<Vacancy> FindAll(Guid parentId)
        {
            return GetObjectSet().Where(a => a.ParentId == parentId).ToList();
        }

        public IEnumerable<Vacancy> FindAllPublished(Guid parentId)
        {
            return GetObjectSet().Where(a => (a.ParentId == parentId) && (a.IsActive == true)).ToList();
        }
        #endregion
    }
}
