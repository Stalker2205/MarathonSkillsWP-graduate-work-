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
    public partial class InteractMap : Window
    {
        public InteractMap()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            MapImg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "marathon-skills-2016-marathon-map.jpg", UriKind.Absolute));
        }
        private DispatcherTimer timer = null;

        private void timerStart()
        {
            timer = new DispatcherTimer();  // если надо, то в скобках указываем приоритет, например DispatcherPriority.Render
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            TimeSpan datet = Perem.datetim();
            LabelTime.Content = $"{datet.Days} дней {datet.Hours} часов и {datet.Minutes} минут до старта марафона!";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Checpoint.Text = "Checpoint 8";
            WaterTbox.Text = "да";
            EatTBox.Text = "да";
            TyalTbox.Text = "да";
            MedicTbox.Text = "Да";
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Checpoint.Text = "Checpoint 1";
            WaterTbox.Text = "да";
            EatTBox.Text = "да";
            TyalTbox.Text = "нет";
            MedicTbox.Text = "нет";
        }

        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            Checpoint.Text = "Checpoint 2";
            WaterTbox.Text = "да";
            EatTBox.Text = "да";
            TyalTbox.Text = "да";
            MedicTbox.Text = "да";
        }

        private void Image_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            Checpoint.Text = "Checpoint 3";
            WaterTbox.Text = "да";
            EatTBox.Text = "да";
            TyalTbox.Text = "да";
            MedicTbox.Text = "нет";
        }

        private void Image_MouseLeftButtonDown_4(object sender, MouseButtonEventArgs e)
        {
            Checpoint.Text = "Checpoint 4";
            WaterTbox.Text = "да";
            EatTBox.Text = "да";
            TyalTbox.Text = "да";
            MedicTbox.Text = "да";
        }

        private void Image_MouseLeftButtonDown_5(object sender, MouseButtonEventArgs e)
        {
            Checpoint.Text = "Checpoint 5";
            WaterTbox.Text = "да";
            EatTBox.Text = "да";
            TyalTbox.Text = "да";
            MedicTbox.Text = "нет";
        }

        private void Image_MouseLeftButtonDown_6(object sender, MouseButtonEventArgs e)
        {
            Checpoint.Text = "Checpoint 6";
            WaterTbox.Text = "да";
            EatTBox.Text = "да";
            TyalTbox.Text = "да";
            MedicTbox.Text = "нет";
        }

        private void Image_MouseLeftButtonDown_7(object sender, MouseButtonEventArgs e)
        {
            Checpoint.Text = "Checpoint 7";
            WaterTbox.Text = "да";
            EatTBox.Text = "да";
            TyalTbox.Text = "да";
            MedicTbox.Text = "да";
        }
    }
}
