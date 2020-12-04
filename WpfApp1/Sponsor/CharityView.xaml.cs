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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для CharityView.xaml
    /// </summary>
    public partial class CharityView : Window
    {
        public CharityView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Image logo = new Image();
            WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));
            WpfApp1.marathonDataSetTableAdapters.DataTable2TableAdapter dataTable2TableAdapter = new marathonDataSetTableAdapters.DataTable2TableAdapter();
            WpfApp1.marathonDataSetTableAdapters.DataTable1TableAdapter dataTable1TableAdapter = new marathonDataSetTableAdapters.DataTable1TableAdapter();
            dataTable1TableAdapter.findID(marathonDataSet.DataTable1, Perem.Runner);
            string id = marathonDataSet.DataTable1[0][1].ToString();
            dataTable2TableAdapter.FillBy(marathonDataSet.DataTable2, Convert.ToInt32(id));
            Perem.CharityName = marathonDataSet.DataTable2[0][1].ToString();
            Perem.CharityDescription = marathonDataSet.DataTable2[0][2].ToString();
            Perem.LogoName = marathonDataSet.DataTable2[0][3].ToString();
            string sor = $"pack://application:,,,/Images\\diabetes_brazil_logo.png";
            
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri($"Images\\{Perem.LogoName}", UriKind.Relative) ;
            logo.EndInit();
            CharityName.Content = Perem.CharityName;
            CharityDiscription.Text = Perem.CharityDescription;
            ImageLogo.Source = logo;
        }
    }
}
