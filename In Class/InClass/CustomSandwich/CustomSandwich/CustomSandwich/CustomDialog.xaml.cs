using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CustomSandwich
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CustomDialog : Window
    {
        private string _breadType;
        public string BreadType { get => _breadType; set => _breadType = value; }

        private string[] _veggies;
        public string[] Veggies { get => _veggies; set => _veggies = value; }

        
        public CustomDialog()
        {
            InitializeComponent();
        }

        private void Custom_BtSave_Click(object sender, RoutedEventArgs e)
        {

            Sandwich sandwich = new Sandwich();

            sandwich.Bread = CmbBread.Text;
            string[] SelectedVeggies = new string[3];

            // Veggies
            if (CbCucumbers.IsChecked == true)
            {
                SelectedVeggies[0] = (string)CbCucumbers.Content;
            }
            if (CbLettuce.IsChecked == true)
            {
                SelectedVeggies[1] = (string)CbLettuce.Content;
            }
            if (CbTomatoes.IsChecked == true)
            {
                SelectedVeggies[2] = (string)CbTomatoes.Content;
            }

            Veggies = SelectedVeggies;     // NOT SUUURE this works...

            BreadType = sandwich.Bread;

            DialogResult = true;
        }

        private void Custom_BtCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    
    public class Sandwich
    {
        string _bread;
        public string[] Veggies { get; set; }
        public string[] Meat { get; set; }

        public string Bread { get => _bread; set => _bread = value; }
    }

}
