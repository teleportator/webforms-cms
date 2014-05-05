using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

namespace SharpCMS.Repository
{
    public abstract class DataAccess
    {
        protected string ConnectionString { get; set; }

        protected int ExecuteNonQuery(DbCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        protected IDataReader ExecuteReader(DbCommand cmd)
        {
            return ExecuteReader(cmd, CommandBehavior.Default);
        }

        protected IDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior)
        {
            return cmd.ExecuteReader(behavior);
        }

        protected object ExecuteScalar(DbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }
    }
}
