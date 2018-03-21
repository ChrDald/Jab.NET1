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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomSandwich
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtMake_Click(object sender, RoutedEventArgs e)
        {
            CustomDialog dialog = new CustomDialog();
            if (dialog.ShowDialog() == true)
            {
                if (dialog.DialogResult == true)
                {
                    Sandwich test = new Sandwich();
                    test.Bread = dialog.BreadType;
                    test.Veggies = dialog.Veggies;

                    TblBread.Text = test.Bread;

                    string SelectedVeggies = null;

      
                    foreach (string veggies in test.Veggies)
                    {
                        if (veggies == "")
                        {
                            continue;
                        }
                        SelectedVeggies += veggies + ", ";
                    }
                    MessageBox.Show(SelectedVeggies);

                    TblVeggies.Text = SelectedVeggies;
                }
                
            }

            

        }
    }
}
