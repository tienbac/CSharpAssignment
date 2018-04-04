using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace StudentsMansger.Model
{
    class StudentModel
    {
        public void InsertData(string rollNumber, string name, int gender, string phone, string email, string address, string createdAt)
        {
            MySqlConnection connection = null;
            if (connection == null)
            {
                connection = ConnectionHelper.GetConnection();
            }
            try
            {
                string insertSql = "INSERT INTO students(rollNumber, name, gender, phone, email, address, createdAt)"
                                    + "VALUES(@roll, @name, @gender, @phone, @email, @address, @created)";

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = insertSql;

                // Tạo đối tượng Parameter cách 1
                MySqlParameter rollParam = new MySqlParameter("@roll", MySqlDbType.VarChar);
                rollParam.Value = rollNumber;
                cmd.Parameters.Add(rollParam);

                // Cách 2
                MySqlParameter nameParam = cmd.Parameters.Add("@name", MySqlDbType.VarChar);
                nameParam.Value = name;

                // Cách 3
                cmd.Parameters.Add("@gender", MySqlDbType.Int64).Value = gender;

                // <===============>
                MySqlParameter phoneParam = cmd.Parameters.Add("@phone", MySqlDbType.VarChar);
                phoneParam.Value = phone;

                MySqlParameter emailParam = cmd.Parameters.Add("@email", MySqlDbType.VarChar);
                emailParam.Value = email;

                MySqlParameter addressParam = cmd.Parameters.Add("@address", MySqlDbType.VarChar);
                addressParam.Value = address;

                MySqlParameter createdParam = cmd.Parameters.Add("@created", MySqlDbType.VarChar);
                createdParam.Value = createdAt;

                // Thực thi Command
                cmd.ExecuteNonQuery();

                Console.WriteLine("Insert Success!");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        public void UpdateData(string rollNumber, string name, int gender, string phone, string email, string address, string updatedAt)
        {
            MySqlConnection connection = null;
            if (connection == null)
            {
                connection = ConnectionHelper.GetConnection();
            }
            try
            {
                string updateSql = "UPDATE students SET name = @name, gender = @gender, phone = @phone, email = @email, address = @address, updatedAt = @updatedAt WHERE rollNumber = @roll";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = updateSql;

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@gender", MySqlDbType.Int64).Value = gender;
                cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = address;
                cmd.Parameters.Add("@updatedAt", MySqlDbType.VarChar).Value = updatedAt;
                cmd.Parameters.Add("@roll", MySqlDbType.VarChar).Value = rollNumber;

                cmd.ExecuteNonQuery();
                Console.WriteLine("Update Successful !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        public void DeteleData(string rollNumber, int choice)
        {
            MySqlConnection connection = null;
            if (connection == null)
            {
                connection = ConnectionHelper.GetConnection();
            }
            try
            {
                string deleteSql = "DELETE FROM students WHERE rollNumber = @roll";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = deleteSql;

                cmd.Parameters.Add("@roll", MySqlDbType.VarChar).Value = rollNumber;

                switch (choice)
                {
                    case 1:
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Delete Successful !");
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please choice 0 or 1!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        public void SelectData()
        {

            MySqlConnection connection = null;
            if (connection == null)
            {
                connection = ConnectionHelper.GetConnection();
            }
            try
            {
                string selectSql = "SELECT id, rollNumber, name, gender, phone, email, address FROM students";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = selectSql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine("||--------------||--------------||----------------------||--------------||----------------------||------------------------------||--------------------------------------||");
                        Console.WriteLine("||      ID      ||  ROLLNUMBER  ||         NAME         ||    GENDER    ||         PHONE        ||               EMAIL          ||                 ADDRESS              ||");
                        Console.WriteLine("||--------------||--------------||----------------------||--------------||----------------------||------------------------------||--------------------------------------||");
                        while (reader.Read())
                        {

                            int idIndex = reader.GetOrdinal("id");
                            //long id = Convert.ToInt64(reader.GetValue(idIndex));
                            int id = (int)reader.GetValue(idIndex);
                            //Console.WriteLine("ID:" + id);

                            int rollIndex = reader.GetOrdinal("rollNumber");
                            string rollNumber = reader.GetString(rollIndex);
                            //Console.WriteLine("Rollnumber: " + rollNumber);

                            int nameIndex = reader.GetOrdinal("name");
                            string name = reader.GetString(nameIndex);
                            //Console.WriteLine(name);

                            int genderIndex = reader.GetOrdinal("gender");
                            //long gender = Convert.ToInt64(reader.GetValue(genderIndex));
                            int gender = (int)reader.GetValue(genderIndex);

                            //Console.WriteLine(gender);

                            int phoneIndex = reader.GetOrdinal("phone");
                            string phone = reader.GetString(phoneIndex);
                            //Console.WriteLine(phone);

                            int emailIndex = reader.GetOrdinal("email");
                            string email = reader.GetString(emailIndex);
                            //Console.WriteLine(email);

                            int addressIndex = reader.GetOrdinal("address");
                            string address = reader.GetString(addressIndex);
                            //Console.WriteLine(address);

                            //Student student = new Student(id, rollNumber, name, gender, phone, email, address);
                            //list.Add(student);

                            Console.WriteLine("||\t" + id + "\t||\t" + rollNumber + "\t||\t" + name + "\t||\t"
                                                + (gender == 0 ? "Female" : (gender == 1 ? "Male" : "Other")) + "\t||\t" + phone + "\t||\t" + email + "\t||\t" + address + "\t||");
                            Console.WriteLine("||--------------||--------------||----------------------||--------------||----------------------||------------------------------||--------------------------------------||");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            /*finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }*/
        }

        /*public static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.WriteLine("{0}", obj);
            Console.WriteLine();
        }*/

        public void FindData(string rollnumber)
        {
            MySqlConnection connection = null;
            if (connection == null)
            {
                connection = ConnectionHelper.GetConnection();
            }
            try
            {
                string findSql = "SELECT id, rollNumber, name, gender, phone, email, address, createdAt, updatedAt FROM students WHERE rollNumber =" + "'" + rollnumber + "'";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = findSql;

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("||------------------------------------------------||");
                    Console.WriteLine("||  ID         : " + reader["id"] + "                                ||");
                    Console.WriteLine("||------------------------------------------------||");
                    Console.WriteLine("||  Roll Number: " + reader["rollNumber"].ToString() + "                           ||");
                    Console.WriteLine("||------------------------------------------------||");
                    Console.WriteLine("||  Name       : " + reader["name"].ToString() + "                    ||");
                    Console.WriteLine("||------------------------------------------------||");

                    int gender = (int)reader["gender"];
                    Console.WriteLine("||  Gender     : " + (gender == 0 ? "Female" : (gender == 1 ? "Male" : "Other")) + "                             ||");
                    Console.WriteLine("||------------------------------------------------||");

                    Console.WriteLine("||  Phone      : " + reader["phone"].ToString() + "                      ||");
                    Console.WriteLine("||------------------------------------------------||");
                    Console.WriteLine("||  Email      : " + reader["email"].ToString() + "          ||");
                    Console.WriteLine("||------------------------------------------------||");
                    Console.WriteLine("||  Address    : " + reader["address"].ToString() + "    ||");
                    Console.WriteLine("||------------------------------------------------||");
                    Console.WriteLine("||  Created At : " + reader["createdAt"].ToString() + "              ||");
                    Console.WriteLine("||------------------------------------------------||");
                    Console.WriteLine("||  Updated At : " + reader["updatedAt"].ToString() + "              ||");
                    Console.WriteLine("||------------------------------------------------||");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }
    }
}
