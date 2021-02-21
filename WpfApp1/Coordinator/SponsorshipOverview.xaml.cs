﻿using System;
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
    public partial class SponsorshipOverview : Window
    {
        public SponsorshipOverview()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            // Загрузить данные в таблицу SponsorshipOverview. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.SponsorshipOverviewTableAdapter marathonDataSetSponsorshipOverviewTableAdapter = new WpfApp1.marathonDataSetTableAdapters.SponsorshipOverviewTableAdapter();
            marathonDataSetSponsorshipOverviewTableAdapter.Fill(marathonDataSet.SponsorshipOverview);
            System.Windows.Data.CollectionViewSource sponsorshipOverviewViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("sponsorshipOverviewViewSource")));
            sponsorshipOverviewViewSource.View.MoveCurrentToFirst();
            CharityTbox.Text = $"Благотворительных организаций : {Convert.ToString(marathonDataSetSponsorshipOverviewTableAdapter.CountCharity())}";
            AllMoneyTbox.Text = $"Всего спонсорских взносов : {Convert.ToString(marathonDataSetSponsorshipOverviewTableAdapter.AllMoney())}";
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
