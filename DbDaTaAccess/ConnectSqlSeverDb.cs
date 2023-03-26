using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDaTaAccess
{
    public static class ConnectSqlSeverDb
    {
        public static  SqlConnection GetSqlConnection()
        {
            SqlConnection conn = null;
            var connectString = "Server=NWS-007;Database=ThayQuan1_2;User Id=sa;Password=123456";
            conn = new SqlConnection(connectString);
            if(conn.State==System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
    }
}
