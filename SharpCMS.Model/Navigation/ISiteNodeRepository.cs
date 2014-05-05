using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Model
{
    public interface ISiteNodeRepository
    {
        void Add(SiteNode node);
        void Remove(SiteNode node);
        void Save(SiteNode node);

        SiteNode FindBy(Guid Id);
        IEnumerable<SiteNode> FindAll();
    }
}
