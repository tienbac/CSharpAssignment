using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsMansger.Model
{
    class DBUtils
    {
        public static MySqlConnection GetDbConnection()
        {
            string server = "localhost";
            int port = 3306;
            string database = "aptech_csharp";
            string username = "root";
            string password = "";

            return DBConnect.GetDbConnection(server, port, database, username, password);
        }
    }
}
