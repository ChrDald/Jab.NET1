using Microsoft.Win32;
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

// Note this is not quite finished, need to fix up some functions

namespace NotepadClone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // global file
        static String fileName = null;
        static String filePath = null;
        static bool unSaved = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void miOpen_Click(object sender, RoutedEventArgs e)
        {
            // import text file, write to text box line by line.

            // first select file
            OpenFileDialog dlgOpen = new OpenFileDialog();

            if (dlgOpen.ShowDialog() == true)
            {
                String[] lines = File.ReadAllLines(dlgOpen.FileName);
                foreach (String line in lines)
                {
                    tbContent.AppendText(line + "\n");
                }
            }

        }

        private void miSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == true)
            {
                fileName = saveFileDialog.FileName;
                File.WriteAllText(saveFileDialog.FileName, tbContent.Text);
                unSaved = false;
            }
                

        }

        private void miSave_Click(object sender, RoutedEventArgs e)
        {
            if (fileName == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                if (saveFileDialog.ShowDialog() == true)
                {
                    fileName = saveFileDialog.FileName;
                    File.WriteAllText(saveFileDialog.FileName, tbContent.Text);
                    unSaved = false;
                }
            }
            else
            {
                File.WriteAllText(fileName, tbContent.Text);
                unSaved = false;
            }
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            

            if (unSaved == true)
            {

                MessageBoxResult result = MessageBox.Show("Unsaved Changes, do you really want to quit?", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
                else
                {
                    System.Environment.Exit(0);
                }
                
            }
        }

        private void tbContent_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // when textbox content is changed, set the boolean "unSaved" to false, so no data is lost
            unSaved = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
