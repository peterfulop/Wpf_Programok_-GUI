using Microsoft.Win32;
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

namespace WPF_MENU_ABLAKOK
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


    private void btn_fooldal_Click(object sender, RoutedEventArgs e)
        {
            Tartalom.Content = new MainPage();
        }

        private void btn_ujablak_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.ShowDialog();
        }

        public void btn_tallozas_Click(object sender, RoutedEventArgs e)
        {
            Tartalom.Content = new OpenFile();
        }

        private void btn_oldal_1_Click(object sender, RoutedEventArgs e)
        {
            Tartalom.Content = new Page1();
        }

        private void btn_oldal_2_Click(object sender, RoutedEventArgs e)
        {
            Tartalom.Content = new Page2();
        }

        private void ablakom_Loaded(object sender, RoutedEventArgs e)
        {
            Tartalom.Content = new MainPage();
        }
    }
}
