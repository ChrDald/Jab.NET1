using System;
using System.Collections.Generic;
using System.IO;
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

namespace RegisterPeople
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Automatically resize height and width relative to content
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        private void btRegister_Click(object sender, RoutedEventArgs e)
        {
            List<String> RegisterPerson = new List<string>();

            // validate the data before adding
            RegisterPerson.Add(tbName.Text);    // Name

            if (Int32.TryParse(tbAge.Text, out int age)) {
                if (age > 0)
                {
                    RegisterPerson.Add(tbAge.Text);     // Age
                }
                else
                {
                    MessageBox.Show("Enter a valid age", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Enter a valid age", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            

            // get the selected gender and value
            if (rbGender_Female.IsChecked == true)
            {
                RegisterPerson.Add("Female");
            }
            else if (rbGender_Male.IsChecked == true)
            {
                RegisterPerson.Add("Male");
            }
            else if (rbGender_Other.IsChecked == true)
            {
                RegisterPerson.Add("Other?");
            }
            else
            {
                // message box error if no gender selected
                MessageBox.Show("Please select a gender...", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // get the selected radio button and it's value
            if (cbPets_Cat.IsChecked == true)
            {
                RegisterPerson.Add("Cat(s)");
            }
            else if (cbPets_Dog.IsChecked == true)
            {
                RegisterPerson.Add("Dog(s)");
            }
            else if (cbPets_Other.IsChecked == true)
            {
                RegisterPerson.Add("Other pet(s)");
            }
            else
            {
                RegisterPerson.Add("No pets");
            }

            // get the selected continent
            if (cmbContinent.Text == null)
            {
                MessageBox.Show("Please select a continent from the list", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            RegisterPerson.Add(cmbContinent.Text);

            MessageBox.Show("Name: " + RegisterPerson[0] + "\n Age: " + RegisterPerson[1]
                + "\n Gender: " + RegisterPerson[2] + "\n Pets: " + RegisterPerson[3]
                + "\n Continent: " + RegisterPerson[4]);

            foreach (String data in RegisterPerson)
            {
                File.AppendAllText(@"../../test.txt", data + ",");
            }
            File.AppendAllText(@"../../test.txt", "\n");
        }
    }
}
