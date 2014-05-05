using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Model
{
    public interface IVacancyRepository
    {
        void Add(Vacancy vacancy);
        void Remove(Vacancy vacancy);
        void Save(Vacancy vacancy);

        Vacancy FindBy(Guid Id);
        IEnumerable<Vacancy> FindAll();

        IEnumerable<Vacancy> FindAll(Guid parentId);
        IEnumerable<Vacancy> FindAllPublished(Guid parentId);
    }
}
