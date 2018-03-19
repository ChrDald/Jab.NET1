using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewPeopleDB
{
    public class Database
    {
        static SqlConnection conn;

        public Database()
        {
            String connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\D\Desktop\My.NETRepo\In Class\InClass\DbPracticeMSSQL\DbPracticeMSSQL\DbPracticeMSSQL\FileDB.mdf'; Integrated Security = True; Connect Timeout = 30";

            conn = new SqlConnection(connectionString);

            conn.Open();
        }

        // get all people
        public List<People> GetPeople()
        {
            SqlCommand selectCmd = new SqlCommand("SELECT Name, Age, Height FROM People", conn);

            List<People> List = new List<People>();

            using (SqlDataReader reader = selectCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        People p = new People();
                        p.Name = (string)reader["Name"];
                        p.Age = (int)reader["Age"];
                        p.Height = (double)reader["Height"];

                        List.Add(p);

                    }
                    catch (InvalidCastException)
                    {
                        MessageBox.Show("Casting exception");
                        return null;
                    }
                }
            }
            // test
            if (List == null)
            {
                MessageBox.Show("List is Empty, check your select statement");
            }
            else
            {
                return List;
            }
            return null;
        }

        public void AddPerson(People p)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO People (Name, Age, Height) VALUES (@Name, @Height, @Age)", conn);

                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Age", p.Age);
                cmd.Parameters.AddWithValue("@Height", p.Height);
                //Execute command
                cmd.ExecuteNonQuery();
            } catch (SqlException)  // not sure if this works?
            {
                throw new Exception("SQL Exception, check your insert data");
            }
            
        }
    }
}

