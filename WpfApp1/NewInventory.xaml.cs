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
    public partial class NewInventory : Window
    {
        public NewInventory()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
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
            WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));
            marathonDataSetTableAdapters.InventoryTableAdapter inventoryTableAdapter = new marathonDataSetTableAdapters.InventoryTableAdapter();
            inventoryTableAdapter.Fill(marathonDataSet.Inventory);
            int num = Convert.ToInt32(marathonDataSet.Inventory[0][2].ToString()); ;
            int rfid = Convert.ToInt32(marathonDataSet.Inventory[1][2].ToString());
            int beis = Convert.ToInt32(marathonDataSet.Inventory[2][2].ToString());
            int water = Convert.ToInt32(marathonDataSet.Inventory[3][2].ToString());
            int fytbolka = Convert.ToInt32(marathonDataSet.Inventory[4][2].ToString());
            int bykl = Convert.ToInt32(marathonDataSet.Inventory[5][2].ToString());
            inventoryTableAdapter.UpdateQuery("Номер", num + Convert.ToInt32(NumerTbox.Text));
            inventoryTableAdapter.UpdateQuery("RFID", rfid + Convert.ToInt32((Rfid.Text)));
            inventoryTableAdapter.UpdateQuery("Бейсболка", beis + Convert.ToInt32((beisbol.Text)));
            inventoryTableAdapter.UpdateQuery("Бутылка воды", water + Convert.ToInt32((WaterTbox.Text)));
            inventoryTableAdapter.UpdateQuery("Футболка", fytbolka + Convert.ToInt32((FytbTbox.Text)));
            inventoryTableAdapter.UpdateQuery("Сувенирный буклет", bykl + Convert.ToInt32((ByklTbox.Text)));
            Close();

        }
    }
}
