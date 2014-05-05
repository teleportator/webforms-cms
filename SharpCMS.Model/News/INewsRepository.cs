using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Model
{
    public interface INewsRepository
    {
        void Add(News news);
        void Remove(News news);
        void Save(News news);

        News FindBy(Guid Id);
        IEnumerable<News> FindAll();

        IEnumerable<News> FindAll(Guid newsGroupId);
        IEnumerable<News> FindAllPublished(Guid newsGroupId);
        IEnumerable<News> FindLatestPublished(Guid newsGroupId, int count);
    }
}
