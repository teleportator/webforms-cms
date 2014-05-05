using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Model
{
    public interface IAnnouncementRepository
    {
        void Add(Announcement announcement);
        void Remove(Announcement announcement);
        void Save(Announcement announcement);

        Announcement FindBy(Guid Id);
        IEnumerable<Announcement> FindAll();

        IEnumerable<Announcement> FindAll(Guid parentId);
        IEnumerable<Announcement> FindAllPublished(Guid parentId);
    }
}
