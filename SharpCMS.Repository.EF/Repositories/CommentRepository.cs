using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Model;
using SharpCMS.Infrastructure;

namespace SharpCMS.Repository.EF.Repositories
{
    public class CommentRepository : Repository<Comment, Guid>, ICommentRepository
    {
        #region .Ctor
        public CommentRepository(IUnitOfWork uow)
            : base(uow) { }
        #endregion

        #region Methods
        public override IQueryable<Comment> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().Comments;
        }

        public override string GetEntitySetName()
        {
            return "Comments";
        }

        public override Comment FindBy(Guid id)
        {
            return GetObjectSet().FirstOrDefault<Comment>(n => n.Id == id);
        }


        public IEnumerable<Comment> FindAll(Guid parentId)
        {
            return GetObjectSet().Where(n => n.ParentId == parentId).ToList();
        }

        public IEnumerable<Comment> FindAllPublished(Guid parentId)
        {
            return GetObjectSet().Where(n => (n.IsActive == true) && (n.ParentId == parentId)).ToList();
        }
        #endregion
    }
}
