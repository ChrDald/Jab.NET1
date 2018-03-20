using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

namespace NewPeopleDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db = new Database();
        
        public MainWindow()
        {
            InitializeComponent();
            
            LoadList();
        }

        // load the list
        private void LoadList()
        {
            LstbPeople.Items.Clear();
            List<People> PeopleList = new List<People>();

            foreach (People p in db.GetPeople())
            {
                PeopleList.Add(p);
            }

            foreach (People p in PeopleList)
            {
                LstbPeople.Items.Add(p);
            }       
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            People p = new People();

            // validating data before inserting...
            p.Name = TbName.Text;
            p.Age = Int32.Parse(TbAge.Text);
            p.Height = SldHeight.Value;

            db.AddPerson(p);
            LoadList();
        }

        private void LstbPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstbPeople.SelectedIndex == -1)
            {
                return;
            }

            try
            {
                People selectedPerson = (People)LstbPeople.SelectedItem;
                TbName.Text = selectedPerson.Name;
                TbAge.Text = selectedPerson.Age + "";
                SldHeight.Value = (int)selectedPerson.Height;

            } catch (InvalidCastException)
            {
                MessageBox.Show("Invalid casting @ selection changed");
                return;
            }                    
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // NOTE i decided not to use the ID, bad decision... pretend im using ID instead of Name to delete
            if (LstbPeople.SelectedIndex == -1)
            {
                return;
            }
            People selectedPerson = (People)LstbPeople.SelectedItem;
            db.DeletePerson(selectedPerson);
            LoadList();
        }
    }
}
