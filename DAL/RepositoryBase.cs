using System;
using System.Data.Common;
using System.Data.SqlClient;
using Dapper;

namespace DAL
{
    public class RepositoryBase
    {
        protected DbConnection GetDatabaseConnection()
        {
            return new SqlConnection("");
        }
    }
}
