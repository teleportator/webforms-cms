using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Model
{
    public interface ICompanyRepository
    {
        void Add(Company company);
        void Remove(Company company);
        void Save(Company company);

        Company FindBy(Guid Id);
        IEnumerable<Company> FindAll();

        IEnumerable<Company> FindAll(Guid groupId);
        IEnumerable<Company> FindAllPublished(Guid groupId);
    }
}
