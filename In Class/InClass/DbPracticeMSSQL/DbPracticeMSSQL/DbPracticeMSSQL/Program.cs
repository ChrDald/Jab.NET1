using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbPracticeMSSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            String connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\D\Desktop\My.NETRepo\In Class\InClass\DbPracticeMSSQL\DbPracticeMSSQL\DbPracticeMSSQL\FileDB.mdf'; Integrated Security = True; Connect Timeout = 30";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            Console.WriteLine("Connected");

            //create command and assign the query and connection from the constructor
            SqlCommand cmd = new SqlCommand("INSERT INTO Friends (Name) VALUES (@name)", conn);
            cmd.Parameters.AddWithValue("@name", "Test");

            //Execute command
            cmd.ExecuteNonQuery();

            // sql select all
            SqlCommand selectCmd = new SqlCommand("SELECT * FROM friends", conn);

            using(SqlDataReader reader = selectCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}: {1}", reader[0], reader[1]));
                  
                }
                Console.ReadLine();
            }
            
        }
    }
}
