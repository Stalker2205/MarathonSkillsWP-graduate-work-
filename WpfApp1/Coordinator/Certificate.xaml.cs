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
    public partial class Certificate : Window
    {
        public Certificate()
        {
            InitializeComponent();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            marathonDataSet marathonDataSet = ((marathonDataSet)(FindResource("marathonDataSet")));
            marathonDataSetTableAdapters.CertificateTableAdapter certificateTableAdapter = new marathonDataSetTableAdapters.CertificateTableAdapter();
            certificateTableAdapter.Fill(marathonDataSet.Certificate); 
            System.Windows.Data.CollectionViewSource certificateViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("certificateViewSource")));
            certificateViewSource.View.MoveCurrentToFirst();
            certificateTableAdapter.SerchByEmailAndEventName(marathonDataSet.Certificate, Libra.Runner.Email, Libra.Event.distance);
            EventNameTbox.Text = $"Марафон : {Libra.Event.distance}";
            int zerro = 0;
            string ss = marathonDataSet.Certificate[0][1].ToString();
            if (marathonDataSet.Certificate[0][1].ToString() == "") { zerro = 0; } else { zerro = Convert.ToInt32( marathonDataSet.Certificate[0][1].ToString()); }
            InfaTbox.Text = $"Поздравляем {Libra.Runner.FirstName} {Libra.Runner.LastName} с участием в {Libra.Event.distance}. ваше время : {zerro}";

          
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
