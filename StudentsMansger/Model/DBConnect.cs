using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsMansger.Model
{
    class DBConnect
    {
        public static MySqlConnection
            GetDbConnection(string server, int port, string database, string username, string password)
        {
            string connectString = "Server=" + server + ";Database=" + database + ";port=" + port + ";Username=" + username + ";password=" + password;
            MySqlConnection conn = new MySqlConnection(connectString);
            return conn;
        }
    }
}
