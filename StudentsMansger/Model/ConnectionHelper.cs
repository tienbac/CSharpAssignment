using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsMansger.Model
{
    class ConnectionHelper
    {
        private static MySqlConnection connection;
        public static MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                try
                {
                    //Console.WriteLine("Getting Connection ....");
                    connection = DBUtils.GetDbConnection();
                    //Console.WriteLine("Openning Connecttion ...");
                    connection.Open();
                    //Console.WriteLine("Connection Successful !!!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
            }
            return connection;
        }
    }
}
