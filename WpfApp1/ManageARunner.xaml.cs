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
    public partial class ManageARunner : Window
    {
        public ManageARunner()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            // Загрузить данные в таблицу ManageArunnerGrid. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.ManageArunnerGridTableAdapter marathonDataSetManageArunnerGridTableAdapter = new WpfApp1.marathonDataSetTableAdapters.ManageArunnerGridTableAdapter();
            marathonDataSetManageArunnerGridTableAdapter.Fill(marathonDataSet.ManageArunnerGrid);
            System.Windows.Data.CollectionViewSource manageArunnerGridViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("manageArunnerGridViewSource")));
            manageArunnerGridViewSource.View.MoveCurrentToFirst();
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
    }
}
