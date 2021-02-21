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
    public partial class BMIcalculator : Window
    {
        public BMIcalculator()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            PeopleImg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "bmi-healthy-icon.png", UriKind.Absolute));
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

        private void FmaleIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MaleTbox.Background = Brushes.White;
            FmaleTbox.Background = Brushes.Gray;
        }

        private void MaleIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MaleTbox.Background = Brushes.Gray;
            FmaleTbox.Background = Brushes.White;
        }

        private void calculation_Click(object sender, RoutedEventArgs e)
        {
           
            Double bmi; 
            #region Calculation Bmi
            int growth;
            int weight;
            try
            {
                growth = Convert.ToInt32(growthTbox.Text);
                weight = Convert.ToInt32(weightTbox.Text);
            }
            catch { MessageBox.Show("Введите только числа"); return; }
            Runner runner = new Runner();
            bmi = runner.CalculationBmi(growth, weight);
            #endregion
            #region Bmi
            if (bmi > 200)
            {
                MessageBox.Show("Введите корректный рост и вес"); return;
            }
            if (bmi < 0) { Slider.Value = 0;return; }
            if (bmi > 35) { Slider.Value = 35; }
            if (bmi < 18.5) 
            { 
                Slider.Value = bmi;
                PeopleImg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "bmi-underweight-icon.png", UriKind.Absolute));
                BmiTbox.Text = bmi.ToString();
            }
            if(bmi>18.5 && bmi<24.9)
            {
                Slider.Value = bmi;
                PeopleImg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "bmi-healthy-icon.png", UriKind.Absolute));
                BmiTbox.Text = bmi.ToString();
            }
            if(bmi>24.9 && bmi<30)
            {
                Slider.Value = bmi;
                PeopleImg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "bmi-overweight-icon.png", UriKind.Absolute));
                BmiTbox.Text = bmi.ToString();
            }
            if(bmi>30)
            {
                Slider.Value = bmi;
                PeopleImg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "bmi-obese-icon.png", UriKind.Absolute));
                BmiTbox.Text = bmi.ToString();
            }

            #endregion
        }


        private void Clearing_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
