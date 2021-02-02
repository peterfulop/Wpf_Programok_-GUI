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


        public MainWindow()
        {
            InitializeComponent();

            //indítás gomb engedélyezése
            InditasGomb.IsEnabled = true;
            
            //igen/nem gomb letiltása
            IgenGomb.IsEnabled = false;
            NemGomb.IsEnabled = false;

            Pontok = 0;
            Run = false;

            //létrehozom a listát mint kártyapakli
            KartyaPakli = new List<FontAwesomeIcon>()
            { 
                FontAwesomeIcon.Flag, FontAwesomeIcon.Wifi, FontAwesomeIcon.Deaf, FontAwesomeIcon.Twitter, FontAwesomeIcon.Magic, FontAwesomeIcon.Edit 
            };

            //Készítek egy véltlen szám generátort (dobókocka)
            Dobokocka = new Random();

            UjKartyaHuzasa();
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

        //függvények
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

            UjKartyaHuzasa();
        }


        private void Pontszerzes(bool add)
        {

            if (add)
            {
                Pontok++;
                pontokLabel.Content = Pontok;
            }
            else
            {
                Pontok--;
                if (Pontok < 0)
                {
                    MessageBox.Show("Vesztettél!");
                    Close();
                }
                pontokLabel.Content = Pontok;
            }
         
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
