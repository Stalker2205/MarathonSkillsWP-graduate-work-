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
    public partial class Inventory : Window
    {
        public Inventory()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Img1.Source = Img2.Source = Img3.Source = Img4.Source = Img5.Source = Img6.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "cross-icon.png", UriKind.Absolute));
            timerStart();
            WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));
            marathonDataSetTableAdapters.Registration1TableAdapter registration1TableAdapter = new marathonDataSetTableAdapters.Registration1TableAdapter();
            registration1TableAdapter.A(marathonDataSet.Registration1);
            TypeA0.Text = TypeA1.Text = TypeA2.Text = marathonDataSet.Registration1[0][1].ToString();
            registration1TableAdapter.B(marathonDataSet.Registration1);
            TypeB0.Text = TypeB1.Text = TypeB2.Text = TypeB3.Text = TypeB4.Text = marathonDataSet.Registration1[0][1].ToString();
            registration1TableAdapter.C(marathonDataSet.Registration1);
            TypeC0.Text = TypeC1.Text = TypeC2.Text = TypeC3.Text = TypeC4.Text = TypeC5.Text = TypeC6.Text = marathonDataSet.Registration1[0][1].ToString();
            marathonDataSetTableAdapters.InventoryTableAdapter inventoryTableAdapter = new marathonDataSetTableAdapters.InventoryTableAdapter();
            inventoryTableAdapter.Fill(marathonDataSet.Inventory);
            neob0.Text = Convert.ToString(Convert.ToInt32(TypeA0.Text) + Convert.ToInt32(TypeB0.Text) + Convert.ToInt32(TypeC0.Text));
            neob1.Text = Convert.ToString(Convert.ToInt32(TypeA1.Text) + Convert.ToInt32(TypeB1.Text) + Convert.ToInt32(TypeC1.Text));
            neob2.Text = Convert.ToString(Convert.ToInt32(TypeA2.Text) + Convert.ToInt32(TypeB2.Text) + Convert.ToInt32(TypeC2.Text));
            neob3.Text = Convert.ToString(Convert.ToInt32(TypeB3.Text) + Convert.ToInt32(TypeC3.Text));
            neob4.Text = Convert.ToString(Convert.ToInt32(TypeB4.Text) + Convert.ToInt32(TypeC4.Text));
            neob5.Text = Convert.ToString(Convert.ToInt32(TypeC5.Text));
            neob6.Text = Convert.ToString(Convert.ToInt32(TypeC6.Text));
            ost1.Text = marathonDataSet.Inventory[0][2].ToString();
            ost2.Text = marathonDataSet.Inventory[1][2].ToString();
            ost3.Text = marathonDataSet.Inventory[2][2].ToString();
            ost4.Text = marathonDataSet.Inventory[3][2].ToString();
            ost5.Text = marathonDataSet.Inventory[4][2].ToString();
            ost6.Text = marathonDataSet.Inventory[5][2].ToString();
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
    }
}
