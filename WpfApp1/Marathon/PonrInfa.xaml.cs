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
    public partial class PonrInfa : Window
    {
        public PonrInfa()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SpisokOrg spisokOrg = new SpisokOrg();
            spisokOrg.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            HowLongIsAMarathon marathon = new HowLongIsAMarathon();
            marathon.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AboutMarathon aboutMarathon = new AboutMarathon();
            aboutMarathon.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            PreviousRaceResult previousRaceResult = new PreviousRaceResult();
            previousRaceResult.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            BMIcalculator bMIcalculator = new BMIcalculator();
            bMIcalculator.Show();
            Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            BMRcalculator bMRcalculator = new BMRcalculator();
            bMRcalculator.Show();
            Close();
        }
    }
}
