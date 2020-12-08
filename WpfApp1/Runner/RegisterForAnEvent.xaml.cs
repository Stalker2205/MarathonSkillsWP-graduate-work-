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
using Libra;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class RegisterForAnEvent : Window
    {
        public RegisterForAnEvent()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            WpfApp1.marathonDataSet marathonDataSet = ((marathonDataSet)(this.FindResource("marathonDataSet")));
            // Загрузить данные в таблицу Charity. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.CharityTableAdapter marathonDataSetCharityTableAdapter = new WpfApp1.marathonDataSetTableAdapters.CharityTableAdapter();
            marathonDataSetCharityTableAdapter.Fill(marathonDataSet.Charity);
            System.Windows.Data.CollectionViewSource charityViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("charityViewSource")));
            charityViewSource.View.MoveCurrentToFirst();
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
        int priceAll = 0;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));
            WpfApp1.marathonDataSetTableAdapters.RunnerTableAdapter runnerTableAdapter = new marathonDataSetTableAdapters.RunnerTableAdapter();
            WpfApp1.marathonDataSetTableAdapters.RegistrationTableAdapter registrationTableAdapter = new marathonDataSetTableAdapters.RegistrationTableAdapter();
            WpfApp1.marathonDataSetTableAdapters.CharityTableAdapter charityTableAdapter = new marathonDataSetTableAdapters.CharityTableAdapter();
            if (!(bool)KM32.IsChecked && !(bool)KM23.IsChecked && !(bool)KM5.IsChecked)
            {
                MessageBox.Show("Выберите хотя бы 1 дистанцию"); return;
            }
            if (!(bool)VarA.IsChecked && !(bool)VarB.IsChecked && !(bool)VarC.IsChecked)
            {
                MessageBox.Show("Выберите комплект"); return;
            }
            try
            {
                Convert.ToInt32(PriceTextBox.Text);
            }
            catch { MessageBox.Show("Сумма взноса должна быть числом"); }
            runnerTableAdapter.Runner(marathonDataSet.Runner, Runner.Email, Runner.Gender, Runner.CountryCode, Runner.Photo);
            charityTableAdapter.FillBy(marathonDataSet.Charity, charityNameComboBox.Text);
            int runnerid = Convert.ToInt32(marathonDataSet.Runner[0][0].ToString());     
            if (Convert.ToInt32(PriceTextBox.Text) < Convert.ToInt32(priceAll))
            {
                registrationTableAdapter.InsertReg(runnerid, DateTime.Now, variant, 1, priceAll,Convert.ToInt32( marathonDataSet.Charity[0][0].ToString()),Convert.ToDecimal( Price.Text));
            }
            registrationTableAdapter.InsertReg(runnerid, DateTime.Now, variant, 2, priceAll, Convert.ToInt32(marathonDataSet.Charity[0][0].ToString()), Convert.ToDecimal(priceAll));
            RegistrationConfirmation registrationConfirmation = new RegistrationConfirmation();
            registrationConfirmation.Show();
            Close();
        }

        private void KM32_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(KM32.IsChecked)) { priceAll += 145; } else { priceAll -= 145; }
            Price.Text = $"${priceAll}";
        }

        private void KM23_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(KM23.IsChecked)) { priceAll += 75; } else { priceAll -= 75; }
            Price.Text = $"${priceAll}";
        }

        private void KM5_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(KM5.IsChecked)) { priceAll += 20; } else { priceAll -= 20; }
            Price.Text = $"${priceAll}";
        }
        String variant = "A";
        private void VarA_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(VarA.IsChecked)) { priceAll += 0; }
            Price.Text = $"${priceAll}";
            variant = "A";
        }

        private void VarB_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(VarB.IsChecked)) { priceAll += 20; } else { priceAll -= 20; }
            Price.Text = $"${priceAll}";
            variant = "B";
        }

        private void VarC_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(VarC.IsChecked)) { priceAll += 45; } else { priceAll -= 45; }
            Price.Text = $"${priceAll}";
            variant = "C";
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));
            WpfApp1.marathonDataSetTableAdapters.CharityTableAdapter charityTableAdapter = new marathonDataSetTableAdapters.CharityTableAdapter();
            charityTableAdapter.FillBy(marathonDataSet.Charity, charityNameComboBox.Text);
            Perem.CharityName = marathonDataSet.Charity[0][1].ToString();
            CharityView nn = new CharityView();
            nn.ShowDialog();
            charityTableAdapter.Fill(marathonDataSet.Charity);
        }
    }
}
