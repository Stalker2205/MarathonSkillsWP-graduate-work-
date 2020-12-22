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
            marathonDataSet marathonDataSet = ((marathonDataSet)((FindResource("marathonDataSet"))));
            // Загрузить данные в таблицу ManageArunnerGrid. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.ManageArunnerGridTableAdapter marathonDataSetManageArunnerGridTableAdapter = new WpfApp1.marathonDataSetTableAdapters.ManageArunnerGridTableAdapter();
            marathonDataSetManageArunnerGridTableAdapter.SerchByEmail(marathonDataSet.ManageArunnerGrid, Libra.Runner.Email,Libra.Event.marathon);
            System.Windows.Data.CollectionViewSource manageArunnerGridViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("manageArunnerGridViewSource")));
            manageArunnerGridViewSource.View.MoveCurrentToFirst();
            if (marathonDataSet.ManageArunnerGrid[0][10].ToString() != "")
            {
                FotoImg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + marathonDataSet.ManageArunnerGrid[0][10].ToString(), UriKind.Absolute));
            }
            int kol = Convert.ToInt32(marathonDataSet.ManageArunnerGrid[0][11].ToString());
            switch (kol)
            {
                case 1:
                    {
                        Img1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "IkonOk.png",UriKind.Absolute));
                        Img2.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "IkonNo.png", UriKind.Absolute));
                        Img3.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "IkonNo.png", UriKind.Absolute));
                        Img4.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "IkonNo.png", UriKind.Absolute));

                        return;
                    }
                case 2:
                    {
                        Img1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "IkonOk.png", UriKind.Absolute));
                        Img2.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "IkonOk.png", UriKind.Absolute));
                        Img3.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "IkonNo.png", UriKind.Absolute));
                        Img4.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "IkonNo.png", UriKind.Absolute));
                        return;
                    }
                case 3:
                    {
                        Img1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "IkonOk.png", UriKind.Absolute));
                        Img2.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "IkonOk.png", UriKind.Absolute));
                        Img3.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "IkonOk.png", UriKind.Absolute));
                        Img4.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "IkonNo.png", UriKind.Absolute));
                        return;
                    }
                case 4:
                    {
                        Img1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "IkonOk.png", UriKind.Absolute));
                        Img2.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "IkonOk.png", UriKind.Absolute));
                        Img3.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "IkonOk.png", UriKind.Absolute));
                        Img4.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "IkonOk.png", UriKind.Absolute));
                        return;
                    }

                default:
                    break;
            }
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
