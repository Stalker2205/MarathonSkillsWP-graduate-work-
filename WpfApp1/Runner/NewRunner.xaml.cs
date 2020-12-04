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
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class NewRunner : Window
    {
        public NewRunner()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));
            // Загрузить данные в таблицу Gender. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.GenderTableAdapter marathonDataSetGenderTableAdapter = new WpfApp1.marathonDataSetTableAdapters.GenderTableAdapter();
            marathonDataSetGenderTableAdapter.Fill(marathonDataSet.Gender);
            System.Windows.Data.CollectionViewSource genderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("genderViewSource")));
            genderViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Country. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.CountryTableAdapter marathonDataSetCountryTableAdapter = new WpfApp1.marathonDataSetTableAdapters.CountryTableAdapter();
            marathonDataSetCountryTableAdapter.Fill(marathonDataSet.Country);
            System.Windows.Data.CollectionViewSource countryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("countryViewSource")));
            countryViewSource.View.MoveCurrentToFirst();
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
        string Filename;
        string FilePath;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Files|*.jpg;*.jpeg;*.png;";
            if (file.ShowDialog() == true)
            {
                try
                {
                    Filename = file.SafeFileName;
                    FilePath = file.FileName;
                    System.IO.File.Move(file.FileName, AppDomain.CurrentDomain.BaseDirectory + Filename);
                    fotoname.Text = Filename;
                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    img.UriSource = new Uri($"Images\\upbeat-logo.png", UriKind.Relative);
                    img.EndInit();
                    foto.Source = img;
                }
                catch (System.IO.IOException) { MessageBox.Show("Файл с таким именем уже существует"); return; }
            }
        }
    }
}
