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
    /// Interaction logic for Menu_3.xaml
    /// </summary>
    public partial class Menu_3 : Page
    {
        public Menu_3()
        {
            InitializeComponent();
        }

        private void main_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            MainWindow mw = new MainWindow();
            mw.Content_Frame.Content = home;
            NavigationService.Navigate(home);
        }
    }
}
