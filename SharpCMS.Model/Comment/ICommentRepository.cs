using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Model
{
    public interface ICommentRepository
    {
        void Add(Comment comment);
        void Remove(Comment comment);
        void Save(Comment comment);

        Comment FindBy(Guid Id);
        IEnumerable<Comment> FindAll();

        IEnumerable<Comment> FindAll(Guid parentId);
        IEnumerable<Comment> FindAllPublished(Guid parentId);
    }
}
