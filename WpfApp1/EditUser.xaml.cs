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
using System.Text.RegularExpressions;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public EditUser()
        {
            InitializeComponent();
        }
        string RoleKey = "";//R,C,A
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            // Загрузить данные в таблицу User. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.UserTableAdapter marathonDataSetUserTableAdapter = new WpfApp1.marathonDataSetTableAdapters.UserTableAdapter();
            marathonDataSetUserTableAdapter.Fill(marathonDataSet.User);
            marathonDataSetUserTableAdapter.SerchEmail(marathonDataSet.User, Libra.Users.Email);
            System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
            userViewSource.View.MoveCurrentToFirst();

            // Загрузить данные в таблицу Role. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.RoleTableAdapter marathonDataSetRoleTableAdapter = new WpfApp1.marathonDataSetTableAdapters.RoleTableAdapter();
            marathonDataSetRoleTableAdapter.Fill(marathonDataSet.Role);

            System.Windows.Data.CollectionViewSource roleViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("roleViewSource")));
            roleViewSource.View.MoveCurrentToFirst();
            marathonDataSetRoleTableAdapter.SerchRoleName(marathonDataSet.Role, Libra.Users.Role);
            RoleKey = marathonDataSet.Role[0][0].ToString();
            marathonDataSetRoleTableAdapter.Fill(marathonDataSet.Role);
            roleViewSource.View.MoveCurrentToFirst();

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

        private void CloasingButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            marathonDataSetTableAdapters.UserTableAdapter userTableAdapter = new marathonDataSetTableAdapters.UserTableAdapter();
            marathonDataSetTableAdapters.RoleTableAdapter roleTableAdapter = new marathonDataSetTableAdapters.RoleTableAdapter();


            if (firstNameTextBox.Text.Length == 0) { MessageBox.Show("Введите имя"); return; }
            if (lastNameTextBox.Text.Length == 0) { MessageBox.Show("Введите фамилию"); return; }
            if (PasswordTbox.Text.Length == 0 && RePasswordTbox.Text.Length == 0)
            {
                roleTableAdapter.SerchRoleName(marathonDataSet.Role, roleNameComboBox.Text);
                RoleKey = marathonDataSet.Role[0][0].ToString();
                userTableAdapter.UpdateByEmailNoPass(firstNameTextBox.Text, lastNameTextBox.Text, RoleKey, Libra.Users.Email);
                Close();
            }
            else
            {
                if (PasswordTbox.Text.Length < 6) { MessageBox.Show("Введите пароль, не менее 6 символов"); return; }
                Regex reg = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$");
                string ss = Convert.ToString(reg.Match(PasswordTbox.Text));
                if (ss.Length == 0)
                {
                    MessageBox.Show("Пароль должен отвечать следующим требованиям:\n" +
                    "•Минимум 6 символов\n•Минимум 1 прописная буква\n•Минимум 1 цифра\n•По крайней мере один из следующих символов: ! @ # $ % ^ "); return;
                }
                if (PasswordTbox.Text.Length == 0) { MessageBox.Show("Введите пароль"); return; }
                if (RePasswordTbox.Text.Length == 0) { MessageBox.Show("Введите повтор пароля"); return; }
                if (PasswordTbox.Text != RePasswordTbox.Text) { MessageBox.Show("Пароли должны совпадать"); return; }
                roleTableAdapter.SerchRoleName(marathonDataSet.Role, roleNameComboBox.Text);
                RoleKey = marathonDataSet.Role[0][0].ToString();
                userTableAdapter.UpdateUserByEmail(PasswordTbox.Text, firstNameTextBox.Text, lastNameTextBox.Text, RoleKey, Libra.Users.Email);
                Close();
            }
        }
        private void roleNameComboBox_DropDownClosed(object sender, EventArgs e)
        {
        }
    }
}
