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
    /// Interaction logic for Menu_2.xaml
    /// </summary>
    public partial class Menu_2 : Page
    {
        public string MyNumber { get; set; }

        public Menu_2()
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


        private void menu_2_btn_1_Click(object sender, RoutedEventArgs e)
        {
            setData(sender);
        }

        private void menu_2_btn_2_Click(object sender, RoutedEventArgs e)
        {
            setData(sender);
        }

        private void menu_2_btn_3_Click(object sender, RoutedEventArgs e)
        {
            setData(sender);
        }

        private void menu_2_btn_4_Click(object sender, RoutedEventArgs e)
        {
            setData(sender);
        }

        private void menu_2_btn_5_Click(object sender, RoutedEventArgs e)
        {
            setData(sender);
        }

        private void menu_2_btn_6_Click(object sender, RoutedEventArgs e)
        {
            setData(sender);
        }


        public void setData(object sender)
        {
            var btn = (Button)sender;
            MainWindow.Counter++;
            Home home = new Home();
            MyNumber = $"{home.menu_2_btn.DataContext}{btn.DataContext}{MainWindow.Counter}";
            fillTicketWindow();
        }

        public void fillTicketWindow()
        {
            DateTime today = DateTime.Now;

            Ticket t = new Ticket();

            t.Label_Date.Content = today.ToString("yyyy/MM/dd HH:mm:ss");
            t.Label_MyNumber.Content = MyNumber;

            t.ShowDialog();

        }


    }
}
