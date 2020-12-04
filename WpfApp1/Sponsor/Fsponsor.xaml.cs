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
using System.Windows.Threading;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Fsponsor.xaml
    /// </summary>
    public partial class Fsponsor : Window
    {
        public Fsponsor()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));
            // Загрузить данные в таблицу DataTable1. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.DataTable1TableAdapter marathonDataSetDataTable1TableAdapter = new WpfApp1.marathonDataSetTableAdapters.DataTable1TableAdapter();
            marathonDataSetDataTable1TableAdapter.FillBy1(marathonDataSet.DataTable1);
            System.Windows.Data.CollectionViewSource dataTable1ViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("dataTable1ViewSource")));
            dataTable1ViewSource.View.MoveCurrentToFirst();
            string ss = expr1ComboBox.Text;
            Perem.PeopleName = expr1ComboBox.Text;
          //  WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));
            WpfApp1.marathonDataSetTableAdapters.DataTable2TableAdapter dataTable2TableAdapter = new marathonDataSetTableAdapters.DataTable2TableAdapter();
            WpfApp1.marathonDataSetTableAdapters.DataTable1TableAdapter dataTable1TableAdapter = new marathonDataSetTableAdapters.DataTable1TableAdapter();
            dataTable1TableAdapter.findID(marathonDataSet.DataTable1, expr1ComboBox.Text);
            string id = marathonDataSet.DataTable1[0][1].ToString();
            dataTable2TableAdapter.FillBy(marathonDataSet.DataTable2, Convert.ToInt32(id));
            OrgName.Content = marathonDataSet.DataTable2[0][1].ToString();
            dataTable1TableAdapter.FillBy1(marathonDataSet.DataTable1);
            expr1ComboBox.Text = ss;
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
            DateTime nn = DateTime.Now;
            DateTime n1 = Convert.ToDateTime("10.12.2020 18:30:25");
            int day = n1.Day - nn.Day;
            int min = (n1.Hour * 60 + n1.Minute) - (nn.Hour * 60 + nn.Minute);
            int hour = 0;
            while (min > 60)
            {
                min -= 60;
                hour++;
            }
            LabelTime.Content = $"{day} дней {hour} часов и {min} минут до старта марафона!";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(TboxPrice.Text);
            }
            catch { MessageBox.Show("Сумма пожертвований должна быть числом"); return; }
            LPric.Content = "$" + Convert.ToString(Convert.ToInt32(TboxPrice.Text) + 10);
            TboxPrice.Text = Convert.ToString(Convert.ToInt32(TboxPrice.Text) + 10);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(TboxPrice.Text);
            }
            catch { MessageBox.Show("Сумма пожертвований должна быть числом"); return; }
            if (Convert.ToInt32(TboxPrice.Text) == 0 || Convert.ToInt32(TboxPrice.Text) < 0)
            {
                MessageBox.Show("Сумма не может быть меньше или равна 0");
                return;
            }
            LPric.Content = "$" + Convert.ToString(Convert.ToInt32(TboxPrice.Text) - 10);
            TboxPrice.Text = Convert.ToString(Convert.ToInt32(TboxPrice.Text) - 10);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(TboxPrice.Text);
            }
            catch { MessageBox.Show("Сумма пожертвований должна быть числом"); return; }
            if (Convert.ToInt32(TboxPrice.Text) == 0 || Convert.ToInt32(TboxPrice.Text) < 0)
            {
                MessageBox.Show("Сумма не может быть меньше или равна 0");
                return;
            }
            if (TboxName1.Text.Length == 0) { MessageBox.Show("Введите имя и фамилию плательщика"); return; }
            if (expr1ComboBox.SelectedIndex == -1) { MessageBox.Show("Выберите"); return; }
            if (TboxVladCart.Text.Length == 0) { MessageBox.Show("Введите владельца карты"); return; }
            if (TboxNumberCart.Text.Length != 16) { MessageBox.Show("Номер карты должен состоять из 16 цифр"); return; }
            int iwwwe;
            int iwwwe1;
            try
            {
                iwwwe =  Convert.ToInt32(TboxNumberCart.Text.Substring(0,8));
                iwwwe1 = Convert.ToInt32(TboxNumberCart.Text.Substring(8, 8));
            }
            catch { MessageBox.Show("Номер карты должен состоять только из цифр"); return; }
            if(Convert.ToInt32(TboxSrokMunf.Text) > 12) { MessageBox.Show("Месяц не может быть больше 12"); }
            if (TboxSrokMunf.Text.Length == 0) { MessageBox.Show("Введите месяц на карте"); return; }
            if (TboxSrokYear.Text.Length == 0) { MessageBox.Show("Введите год карты"); return; }
            if (TboxCVC.Text.Length == 0) { MessageBox.Show("Введите CVC"); return; }
            try
            {
                Convert.ToInt32(TboxSrokMunf.Text);
                Convert.ToInt32(TboxSrokYear.Text);
                Convert.ToInt32(TboxCVC.Text);
            }
            catch
            {
                MessageBox.Show("срок дейсвия и CVC должен быть числом "); return;
            }
            if (Convert.ToInt32(TboxSrokYear.Text) < DateTime.Now.Year)
            {
                MessageBox.Show("Ваша карта не действительна"); return;
            }
            else
            {
                WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));
                WpfApp1.marathonDataSetTableAdapters.DataTable1TableAdapter dataTable1TableAdapter = new marathonDataSetTableAdapters.DataTable1TableAdapter();
                int i = dataTable1TableAdapter.findID(marathonDataSet.DataTable1, expr1ComboBox.Text);
                string h = marathonDataSet.DataTable1[0][1].ToString();
                WpfApp1.marathonDataSetTableAdapters.SponsorshipTableAdapter sponsorshipTableAdapter = new marathonDataSetTableAdapters.SponsorshipTableAdapter();
                sponsorshipTableAdapter.InsertQuery(TboxName1.Text, Convert.ToInt32(h), Convert.ToDecimal(TboxPrice.Text));
                //MessageBox.Show("Спасибо за поддержку"); Close();
                Perem.Price =Convert.ToInt32(TboxPrice.Text);
                Podtw podtw = new Podtw();
                podtw.ShowDialog();
                Close();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CharityView charityView = new CharityView();
            charityView.ShowDialog();
        }

        private void expr1ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            string ss = expr1ComboBox.Text;
            Perem.Runner = expr1ComboBox.Text;
            Perem.PeopleName = expr1ComboBox.Text;
            WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));
            WpfApp1.marathonDataSetTableAdapters.DataTable2TableAdapter dataTable2TableAdapter = new marathonDataSetTableAdapters.DataTable2TableAdapter();
            WpfApp1.marathonDataSetTableAdapters.DataTable1TableAdapter dataTable1TableAdapter = new marathonDataSetTableAdapters.DataTable1TableAdapter();
            dataTable1TableAdapter.findID(marathonDataSet.DataTable1, expr1ComboBox.Text);
            string id = marathonDataSet.DataTable1[0][1].ToString();
            dataTable2TableAdapter.FillBy(marathonDataSet.DataTable2, Convert.ToInt32(id));
            OrgName.Content = marathonDataSet.DataTable2[0][1].ToString();
            dataTable1TableAdapter.FillBy1(marathonDataSet.DataTable1);
            expr1ComboBox.Text = ss;
        }
    }
}
