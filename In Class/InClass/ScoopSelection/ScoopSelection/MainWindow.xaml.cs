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

namespace ScoopSelection
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

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            // handle if selection is null
            if (lstFlavours.SelectedItem == null)
            {
                MessageBox.Show("Please Select an item to add", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // add the selected flavour to the list
            lstSelected.Items.Add((lstFlavours.SelectedItem as ListBoxItem).Content.ToString());

        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            // handle if selection is null
            if (lstSelected.SelectedItem == null)
            {
                MessageBox.Show("Please Select an item to delete", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            lstSelected.Items.Remove(lstSelected.SelectedItem);
        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            lstSelected.Items.Clear();
        }
    }
}
