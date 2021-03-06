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
using Libra;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class ManageCharities : Window
    {
        public ManageCharities()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));
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
            TimeSpan datet = Perem.datetim();
            LabelTime.Content = $"{datet.Days} дней {datet.Hours} часов и {datet.Minutes} минут до старта марафона!";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)

                if (vis is DataGridRow)
                {
                    Libra.Charity charity = new Libra.Charity();
                    var Selectedsell = this.charityDataGrid.Columns[0].GetCellContent(this.charityDataGrid.SelectedItem);
                    string Cell = Selectedsell.Parent.ToString();
                    string koll = "System.Windows.Controls.DataGridCell: ";
                    Cell = Cell.Remove(0, koll.Length);
                    Cell = Cell.Replace(" ", "");
                    Perem.CharityID = Convert.ToInt32(Cell);
                    AddOrEditCharity addOrEditCharity = new AddOrEditCharity();
                    addOrEditCharity.ShowDialog();
                    WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));
                    // Загрузить данные в таблицу Charity. Можно изменить этот код как требуется.
                    WpfApp1.marathonDataSetTableAdapters.CharityTableAdapter marathonDataSetCharityTableAdapter = new WpfApp1.marathonDataSetTableAdapters.CharityTableAdapter();
                    marathonDataSetCharityTableAdapter.Fill(marathonDataSet.Charity);

                }
        }
    }
}
