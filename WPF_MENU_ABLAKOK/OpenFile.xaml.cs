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
using System.IO;
using Microsoft.Win32;

namespace WPF_MENU_ABLAKOK
{
    /// <summary>
    /// Interaction logic for OpenFile.xaml
    /// </summary>
    public partial class OpenFile : Page
    {
        public OpenFile()
        {
            InitializeComponent();
            //Reset();
            CheckIsChecked(false);

        }


        public void Open()
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "txt files (*.txt)|*.txt"
            };

            dlg.Filter = "txt files (*.txt)|*.txt";

            var result = dlg.ShowDialog();

            if (result == true)
            {
                using (var fs = new FileStream(dlg.FileName, FileMode.Open))
                {
                    using (var sr = new StreamReader(fs, Encoding.UTF8))
                    {
                        filePathRTF.Selection.Text = sr.ReadToEnd();
                    }
                }

                using (var fs = new FileStream(dlg.FileName, FileMode.Open))
                {
                    using (var sr = new StreamReader(fs, Encoding.UTF8))
                    {
                        filePathText.Text = sr.ReadToEnd();
                    }
                }
            }
        }


        private void ExportData()
        {
            var sfd = new SaveFileDialog() {

                //DefaultExt = "txt",
                //FileName = "*",
                //AddExtension = true,

                Filter = "Szöveg file (*.txt)|*.txt | Kép file (*.jpg) |*.jpg"

            };

            var result = sfd.ShowDialog();

            if (result == true)
            {
                 using (var fs = new FileStream(sfd.FileName, FileMode.Create))
                 {
                    using (var sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        sw.WriteLine(filePathText.Text);
                    }
                 }

                MessageBox.Show("A mentés sikeres volt!");
            }

            else
            {
                MessageBox.Show("Nincs mentés!");
            }

        }


        private void openFileBtn_Click(object sender, RoutedEventArgs e)
        {
            Open();
        }

        private void enable_dialog_check_Click(object sender, RoutedEventArgs e)
        {

           // CheckBox cb = sender as CheckBox;
           // var state  = (bool)cb.IsChecked;
           // CheckIsChecked(state);

        }

        private void CheckIsBtnChecked()
        {
            openFileBtn.IsEnabled = enable_dialog_check.IsChecked == true ? true : false;
        }

        private void CheckIsChecked( bool ischecked)
        {
           openFileBtn.IsEnabled = ischecked ? true : false;
        }

        private void Reset()
        {
            openFileBtn.IsEnabled = false;
            enable_dialog_check.IsChecked = false;

        }

        private void resetFileBtn_Click(object sender, RoutedEventArgs e)
        {
            filePathRTF.Document.Blocks.Clear();
            filePathText.Clear();
        }

        private void exportFileBtn_Click(object sender, RoutedEventArgs e)
        {
            ExportData();
        }

        private void enable_dialog_check_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            var state = (bool)cb.IsChecked;
            CheckIsChecked(state);
        }

        private void enable_dialog_check_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            var state = (bool)cb.IsChecked;
            CheckIsChecked(state);
        }




    }
}