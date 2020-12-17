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
using System.IO;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class RunnerManagement : Window
    {
        public RunnerManagement()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            // Загрузить данные в таблицу RegistrationStatus. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.RegistrationStatusTableAdapter marathonDataSetRegistrationStatusTableAdapter = new WpfApp1.marathonDataSetTableAdapters.RegistrationStatusTableAdapter();
            marathonDataSetRegistrationStatusTableAdapter.Fill(marathonDataSet.RegistrationStatus);
            System.Windows.Data.CollectionViewSource registrationStatusViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("registrationStatusViewSource")));
            registrationStatusViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу EventType. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.EventTypeTableAdapter marathonDataSetEventTypeTableAdapter = new WpfApp1.marathonDataSetTableAdapters.EventTypeTableAdapter();
            marathonDataSetEventTypeTableAdapter.Fill(marathonDataSet.EventType);
            System.Windows.Data.CollectionViewSource eventTypeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("eventTypeViewSource")));
            eventTypeViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу RunnerManag. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.RunnerManagTableAdapter marathonDataSetRunnerManagTableAdapter = new WpfApp1.marathonDataSetTableAdapters.RunnerManagTableAdapter();
            marathonDataSetRunnerManagTableAdapter.Fill(marathonDataSet.RunnerManag);
            System.Windows.Data.CollectionViewSource runnerManagViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("runnerManagViewSource")));
            runnerManagViewSource.View.MoveCurrentToFirst();
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

        private void registrationStatusComboBox_DropDownClosed(object sender, EventArgs e)
        {
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            marathonDataSetTableAdapters.RunnerManagTableAdapter runnerManagTableAdapter = new marathonDataSetTableAdapters.RunnerManagTableAdapter();
            runnerManagTableAdapter.SerchStatys(marathonDataSet.RunnerManag, registrationStatusComboBox.Text);
        }

        private void eventTypeNameComboBox_DropDownClosed(object sender, EventArgs e)
        {
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            marathonDataSetTableAdapters.RunnerManagTableAdapter runnerManagTableAdapter = new marathonDataSetTableAdapters.RunnerManagTableAdapter();
            runnerManagTableAdapter.SerchEvent(marathonDataSet.RunnerManag, eventTypeNameComboBox.Text);
        }

        private void ClearRunnerMAnager_Click(object sender, RoutedEventArgs e)
        {
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            marathonDataSetTableAdapters.RunnerManagTableAdapter runnerManagTableAdapter = new marathonDataSetTableAdapters.RunnerManagTableAdapter();
            runnerManagTableAdapter.Fill(marathonDataSet.RunnerManag);
        }

        private void AllInfo_Click(object sender, RoutedEventArgs e)
        {
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            marathonDataSetTableAdapters.RunnerManagTableAdapter runnerManagTableAdapter = new marathonDataSetTableAdapters.RunnerManagTableAdapter();
           // runnerManagTableAdapter.Fill(marathonDataSet.RunnerManag);
            string Cont;
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "Ашдумв", "fsdfsd \n");
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.Filter = "Documents (.csv)|*.csv";
            try
            {
                if (saveFileDialog.ShowDialog() == true)
                {
                    StreamWriter OutFile = new StreamWriter(saveFileDialog.FileName);
                    MessageBox.Show("Внимание!, если записей много - это может занять некоторое время, дождитесь подсказки: 'Выгружено'"); 
                    for (int i = 0; i < marathonDataSet.RunnerManag.Count; i++)
                    {

                        OutFile.WriteLine(  marathonDataSet.RunnerManag[i][0].ToString() + "," + marathonDataSet.RunnerManag[i][1].ToString() + "," + marathonDataSet.RunnerManag[i][2].ToString() + "," +
                            marathonDataSet.RunnerManag[i][4].ToString() + "\n");
                    }
                    MessageBox.Show("Выгружено");
                    OutFile.Close();

                }
            }
            catch { MessageBox.Show("Файл с таким именем уже существует");return; }
        }

        private void EmailSpisok_Click(object sender, RoutedEventArgs e)
        {
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            marathonDataSetTableAdapters.RunnerManagTableAdapter runnerManagTableAdapter = new marathonDataSetTableAdapters.RunnerManagTableAdapter();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            string cons;
            for (int i = 0; i < marathonDataSet.RunnerManag.Count; i++)
            {
                Perem.list.Add(marathonDataSet.RunnerManag[i][0].ToString() + ","+ marathonDataSet.RunnerManag[i][1].ToString() + ","+ marathonDataSet.RunnerManag[i][2].ToString() + ";"+"\n");
            }
            Listik list = new Listik();
            list.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Libra.Runner.Email = sender.ToString().Remove(0, 32).Trim();
        }
    }
}
