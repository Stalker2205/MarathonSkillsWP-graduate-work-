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
    public partial class AboutMarathon : Window
    {
        public AboutMarathon()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ImgGlav.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "marathon-skills-2016-marathon-map.jpg", UriKind.Absolute));
            Img1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "banco-banespa.jpg", UriKind.Absolute));
            Img2.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "ibirapuera-park-lake.jpg", UriKind.Absolute));
            Img3.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "marathon-image.jpg", UriKind.Absolute));
            Img4.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "teatro-municipal.jpg", UriKind.Absolute));
            timerStart();
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

        private void ImgGlav_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            InteractMap interactMap = new InteractMap();
            interactMap.ShowDialog();
        }
    }
}
