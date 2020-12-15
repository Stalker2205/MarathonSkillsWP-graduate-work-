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
using System.Windows.Shapes;
using Libra;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));

            // Загрузить данные в таблицу Volonter1. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.Volonter1TableAdapter marathonDataSetVolonter1TableAdapter = new WpfApp1.marathonDataSetTableAdapters.Volonter1TableAdapter();
            marathonDataSetVolonter1TableAdapter.Fill(marathonDataSet.Volonter1);
            System.Windows.Data.CollectionViewSource volonter1ViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("volonter1ViewSource")));
            volonter1ViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Charity. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.CharityTableAdapter marathonDataSetCharityTableAdapter = new WpfApp1.marathonDataSetTableAdapters.CharityTableAdapter();
            marathonDataSetCharityTableAdapter.Fill(marathonDataSet.Charity);
            System.Windows.Data.CollectionViewSource charityViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("charityViewSource")));
            charityViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Volunteer. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.VolunteerTableAdapter marathonDataSetVolunteerTableAdapter = new WpfApp1.marathonDataSetTableAdapters.VolunteerTableAdapter();
            marathonDataSetVolunteerTableAdapter.Fill(marathonDataSet.Volunteer);
            System.Windows.Data.CollectionViewSource volunteerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("volunteerViewSource")));
            volunteerViewSource.View.MoveCurrentToFirst();
        }
    }
}
