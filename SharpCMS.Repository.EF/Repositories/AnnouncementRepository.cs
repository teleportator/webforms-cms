using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Model;
using SharpCMS.Infrastructure;

namespace SharpCMS.Repository.EF.Repositories
{
    public class AnnouncementRepository : Repository<Announcement, Guid>, IAnnouncementRepository
    {
        #region .Ctor
        public AnnouncementRepository(IUnitOfWork uow)
            : base(uow) { }
        #endregion

        #region Methods
        public override IQueryable<Announcement> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().Announcements;
        }

        public override string GetEntitySetName()
        {
            return "Announcements";
        }

        public override Announcement FindBy(Guid id)
        {
            return GetObjectSet().FirstOrDefault<Announcement>(a => a.Id == id);
        }

        public IEnumerable<Announcement> FindAll(Guid parentId)
        {
            return GetObjectSet().Where(a => a.ParentId == parentId).ToList();
        }

        public IEnumerable<Announcement> FindAllPublished(Guid parentId)
        {
            return GetObjectSet().Where(a => (a.ParentId == parentId) && (a.IsActive == true)).ToList();
        }
        #endregion
    }
}
