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
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class SpisokOrg : Window
    {
        public SpisokOrg()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));
            // Загрузить данные в таблицу Charity1. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.Charity1TableAdapter marathonDataSetCharity1TableAdapter = new WpfApp1.marathonDataSetTableAdapters.Charity1TableAdapter();
            marathonDataSetCharity1TableAdapter.Fill(marathonDataSet.Charity1);
            System.Windows.Data.CollectionViewSource charity1ViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("charity1ViewSource")));
            charity1ViewSource.View.MoveCurrentToFirst();
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
            DataRowView row = (DataRowView)charity1DataGrid.Items[1];
            row[1] = "gdfjgjdoigoidf";
        }
    }
}
