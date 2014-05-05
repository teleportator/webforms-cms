using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Model;

namespace SharpCMS.Repository.Stub
{
    public class StubSiteNodeRepository : ISiteNodeRepository
    {
        public void Add(SiteNode node)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid nodeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SiteNode> GetAllNodes()
        {
            return DataContext.Nodes;
        }

        public void Save(SiteNode node)
        {
            throw new NotImplementedException();
        }
    }
}
