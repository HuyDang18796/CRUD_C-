using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp3
{
    public class ConnectionDb
    {
        public SqlConnection GetConnection()
        {
            string connectionString = "Data source = localhost ; Initial Catalog = DbTest; User = sa ; password = sa;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            return sqlConnection;
        }
    }
}
