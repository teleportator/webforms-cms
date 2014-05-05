using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Model;
using System.Data.SqlClient;
using System.Data;

namespace SharpCMS.Repository.SqlServer
{
    public class SqlSiteNodeProvider : SiteNodeProvider
    {
        public SqlSiteNodeProvider(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public override void Add(SiteNode node)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SharpCMS_SiteNodes_AddSiteNode", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = node.Id;
                cmd.Parameters.Add("@ParentId", SqlDbType.UniqueIdentifier).Value = node.ParentId;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = node.Title;
                cmd.Parameters.Add("@DisplayOnMainMenu", SqlDbType.Bit).Value = node.DisplayOnMainMenu;
                cmd.Parameters.Add("@DisplayOnSideMenu", SqlDbType.Bit).Value = node.DisplayOnSideMenu;
                cmd.Parameters.Add("@ItemId", SqlDbType.UniqueIdentifier).Value = node.ItemId;
                cmd.Parameters.Add("@SortOrder", SqlDbType.Int).Value = node.SortOrder;
                cmd.Parameters.Add("@Url", SqlDbType.NVarChar).Value = node.Url;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
            }
        }

        public override void Remove(Guid nodeId)
        {
            //TODO: Implement method
        }

        public override IEnumerable<SiteNode> GetAllNodes()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SharpCMS_SiteNodes_GetAllSiteNodes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetSiteNodeCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override void Save(SiteNode node)
        {
            //TODO: Implement method
        }
    }
}
