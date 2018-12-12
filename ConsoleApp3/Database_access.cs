using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp3
{
    class Database_access
    {
        
        public static int validate_user(string user, string pass)
        // checks in the DB is the username/ password  is acceptable and returns role
        {
            if ((user == "admin") && (pass == "admin"))
                return -1;
            else
            {
                string qs = "SELECT [role] FROM [ChatDB].[dbo].[Users] where [username]='" + user + "' and [password]='" + pass + "'";
                List<string> rolelist = new List<string>();
                rolelist = Database_access.queryDB(qs);
                if (rolelist.Count() == 0) return -2;
                else
                {
                    int n = int.Parse(rolelist[0]);
                    return n;
                }
            }
           
        }

        public static  bool validate_user(string user)
        // checks in the DB is the username/ password  is acceptable and returns role
        {
            string qs = "SELECT [username] FROM [ChatDB].[dbo].[Users] where [username]='" + user + "'"; 
                List<string> rolelist = new List<string>();
                rolelist = Database_access.queryDB(qs);
            if (rolelist.Count() == 0) return false;
            else
            {
                return true;
            }
            

        }

        public static List<string> queryDB(string query)
        {
            string connectionstring= @"Server=localhost\SQLEXPRESS; Database=ChatDb; Trusted_Connection=True";
            List<string> result = new List<string>();
            try
            {
                using (SqlConnection sc = new SqlConnection(connectionstring))
                {
                    SqlCommand command = new SqlCommand(query, sc);
                    sc.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    // Call Read before accessing data.
                    while (reader.Read() )
                    {
                       result.Add(reader[0].ToString());
                    }
                    // Call Close when done reading.
                    reader.Close();

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        public static List<message> query_msg_DB(string query)
        {
            string connectionstring = @"Server=localhost\SQLEXPRESS; Database=ChatDb; Trusted_Connection=True";
            List<message> result = new List<message>();
            try
            {
                using (SqlConnection sc = new SqlConnection(connectionstring))
                {
                    SqlCommand command = new SqlCommand(query, sc);
                    sc.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    // Call Read before accessing data.
                    while (reader.Read())
                    {
                        var msg_i = new message(reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                        msg_i.MessageID = reader["MessageID"].ToString();
                        result.Add(msg_i);
                    }
                    // Call Close when done reading.
                    reader.Close();
                    
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
        public static void updateDB(string query)
        {
            string connectionstring = @"Server=localhost\SQLEXPRESS; Database=master; Trusted_Connection=True";
            try
            {
                using (SqlConnection sc = new SqlConnection(connectionstring))
                {
                    SqlCommand command = new SqlCommand(query, sc);
                    sc.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
