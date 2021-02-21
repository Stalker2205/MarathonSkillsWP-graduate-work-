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
    public partial class MySponsor : Window
    {
        public MySponsor()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            // Загрузить данные в таблицу Charity. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.CharityTableAdapter marathonDataSetCharityTableAdapter = new WpfApp1.marathonDataSetTableAdapters.CharityTableAdapter();
            marathonDataSetCharityTableAdapter.Fill(marathonDataSet.Charity);
            System.Windows.Data.CollectionViewSource charityViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("charityViewSource")));
            charityViewSource.View.MoveCurrentToFirst();
            // TODO: Добавить сюда код, чтобы загрузить данные в таблицу MySponsor.
            // Не удалось создать этот код, поскольку метод marathonDataSetMySponsorTableAdapter.Fill отсутствует или имеет неизвестные параметры.
            WpfApp1.marathonDataSetTableAdapters.MySponsorTableAdapter marathonDataSetMySponsorTableAdapter = new WpfApp1.marathonDataSetTableAdapters.MySponsorTableAdapter();
            marathonDataSetMySponsorTableAdapter.SumAmount(Convert.ToInt32(Libra.Runner.ID));//посчитали сколько всего пожертвований
            SumAmountTbox.Text = $"${Convert.ToString( marathonDataSetMySponsorTableAdapter.SumAmount(Convert.ToInt32(Libra.Runner.ID)))}";
            marathonDataSetMySponsorTableAdapter.Fill(marathonDataSet.MySponsor,Convert.ToInt32( Libra.Runner.ID));//заполняем таблицу на бегуна
            System.Windows.Data.CollectionViewSource mySponsorViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("mySponsorViewSource")));
            mySponsorViewSource.View.MoveCurrentToFirst();

            int kod = Convert.ToInt32(marathonDataSet.MySponsor[0][1].ToString());
            marathonDataSetCharityTableAdapter.SerchID(marathonDataSet.Charity,kod );
            CharitiNameTbox.Text =Convert.ToString( marathonDataSet.Charity[0][1]);
            CharityLogoImg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + marathonDataSet.Charity[0][3].ToString(), UriKind.Absolute));
            charityDescriptionTextBlock.Text = Convert.ToString(marathonDataSet.Charity[0][2]);

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
