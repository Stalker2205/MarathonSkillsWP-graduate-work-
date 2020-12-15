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
    public partial class RunnerMenu : Window
    {
        public RunnerMenu()
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
            MessageBox.Show("Для получения дополнительной информации\nпожалуйста свяжитесь с координаторами\n\n Телефон:55 11 9988 7766" +
                "\n\n Email: coordinators@marathonskills.org", "Контакты");return;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MyRaceResults myRaceResults = new MyRaceResults();
            myRaceResults.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            EditRunnerProfile runnerProfile = new EditRunnerProfile();
            runnerProfile.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            RegisterForAnEvent registerForAn = new RegisterForAnEvent();
            registerForAn.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MySponsor mySponsor = new MySponsor();
            mySponsor.ShowDialog();
        }
    }
}
