using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Model;
using System.Data.SqlClient;
using System.Data;

namespace SharpCMS.Repository.SqlServer
{
    public class SqlArticleProvider : ArticleProvider
    {
        public SqlArticleProvider(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public override void Add(Article article)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SharpCMS_Articles_AddArticle", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Abstract", SqlDbType.NVarChar).Value = article.Abstract;
                cmd.Parameters.Add("@Created", SqlDbType.DateTime).Value = article.Created;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = article.CreatedBy;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = article.Description;
                cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = article.Id;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = article.IsActive;
                cmd.Parameters.Add("@Keywords", SqlDbType.NVarChar).Value = article.Keywords;
                cmd.Parameters.Add("@ParentId", SqlDbType.UniqueIdentifier).Value = article.ParentId;
                cmd.Parameters.Add("@Text", SqlDbType.NVarChar).Value = article.Text;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = article.Title;
                cmd.Parameters.Add("@Updated", SqlDbType.DateTime).Value = article.Updated;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = article.UpdatedBy;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
            }
        }

        public override void Remove(Guid articleId)
        {
            //TODO: Implement method
        }

        public override void Save(Article article)
        {
            //TODO: Implement method
        }

        public override Article FindBy(Guid Id, bool showInactive)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SharpCMS_Articles_GetArticleByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetArticleFromReader(reader, true);
                else
                    return null;
            }
        }

        public override IEnumerable<Article> FindChildArticles(Guid Id, bool showInactive)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SharpCMS_Articles_GetChildArticles", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ParentId", SqlDbType.UniqueIdentifier).Value = Id;
                cn.Open();
                return GetArticleCollectionFromReader(ExecuteReader(cmd), true);
            }
        }
    }
}
