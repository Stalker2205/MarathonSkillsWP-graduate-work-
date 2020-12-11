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
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class EditRunnerProfile : Window
    {
        public EditRunnerProfile()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerStart();
            WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(FindResource("marathonDataSet")));
            // Загрузить данные в таблицу Runner. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.RunnerTableAdapter marathonDataSetRunnerTableAdapter = new WpfApp1.marathonDataSetTableAdapters.RunnerTableAdapter();
            marathonDataSetRunnerTableAdapter.SerchEmail(marathonDataSet.Runner, Runner.Email);
            System.Windows.Data.CollectionViewSource runnerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("runnerViewSource")));
            runnerViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу User. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.UserTableAdapter marathonDataSetUserTableAdapter = new WpfApp1.marathonDataSetTableAdapters.UserTableAdapter();
            marathonDataSetUserTableAdapter.SerchEmail(marathonDataSet.User, Runner.Email);
            System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
            userViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Country. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.CountryTableAdapter marathonDataSetCountryTableAdapter = new WpfApp1.marathonDataSetTableAdapters.CountryTableAdapter();
            marathonDataSetCountryTableAdapter.SerchKod(marathonDataSet.Country, Runner.CountryCode);
            System.Windows.Data.CollectionViewSource countryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("countryViewSource")));
            countryViewSource.View.MoveCurrentToFirst();
            var bitmap = new BitmapImage();
            string sq = AppDomain.CurrentDomain.BaseDirectory + photoTextBox.Text;
            bitmap.BeginInit();
            bitmap.UriSource = new Uri($"{sq}", UriKind.Absolute);
            bitmap.EndInit();
            bitmap.Freeze();
            PhotoUser.Source = bitmap;
            // Загрузить данные в таблицу Gender. Можно изменить этот код как требуется.
            WpfApp1.marathonDataSetTableAdapters.GenderTableAdapter marathonDataSetGenderTableAdapter = new WpfApp1.marathonDataSetTableAdapters.GenderTableAdapter();
            marathonDataSetGenderTableAdapter.Fill(marathonDataSet.Gender);
            System.Windows.Data.CollectionViewSource genderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("genderViewSource")));
            genderViewSource.View.MoveCurrentToFirst();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(FindResource("marathonDataSet")));
            marathonDataSetTableAdapters.CountryTableAdapter countryTableAdapter = new marathonDataSetTableAdapters.CountryTableAdapter();
            countryTableAdapter.Fill(marathonDataSet.Country);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(FindResource("marathonDataSet")));
            WpfApp1.marathonDataSetTableAdapters.RunnerTableAdapter runnerTableAdapter = new marathonDataSetTableAdapters.RunnerTableAdapter();
            WpfApp1.marathonDataSetTableAdapters.CountryTableAdapter countryTableAdapter = new marathonDataSetTableAdapters.CountryTableAdapter();
            WpfApp1.marathonDataSetTableAdapters.UserTableAdapter userTableAdapter = new marathonDataSetTableAdapters.UserTableAdapter();
            if (emailTextBox.Text.Length == 0) { MessageBox.Show("Введите маил"); return; }
            try
            {
                System.Net.Mail.MailAddress mailAddress = new System.Net.Mail.MailAddress(emailTextBox.Text);
            }
            catch { MessageBox.Show("не верный маил"); return; }
            if (firstNameTextBox.Text.Length == 0) { MessageBox.Show("Введите имя"); return; }
            if (lastNameTextBox.Text.Length == 0) { MessageBox.Show("Введите фамилию"); return; }
            if (photoTextBox.Text.Length == 0) { MessageBox.Show("Выберите фото"); return; }
            if (dateOfBirthDatePicker.SelectedDate.Value.Year > DateTime.Now.Year) { MessageBox.Show("Год не может быть больше текущего"); return; }
            if ((DateTime.Now.Year - dateOfBirthDatePicker.SelectedDate.Value.Year) < 10) { MessageBox.Show("дети младше 10 лет не могут быть бегунами"); return; }
            if (PassTbox.Text.Length == 0 && PassTbox1.Text.Length == 0)
            {
                userTableAdapter.UpdateUserPass(firstNameTextBox.Text, lastNameTextBox.Text, Runner.Email);
                runnerTableAdapter.UpdateRunner(genderComboBox.Text, dateOfBirthDatePicker.SelectedDate, countryCodeTextBox.Text, photoTextBox.Text, Runner.Email);

            }
            else
            {
                if (PassTbox.Text != PassTbox1.Text) { MessageBox.Show("Пароли не совпадают"); return; }
                Regex reg = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$");
                string ss = Convert.ToString(reg.Match(PassTbox.Text));
                if (ss.Length == 0)
                {
                    MessageBox.Show("Пароль должен отвечать следующим требованиям:\n" +
                    "•Минимум 6 символов\n•Минимум 1 прописная буква\n•Минимум 1 цифра\n•По крайней мере один из следующих символов: ! @ # $ % ^ "); return;
                }
                userTableAdapter.UpdateUserAndPass(PassTbox.Text, firstNameTextBox.Text, lastNameTextBox.Text, Runner.Email);
                runnerTableAdapter.UpdateRunner(genderComboBox.Text, dateOfBirthDatePicker.SelectedDate, countryCodeTextBox.Text, photoTextBox.Text, Runner.Email);

            }
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string filename;
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Files|*.jpg;*.jpeg;*.png;";
            if (file.ShowDialog() == true)
            {
                //        try
                //{
                filename = file.SafeFileName;
                string sq = AppDomain.CurrentDomain.BaseDirectory + photoTextBox.Text;
                PhotoUser.Source = null;
                //System.IO.File.Delete(sq);
                System.IO.File.Move(file.FileName, AppDomain.CurrentDomain.BaseDirectory + filename);
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + filename, UriKind.Absolute);
                bitmap.EndInit();
                PhotoUser.Source = bitmap;
                photoTextBox.Text = file.SafeFileName;
                Perem.PhotoName = photoTextBox.Text;
                // }
                // catch (System.IO.IOException) { MessageBox.Show("Файл с таким именем уже существует"); return; }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
