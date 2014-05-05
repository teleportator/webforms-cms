using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Model;
using System.Data;

namespace SharpCMS.Repository
{
    public abstract class SiteNodeProvider : DataAccess, ISiteNodeRepository
    {
        public abstract void Add(SiteNode node);
        public abstract void Remove(Guid nodeId);
        public abstract IEnumerable<SiteNode> GetAllNodes();
        public abstract void Save(SiteNode node);

        protected virtual IEnumerable<SiteNode> GetSiteNodeCollectionFromReader(IDataReader reader)
        {
            List<SiteNode> siteNodes = new List<SiteNode>();
            while (reader.Read())
                siteNodes.Add(GetSiteNodeFromReader(reader));
            return siteNodes;
        }

        protected virtual SiteNode GetSiteNodeFromReader(IDataReader reader)
        {
            SiteNode siteNode = new SiteNode()
            {
                Id = (Guid)reader["Id"],
                ItemId = (Guid)reader["ItemId"],
                DisplayOnMainMenu = (bool)reader["DisplayOnMainMenu"],
                DisplayOnSideMenu = (bool)reader["DisplayOnSideMenu"],
                ParentId = (Guid)reader["ParentId"],
                SortOrder = (int)reader["SortOrder"],
                Title = reader["Title"].ToString(),
                Url = reader["Url"].ToString()
            };

            return siteNode;
        }
    }
}
