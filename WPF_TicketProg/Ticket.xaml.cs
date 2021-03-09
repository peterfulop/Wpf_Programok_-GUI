using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPF_TicketProg
{
    /// <summary>
    /// Interaction logic for Ticket.xaml
    /// </summary>
    /// 
    public partial class Ticket : Window
    {
        public TimeSpan RunTime { get; private set; }
        public DispatcherTimer Timer { get; private set; }

        public Ticket()
        {
            InitializeComponent();
            RunTime  = TimeSpan.FromSeconds(3);
            Timer = new DispatcherTimer
               (TimeSpan.FromSeconds(1),
               DispatcherPriority.Normal,
               Orautes,
               Application.Current.Dispatcher);
        }

        private void Orautes(object sender, EventArgs e)
        {
            RunTime -= TimeSpan.FromSeconds(1);

            if (RunTime == TimeSpan.FromSeconds(0))
            {
                Close();
            }
        }

        private void Ticket_Close_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
    }
}
