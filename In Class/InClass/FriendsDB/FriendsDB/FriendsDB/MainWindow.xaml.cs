using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FriendsDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static SqlConnection conn = ConnectDb();

        public MainWindow()
        {
            InitializeComponent();
            LoadList();
        }

        static SqlConnection ConnectDb()
        {
            String connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\D\Desktop\My.NETRepo\In Class\InClass\DbPracticeMSSQL\DbPracticeMSSQL\DbPracticeMSSQL\FileDB.mdf'; Integrated Security = True; Connect Timeout = 30";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            Console.WriteLine("Connected");

            return conn;
        }

        private void LoadList()
        {
            LstvFriendsList.Items.Clear();
            // sql select all
            SqlCommand selectCmd = new SqlCommand("SELECT * FROM Friends", conn);

            using (SqlDataReader reader = selectCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    LstvFriendsList.Items.Add(reader[1]);   // reader[1] is the name value
                }
            }
        }

        private void AddFriend()
        {
            //create command and assign the query and connection from the constructor
            SqlCommand cmd = new SqlCommand("INSERT INTO Friends (Name) VALUES (@name)", conn);

            // get the name
            Regex regex = new Regex(@"^[a-zA-Z]{2,50}");
            String Name = TbName.Text.Trim();

            if (!regex.IsMatch(Name))
            {
                MessageBox.Show("Invalid Name Entered", "Error", MessageBoxButton.OK);
                return;
            }
            
            cmd.Parameters.AddWithValue("@name", Name);

            //Execute command
            cmd.ExecuteNonQuery();

            LoadList();
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TbName == null)
            {
                MessageBox.Show("Enter a name to add (2 to 50 characters)", "Error", MessageBoxButton.OK);
                return;
            }

            AddFriend();
        }
    }

    
}
