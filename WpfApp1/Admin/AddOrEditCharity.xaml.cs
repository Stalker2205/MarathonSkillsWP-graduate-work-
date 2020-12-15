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
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AddOrEditCharity : Window
    {
        public AddOrEditCharity()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            if (Perem.key == 0)
            {
                WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(FindResource("marathonDataSet")));
                // Загрузить данные в таблицу Charity. Можно изменить этот код как требуется.
                WpfApp1.marathonDataSetTableAdapters.CharityTableAdapter marathonDataSetCharityTableAdapter = new WpfApp1.marathonDataSetTableAdapters.CharityTableAdapter();
                marathonDataSetCharityTableAdapter.Fill(marathonDataSet.Charity);
                marathonDataSetCharityTableAdapter.SerchID(marathonDataSet.Charity, Perem.CharityID);
                System.Windows.Data.CollectionViewSource charityViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("charityViewSource")));
                charityViewSource.View.MoveCurrentToFirst();
                Logo = charityLogoTextBox.Text;
                LogoImg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + charityLogoTextBox.Text, UriKind.Absolute));
                charityLogoTextBox.Text = "";

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
        string Logo;
        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Files|*.jpg;*.jpeg;*.png;";
                if (Convert.ToBoolean(openFile.ShowDialog()))
                {
                    string FilePath = openFile.FileName;
                    string FileName = openFile.SafeFileName;
                    System.IO.File.Copy(FilePath, AppDomain.CurrentDomain.BaseDirectory + FileName);
                    LogoImg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + FileName, UriKind.Absolute));
                    charityLogoTextBox.Text = FileName;
                }
            }
            catch { MessageBox.Show("Это имя занято"); return; }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));
            marathonDataSetTableAdapters.CharityTableAdapter charityTableAdapter = new marathonDataSetTableAdapters.CharityTableAdapter();
            if (Perem.key == 0)
            {

                if (charityNameTextBox.Text.Length == 0) { MessageBox.Show("Введите наименование организации"); return; }
                if (charityLogoTextBox.Text.Length == 0)
                {
                    charityTableAdapter.UpdateID(charityNameTextBox.Text, charityDescriptionTextBox.Text, Logo, Perem.CharityID);
                    Close();
                }
                else
                {
                    charityTableAdapter.UpdateID(charityNameTextBox.Text, charityDescriptionTextBox.Text, charityLogoTextBox.Text, Perem.CharityID);
                    Close();

                }
            }
            else
            {
                if (charityNameTextBox.Text.Length == 0) { MessageBox.Show("Введите название организации"); return; }
                if (charityDescriptionTextBox.Text.Length == 0) { MessageBox.Show("Введите описание организации"); return; }
                if (charityLogoTextBox.Text.Length == 0) { MessageBox.Show("Выберите лого"); return; }
                charityTableAdapter.InsertChariti(charityNameTextBox.Text, charityDescriptionTextBox.Text, charityLogoTextBox.Text);
                Close();
                
            }

        }

        private void CloseForm_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
