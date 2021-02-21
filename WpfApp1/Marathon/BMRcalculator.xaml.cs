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
    public partial class BMRcalculator : Window
    {
        public BMRcalculator()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
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
            PonrInfa ponrInfa = new PonrInfa();
            ponrInfa.Show();
            Close();
        }
        int key = 0;
        private void FmaleIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            key = 1;
            MaleTbox.Background = Brushes.White;
            FmaleTbox.Background = Brushes.Gray;
        }

        private void MaleIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            key = 2;
            MaleTbox.Background = Brushes.Gray;
            FmaleTbox.Background = Brushes.White;
        }

        private void Calculation_Click(object sender, RoutedEventArgs e)
        {
            #region Checks
            if (Growth.Text.Length == 0) { MessageBox.Show("Введите рост"); return; }
            if (Weight.Text.Length == 0) { MessageBox.Show("Введите вес"); return; }
            if (Age.Text.Length == 0) { MessageBox.Show("Введите возраст"); return; }
            try
            {
                Convert.ToInt32(Growth.Text);
                Convert.ToInt32(Weight.Text);
                Convert.ToInt32(Age.Text);
            }
            catch { MessageBox.Show("Рост,вес и возраст должны быть числами"); return; }
            if (Convert.ToInt32(Age.Text) > 130) { MessageBox.Show("Вам не может быть больше 130 лет"); return; }
            #endregion
            double Bmr;
            if (key == 0) { MessageBox.Show("Выберите пол"); return; }
            if (key == 1)//Женщина
            {
                Bmr = 655 + (9.6 * Convert.ToInt32(Weight.Text)) + (1.8 * Convert.ToInt32(Growth.Text)) - (4.7 * Convert.ToInt32(Age.Text));
                SitActivityTbox.Text = Convert.ToString(Bmr * 1.2);
                BmrTbox.Text = Convert.ToString(Bmr);
                LowActivityTbox.Text = Convert.ToString(Bmr * 1.375);
                StrongActivityTbox.Text = Convert.ToString(Bmr * 1.55);
                AverageActivityTbox.Text = Convert.ToString(Bmr * 1.725);
                MaximumActivityTbox.Text = Convert.ToString(Bmr * 1.9);
            }
            else//мужчина
            {
                Bmr = 66 + (13.7 * Convert.ToInt32(Weight.Text)) + (5 * Convert.ToInt32(Growth.Text)) - (6.8 * Convert.ToInt32(Age.Text));
                SitActivityTbox.Text = Convert.ToString(Bmr * 1.2);
                BmrTbox.Text = Convert.ToString(Bmr);
                LowActivityTbox.Text = Convert.ToString(Bmr * 1.375);
                StrongActivityTbox.Text = Convert.ToString(Bmr * 1.55);
                AverageActivityTbox.Text = Convert.ToString(Bmr * 1.725);
                MaximumActivityTbox.Text = Convert.ToString(Bmr * 1.9);
            }
        }

        private void Cloasing_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Info_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Сидячий образ - Нет работы или работа за столом \n\n" +
                "Маленькая активность - Мало физических работы или занятия спортом 1-3 раза в неделю \n\n" +
                "Средняя активность - Умеренная физическая работа или занятия спортом 3 - 5 дней в неделю\n\n" +
                "Сильная активность - Сильные физическая нагрузка или занятия спортом 6 - 7 дней в неделю\n\n" +
                "Максимальная активность - Сильная ежедневная физическая нагрузка или спорт и физическая работа");
        }
    }
}
