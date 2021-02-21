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
    public partial class PreviousRaceResult : Window
    {
        public PreviousRaceResult()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            // TODO: Добавить сюда код, чтобы загрузить данные в таблицу AllMarathon.
            // Не удалось создать этот код, поскольку метод marathonDataSetAllMarathonTableAdapter.Fill отсутствует или имеет неизвестные параметры.
            WpfApp1.marathonDataSetTableAdapters.AllMarathonTableAdapter marathonDataSetAllMarathonTableAdapter = new WpfApp1.marathonDataSetTableAdapters.AllMarathonTableAdapter();
            marathonDataSetAllMarathonTableAdapter.Fill(marathonDataSet.AllMarathon, "Marathon Skills 2012");
            System.Windows.Data.CollectionViewSource allMarathonViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("allMarathonViewSource")));
            allMarathonViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Marathon. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.MarathonTableAdapter marathonDataSetMarathonTableAdapter = new WpfApp1.marathonDataSetTableAdapters.MarathonTableAdapter();
            marathonDataSetMarathonTableAdapter.Fill(marathonDataSet.Marathon);
            System.Windows.Data.CollectionViewSource marathonViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("marathonViewSource")));
            marathonViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Runner. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.RunnerTableAdapter marathonDataSetRunnerTableAdapter = new WpfApp1.marathonDataSetTableAdapters.RunnerTableAdapter();
            marathonDataSetRunnerTableAdapter.Fill(marathonDataSet.Runner);
            System.Windows.Data.CollectionViewSource runnerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("runnerViewSource")));
            runnerViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Marathon. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.MarathonTableAdapter marathonDataSetMarathonTableAdapter1 = new WpfApp1.marathonDataSetTableAdapters.MarathonTableAdapter();
            marathonDataSetMarathonTableAdapter1.Fill(marathonDataSet.Marathon);
            System.Windows.Data.CollectionViewSource marathonViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("marathonViewSource")));
            marathonViewSource1.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Runner. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.RunnerTableAdapter marathonDataSetRunnerTableAdapter2 = new WpfApp1.marathonDataSetTableAdapters.RunnerTableAdapter();
            marathonDataSetRunnerTableAdapter2.Fill(marathonDataSet.Runner);
            System.Windows.Data.CollectionViewSource runnerViewSource2 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("runnerViewSource")));
            runnerViewSource2.View.MoveCurrentToFirst();
            marathonNameComboBox.Text = "Marathon Skills 2012";
            AllRunnerTbox.Text = $"Всего бегунов: {marathonDataSetAllMarathonTableAdapter.KolvoAll("Marathon Skills 2012")}";
            FinishedRunnerTbox.Text = $"Всего финишировало:{marathonDataSetAllMarathonTableAdapter.KolvoFinished("Marathon Skills 2012")}";
            AvgTime.Text = $"Среднее время: {marathonDataSetAllMarathonTableAdapter.SrednVremy("Marathon Skills 2012")} ";
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

        private void marathonNameComboBox_DropDownClosed(object sender, EventArgs e)
        {
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            // TODO: Добавить сюда код, чтобы загрузить данные в таблицу AllMarathon.
            // Не удалось создать этот код, поскольку метод marathonDataSetAllMarathonTableAdapter.Fill отсутствует или имеет неизвестные параметры.
            WpfApp1.marathonDataSetTableAdapters.AllMarathonTableAdapter marathonDataSetAllMarathonTableAdapter = new WpfApp1.marathonDataSetTableAdapters.AllMarathonTableAdapter();
            marathonDataSetAllMarathonTableAdapter.Fill(marathonDataSet.AllMarathon, marathonNameComboBox.Text);
            System.Windows.Data.CollectionViewSource allMarathonViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("allMarathonViewSource")));
            allMarathonViewSource.View.MoveCurrentToFirst();
            AllRunnerTbox.Text = $"Всего бегунов: {marathonDataSetAllMarathonTableAdapter.KolvoAll(marathonNameComboBox.Text)}";
            FinishedRunnerTbox.Text = $"Всего финишировало:{marathonDataSetAllMarathonTableAdapter.KolvoFinished(marathonNameComboBox.Text)}";
            AvgTime.Text = $"Среднее время: {marathonDataSetAllMarathonTableAdapter.SrednVremy(marathonNameComboBox.Text)} ";
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {

            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            // TODO: Добавить сюда код, чтобы загрузить данные в таблицу AllMarathon.
            // Не удалось создать этот код, поскольку метод marathonDataSetAllMarathonTableAdapter.Fill отсутствует или имеет неизвестные параметры.
            WpfApp1.marathonDataSetTableAdapters.AllMarathonTableAdapter marathonDataSetAllMarathonTableAdapter = new WpfApp1.marathonDataSetTableAdapters.AllMarathonTableAdapter();
            marathonDataSetAllMarathonTableAdapter.SerchGender(marathonDataSet.AllMarathon, marathonNameComboBox.Text, GenderCbox.Text);
        }
    }
}
