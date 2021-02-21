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
    public partial class VolounteerManagement : Window
    {
        public VolounteerManagement()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            // Загрузить данные в таблицу Volonter1. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.Volonter1TableAdapter marathonDataSetVolonter1TableAdapter = new WpfApp1.marathonDataSetTableAdapters.Volonter1TableAdapter();
            marathonDataSetVolonter1TableAdapter.Fill(marathonDataSet.Volonter1);
            System.Windows.Data.CollectionViewSource volonter1ViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("volonter1ViewSource")));
            volonter1ViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Volunteer. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.VolunteerTableAdapter marathonDataSetVolunteerTableAdapter = new WpfApp1.marathonDataSetTableAdapters.VolunteerTableAdapter();
            marathonDataSetVolunteerTableAdapter.Fill(marathonDataSet.Volunteer);
            System.Windows.Data.CollectionViewSource volunteerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("volunteerViewSource")));
            volunteerViewSource.View.MoveCurrentToFirst();
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

        private void NameButton_Click(object sender, RoutedEventArgs e)
        {
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            marathonDataSetTableAdapters.Volonter1TableAdapter charity1TableAdapter = new marathonDataSetTableAdapters.Volonter1TableAdapter();
            charity1TableAdapter.SortName(marathonDataSet.Volonter1);
            FiltrComboBox.Text = NameButton.Name;
        }

        private void LastNameButton_Click(object sender, RoutedEventArgs e)
        {
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            marathonDataSetTableAdapters.Volonter1TableAdapter charity1TableAdapter = new marathonDataSetTableAdapters.Volonter1TableAdapter();
            charity1TableAdapter.SortLastName(marathonDataSet.Volonter1);
            FiltrComboBox.Text = LastNameButton.Name;
        }

        private void CountryButton_Click(object sender, RoutedEventArgs e)
        {
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            marathonDataSetTableAdapters.Volonter1TableAdapter charity1TableAdapter = new marathonDataSetTableAdapters.Volonter1TableAdapter();
            charity1TableAdapter.SortCountry(marathonDataSet.Volonter1);
            FiltrComboBox.Text = CountryButton.Name;
        }

        private void GenderButton_Click(object sender, RoutedEventArgs e)
        {
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            marathonDataSetTableAdapters.Volonter1TableAdapter charity1TableAdapter = new marathonDataSetTableAdapters.Volonter1TableAdapter();
            charity1TableAdapter.SortGender(marathonDataSet.Volonter1);
            FiltrComboBox.Text = GenderButton.Name;
        }
    }
}
