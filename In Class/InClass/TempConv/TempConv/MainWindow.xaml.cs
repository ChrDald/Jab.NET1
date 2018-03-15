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

namespace TempConv
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btConvert_Click(object sender, RoutedEventArgs e)
        {
            String StrCelcius = tbCelcius.Text;
            double CelciusValue;

            if (Double.TryParse(StrCelcius, out CelciusValue)) {
                // note the point of try parse is to NOT throw an exception, it returns either true or false, if parse works the OUT variable is the parse result
                double Fahr = CelciusValue * 9 / 5 + 32;
                lblFahrenheit.Content = Fahr + " F";
            } 
        }
    }
}
