using FontAwesome.WPF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Xaml_Game_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        //oszály szintű változó
        public FontAwesomeIcon elozoKartya { get; private set; }
        public List<FontAwesomeIcon> KartyaPakli { get; private set; }
        public Random Dobokocka { get; private set; }
        public int Pontok { get;  set; }
        public bool Run { get;  private set; }
        public DispatcherTimer Ingaora { get;  private set; }
        public TimeSpan JatekIdo { get; private set; }
        public Stopwatch stopperora { get; private set; }
        public List<long> ListaReakcioIdohoz { get; private set; }



        public MainWindow()
        {
            InitializeComponent();

            //Csak az alkalmazás indulásakor kell lefutnia *************************************************************************************************/

            //létrehozom a listát mint kártyapakli
            KartyaPakli = new List<FontAwesomeIcon>()
            {
                FontAwesomeIcon.Flag, FontAwesomeIcon.Wifi, FontAwesomeIcon.Deaf, FontAwesomeIcon.Twitter, FontAwesomeIcon.Magic, FontAwesomeIcon.Edit
            };

            //Készítek egy véltlen szám generátort (dobókocka)
            Dobokocka = new Random();

            // Ingaóra létrehozása
            Ingaora = new DispatcherTimer
                (TimeSpan.FromSeconds(1),
                DispatcherPriority.Normal,
                Orautes,
                Application.Current.Dispatcher);

            Ingaora.Stop();

            //Stopperóra létrehozása
            stopperora = new Stopwatch();


            /* **********************************************************************************************************************************************/


            // Minden játék indításakor kell ****************************************************************************************************************/

            jatekInditasa();

            /* **********************************************************************************************************************************************/

        }

       

        private void IgenGomb_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Igen gomb");
            //JobbKartya.Icon = FontAwesome.WPF.FontAwesomeIcon.Wifi;
            IgenValasz();
        }

        private void NemGomb_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Nem gomb");
            //BalKartya.Icon = FontAwesome.WPF.FontAwesomeIcon.Ban; 
            NemValasz();
        }

        private void InditasGomb_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Indítás gomb");
            Inditas();
        }

        private void UjraInditasGomb_Click(object sender, RoutedEventArgs e)
        {
            jatekInditasa();
            Inditas();

        }


        //függvények
        private void jatekInditasa()
        {

            ResetLabeles();

            UjraInditasGomb.Visibility = Visibility.Hidden;
            InditasGomb.Visibility = Visibility.Visible;

            Pontok = 0;
            Run = false;

            JatekIdo = TimeSpan.FromSeconds(0);

            //indítás gomb engedélyezése
            InditasGomb.IsEnabled = true;

            //igen/nem gomb letiltása
            IgenGomb.IsEnabled = false;
            NemGomb.IsEnabled = false;

            //lista készítése a reakcióidő tárolására
            ListaReakcioIdohoz = new List<long>();
            
            UjKartyaHuzasa();

        }

        private void ResetLabeles()
        {
            jatekidoLabel.Content = "00:00";
            pontokLabel.Content = "0";
            reakcioIdoLabel.Content = "0";
            atlReakcioIdoLabel.Content = "0";
        }

        private void Orautes(object sender, EventArgs e)
        {
            JatekIdo += TimeSpan.FromSeconds(1);

            LabelJatekido();

            if (JatekIdo >= TimeSpan.FromSeconds(5))
            {
                JatekVegeAllapot();
            }

        }

        private void LabelJatekido()
        {
            jatekidoLabel.Content = $"{JatekIdo.Minutes:00}:{JatekIdo.Seconds:00}";
        }

        private void JatekVegeAllapot()
        {
            Ingaora.Stop();

            //igen/nem gomb letiltása
            IgenGomb.IsEnabled = false;
            NemGomb.IsEnabled = false;

            UjraInditasGomb.Visibility = Visibility.Visible;
            InditasGomb.Visibility = Visibility.Hidden;

        }

        private void NemValasz()
        {
            //jó és rossz válasz vizsgálata
            if (elozoKartya != JobbKartya.Icon)
            {//jó válasz
                JoValasz();
            }
            else
            {//rossz válasz
                RosszValasz();
            }

            UjKartyaHuzasa();
        }

        private void IgenValasz()
        {
            //jó és rossz válasz vizsgálata
            if (elozoKartya == JobbKartya.Icon)
            {//jó válasz
                JoValasz();
            }
            else
            {//rossz válasz
                RosszValasz();
            }

            UjKartyaHuzasa();
        }

        private void Inditas()
        {


            //indítás gomb letiltása
            InditasGomb.IsEnabled = false;

            //igen/nem gomb engedélyezése
            IgenGomb.IsEnabled = true;
            NemGomb.IsEnabled = true;

            Ingaora.Start();

            stopperora.Start();

            UjKartyaHuzasa();



        }


        private void Pontszerzes(bool add)
        {

            if (add)
            {
                Pontok++;
            }
            else
            {
                Pontok--;
                if (Pontok < 0)
                {
                    MessageBox.Show("Vesztettél!");
                    Close();
                }
            }


            ListaReakcioIdohoz.Add(stopperora.ElapsedMilliseconds);

            LabelFill();

        }


        private void LabelFill()
        {
            pontokLabel.Content = Pontok;
            reakcioIdoLabel.Content = ListaReakcioIdohoz.Last();
            atlReakcioIdoLabel.Content = (long)ListaReakcioIdohoz.Average();
        }


        private void JoValasz()
        {
           BalKartya.Icon = FontAwesomeIcon.Check;
           BalKartya.Foreground = Brushes.Green;
           Animation(BalKartya,false, 500);
           Pontszerzes(true);
        }

        private void Animation(ImageAwesome BalKartya, bool fadeIn,int ms )
        {
            int start = 1;
            int end = 0;

            if (fadeIn)
            {
                start = 0;
                end = 1;
            }

            TimeSpan time = TimeSpan.FromMilliseconds(ms);
            var animacio = new DoubleAnimation(start, end, time);
            BalKartya.BeginAnimation(OpacityProperty, animacio);
        }

        private void RosszValasz()
        {
            BalKartya.Icon = FontAwesomeIcon.Times;
            BalKartya.Foreground = Brushes.Red;
            Animation(BalKartya, false, 500);
            Pontszerzes(false);
        }

        private void UjKartyaHuzasa()
        {
            var dobas = Dobokocka.Next(0, KartyaPakli.Count);

            //osztály szintű változót kell létrehozni NEM A var (variable) segítségével
            elozoKartya = JobbKartya.Icon;

            //megadom hogy hol jelenjen meg
            JobbKartya.Icon = KartyaPakli[dobas];
            Animation(JobbKartya, true, 1000);
            stopperora.Restart();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Up && Run == false)
            {
                Run = true;
                Inditas();
            }

            if (e.Key == Key.Right && Run == true)
            {
                NemValasz();
            }

            if (e.Key == Key.Left && Run == true)
            {
                IgenValasz();
            }
        }


    }
}
