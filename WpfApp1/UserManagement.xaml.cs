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
    public partial class UserManagement : Window
    {
        public UserManagement()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            // Загрузить данные в таблицу User. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.UserTableAdapter marathonDataSetUserTableAdapter = new WpfApp1.marathonDataSetTableAdapters.UserTableAdapter();
            marathonDataSetUserTableAdapter.Fill(marathonDataSet.User);
            System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
            userViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Role. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.RoleTableAdapter marathonDataSetRoleTableAdapter = new WpfApp1.marathonDataSetTableAdapters.RoleTableAdapter();
            marathonDataSetRoleTableAdapter.Fill(marathonDataSet.Role);
            System.Windows.Data.CollectionViewSource roleViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("roleViewSource")));
            roleViewSource.View.MoveCurrentToFirst();
            AllUsersTbox.Text = $"Всего пользователей :{marathonDataSetUserTableAdapter.CountUser()}";
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

        private void EmailButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Libra.Users.Email = sender.ToString().Remove(0, 32).Trim();
            }
            catch { MessageBox.Show("ВЫ не можете выбрать никого кроме бегуна"); return; }
            Libra.Users.Role = roleNameComboBox.Text;
            EditUser editUser = new EditUser();
            editUser.ShowDialog();
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            // Загрузить данные в таблицу User. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.UserTableAdapter marathonDataSetUserTableAdapter = new WpfApp1.marathonDataSetTableAdapters.UserTableAdapter();
            marathonDataSetUserTableAdapter.Fill(marathonDataSet.User);
            System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
            userViewSource.View.MoveCurrentToFirst();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddAnewUser addAnewUser = new AddAnewUser();
            addAnewUser.ShowDialog();
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            // Загрузить данные в таблицу User. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.UserTableAdapter marathonDataSetUserTableAdapter = new WpfApp1.marathonDataSetTableAdapters.UserTableAdapter();
            marathonDataSetUserTableAdapter.Fill(marathonDataSet.User);
            System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
            userViewSource.View.MoveCurrentToFirst();
        }
    }
}
