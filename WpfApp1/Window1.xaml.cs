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

            //WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));
            //// Загрузить данные в таблицу Charity. Можно изменить этот код как требуется.
            //WpfApp1.marathonDataSetTableAdapters.CharityTableAdapter marathonDataSetCharityTableAdapter = new WpfApp1.marathonDataSetTableAdapters.CharityTableAdapter();
            //marathonDataSetCharityTableAdapter.Fill(marathonDataSet.Charity);
            //System.Windows.Data.CollectionViewSource charityViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("charityViewSource")));
            //charityViewSource.View.MoveCurrentToFirst();
            //// Загрузить данные в таблицу DataTable3. Можно изменить этот код как требуется.
            //WpfApp1.marathonDataSetTableAdapters.DataTable3TableAdapter marathonDataSetDataTable3TableAdapter = new WpfApp1.marathonDataSetTableAdapters.DataTable3TableAdapter();
            //marathonDataSetDataTable3TableAdapter.Fill(marathonDataSet.DataTable3,Runner.ID,ec);
            //System.Windows.Data.CollectionViewSource dataTable3ViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("dataTable3ViewSource")));
            //dataTable3ViewSource.View.MoveCurrentToFirst();
        }
    }
}
