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
using Libra;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
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
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (TboxMail.Text.Length == 0 || TboxPass.Text.Length == 0) { MessageBox.Show("Введите mail и пароль"); return; }
            WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));
            WpfApp1.marathonDataSetTableAdapters.UserTableAdapter userTableAdapter = new marathonDataSetTableAdapters.UserTableAdapter();
            WpfApp1.marathonDataSetTableAdapters.RunnerTableAdapter runnerTableAdapter = new marathonDataSetTableAdapters.RunnerTableAdapter();
            runnerTableAdapter.SerchEmail(marathonDataSet.Runner, TboxMail.Text);
            userTableAdapter.FillBy(marathonDataSet.User, TboxMail.Text, TboxPass.Text);
            if (userTableAdapter.FillBy(marathonDataSet.User, TboxMail.Text, TboxPass.Text) == 0) { MessageBox.Show("Такой комбинации логина и пароля не существует"); return; }
            string role = marathonDataSet.User[0][4].ToString();
            Runner.ID = marathonDataSet.Runner[0][0].ToString();
            Runner.Email = TboxMail.Text;
            Runner.Password = TboxPass.Text;
            Runner.CountryCode = marathonDataSet.Runner[0][4].ToString();
            Runner.Pos = "Login";
            Runner.Gender = marathonDataSet.Runner[0][2].ToString();
            Runner.Photo = marathonDataSet.Runner[0][5].ToString();
            switch (role)
            {
                case "R"://бегун
                    {
                        RunnerMenu runnerMenu = new RunnerMenu();
                        runnerMenu.Show();
                        Close();
                        break;
                    }
                case "A"://Админ
                    {
                        AdminMenu adminMenu = new AdminMenu();
                        adminMenu.Show();
                        Close();
                        break;
                    }
                case "K"://Координатор
                    {
                        CoordinatorMenu coordinatorMenu = new CoordinatorMenu();
                        coordinatorMenu.Show();
                        Close();
                        break;

                    }
                default:
                    {
                        MessageBox.Show("Default case");
                        break;
                    }
            }
        }
    }
}
