using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Model
{
    public interface IIdeaRepository
    {
        void Add(Idea idea);
        void Remove(Idea idea);
        void Save(Idea idea);

        Idea FindBy(Guid Id);
        IEnumerable<Idea> FindAll();

        IEnumerable<Idea> FindAll(Guid parentId);
        IEnumerable<Idea> FindAllPublished(Guid parentId);
    }
}
