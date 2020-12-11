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
using System.Data.SqlClient;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class HowLongIsAMarathon : Window
    {
        public HowLongIsAMarathon()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();

            SpeedIm1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "f1-car.jpg", UriKind.Absolute));
            SpeedIm2.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "slug.jpg", UriKind.Absolute));
            SpeedIm3.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "horse.png", UriKind.Absolute));
            SpeedIm4.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "capybara.jpg", UriKind.Absolute));
            SpeedIm5.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "jaguar.jpg", UriKind.Absolute));
            ImageGlav.Source = SpeedIm1.Source;
            Dist1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "bus.jpg", UriKind.Absolute));
            Dist2.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "pair-of-havaianas.jpg", UriKind.Absolute));
            Dist3.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "airbus-a380.jpg", UriKind.Absolute));
            Dist4.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "football-field.jpg", UriKind.Absolute));
            Dist5.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "ronaldinho.jpg", UriKind.Absolute));

        }
        private DispatcherTimer timer = null;

        private void timerStart()
        {
            timer = new DispatcherTimer();  // если надо, то в скобках указываем приоритет, например DispatcherPriority.Render
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }
        double speed;

        private void timerTick(object sender, EventArgs e)
        {
            TimeSpan datet = Perem.datetim();
            LabelTime.Content = $"{datet.Days} дней {datet.Hours} часов и {datet.Minutes} минут до старта марафона!";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SpeedIm1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImageGlav.Source = SpeedIm1.Source;
            speed = 42 / 345;
            TextGlavniy.Text = $"Болид F1 двигается со скоростью {345} км/ч и он завершит этот марафон за {speed} минут";
            Pynkt.Text = "Болид F1";

        }

        private void SpeedIm2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImageGlav.Source = SpeedIm2.Source;
            speed = 42 / 0.01;
            TextGlavniy.Text = $"Слизь двигается со скоростью {0.01} км/ч и он завершит этот марафон за {speed} минут";
            Pynkt.Text = "Слизь";
        }

        private void SpeedIm3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImageGlav.Source = SpeedIm3.Source;
            speed = 42 / 15;
            TextGlavniy.Text = $"Лошадь двигается со скоростью {15} км/ч и он завершит этот марафон за {speed} минут";
            Pynkt.Text = "Лошадь";
        }

        private void SpeedIm4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImageGlav.Source = SpeedIm4.Source;
            speed = 42 / 35;
            TextGlavniy.Text = $"Капибара двигается со скоростью {35} км/ч и он завершит этот марафон за {speed} минут";
            Pynkt.Text = "Капибара";
        }

        private void SpeedIm5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImageGlav.Source = SpeedIm5.Source;
            speed = 42 / 80;
            TextGlavniy.Text = $"Ягуар двигается со скоростью {80} км/ч и он завершит этот марафон за {speed} минут";
            Pynkt.Text = "Ягуар";
        }
        int marathon = 42000;
        double lengthMarathon = 0;
        private void Dist1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImageGlav.Source = Dist1.Source;
            lengthMarathon = marathon / 10;
            Pynkt.Text = "Автобус";
            TextGlavniy.Text = $"Автобус имеет длинну {10} можно поставить в ряд {lengthMarathon}, чтобы покрыть вдлинну всего марафона  ";
        }

        private void Dist2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImageGlav.Source = Dist2.Source;
            double LengthPred = 0.245;
            lengthMarathon = marathon / LengthPred;
            Pynkt.Text = "Тапочки";
            TextGlavniy.Text = $"Тапочки имеет длинну {LengthPred} можно поставить в ряд {lengthMarathon}, чтобы покрыть вдлинну всего марафона  ";

        }

        private void Dist3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImageGlav.Source = Dist3.Source;
            double LengthPred = 73;
            lengthMarathon = marathon / LengthPred;
            Pynkt.Text = "Самолет";
            TextGlavniy.Text = $"Самолет имеет длинну {LengthPred} можно поставить в ряд {lengthMarathon}, чтобы покрыть длинну всего марафона  ";

        }

        private void Dist4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImageGlav.Source = Dist4.Source;
            double LengthPred = 105;
            lengthMarathon = marathon / LengthPred;
            Pynkt.Text = "Футбольное поле";
            TextGlavniy.Text = $"Футбольное поле имеет длинну {LengthPred} можно поставить в ряд {lengthMarathon}, чтобы покрыть вдлинну всего марафона  ";

        }

        private void Dist5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImageGlav.Source = Dist5.Source;
            double LengthPred = 1.81;
            lengthMarathon = marathon / LengthPred;
            Pynkt.Text = "Рональдо";
            TextGlavniy.Text = $"Рональдо имеет Рост {LengthPred} можно поставить в ряд {lengthMarathon}, чтобы покрыть вдлинну всего марафона  ";

        }
    }
}
