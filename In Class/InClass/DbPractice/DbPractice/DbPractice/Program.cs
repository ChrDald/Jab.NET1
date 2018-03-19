using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Below is to connect to a MYSQL database

            // NOTE you need to add reference MySql.Data
            // in the solution explorer, right click the project (in this case DbPractice), go to add, select reference (not service reference, just reference)
            // then in top right search mysql, find MySql.Data and add that
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                // Trusted_Connection is used to denote the connection uses Windows Authentication


                string MyConString = "Data Source='den1.mysql2.gear.host';" +
                "Database='dotnetdb';" +
                "UID='dotnetdb';" +
                "PWD='Ah6G?9W?uU94';";

                conn.ConnectionString = MyConString;

                conn.Open();
                Console.WriteLine("Connected (?)");
                Console.ReadLine();
            }
        }
    }
}
