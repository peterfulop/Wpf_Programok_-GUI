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

namespace WPF_TicketProg
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {


        public Home()
        {
            InitializeComponent();
        }


        private void menu_1_btn_Click(object sender, RoutedEventArgs e)
        {
            Menu_1 menu1 = new Menu_1();
            MainWindow mw = new MainWindow();
            mw.Content_Frame.Content = menu1;
            NavigationService.Navigate(menu1);
        }

        private void menu_2_btn_Click(object sender, RoutedEventArgs e)
        {
            Menu_2 menu2 = new Menu_2();
            MainWindow mw = new MainWindow();
            mw.Content_Frame.Content = menu2;
            NavigationService.Navigate(menu2);
        }

        private void menu_3_btn_Click(object sender, RoutedEventArgs e)
        {
            Menu_3 menu3 = new Menu_3();
            MainWindow mw = new MainWindow();
            mw.Content_Frame.Content = menu3;
            NavigationService.Navigate(menu3);
        }


        private void selectMenu()
        {

        }
    }
}
