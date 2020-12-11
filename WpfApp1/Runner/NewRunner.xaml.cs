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
using System.Text.RegularExpressions;
using Libra;

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
            TimeSpan datet = Perem.datetim();
            LabelTime.Content = $"{datet.Days} дней {datet.Hours} часов и {datet.Minutes} минут до старта марафона!";
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
                    string sq = AppDomain.CurrentDomain.BaseDirectory + Filename;
                    fotoname.Text = Filename;
                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    img.UriSource = new Uri($"{sq}", UriKind.Absolute);
                    img.EndInit();
                    foto.Source = img;
                }
                catch (System.IO.IOException) { MessageBox.Show("Файл с таким именем уже существует"); return; }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//Регистрация
        {

            if (TboxMail.Text.Length == 0) { MessageBox.Show("Введите Mail"); return; }
            try
            {
                System.Net.Mail.MailAddress mailAddress = new System.Net.Mail.MailAddress(TboxMail.Text);
            }
            catch { MessageBox.Show("не рабочий mail"); return; }
            if (TboxPass.Text.Length < 6) { MessageBox.Show("Введите пароль, не менее 6 символов"); return; }
            Regex reg = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$");
            string ss = Convert.ToString(reg.Match(TboxPass.Text));
            if (ss.Length == 0)
            {
                MessageBox.Show("Пароль должен отвечать следующим требованиям:\n" +
                "•Минимум 6 символов\n•Минимум 1 прописная буква\n•Минимум 1 цифра\n•По крайней мере один из следующих символов: ! @ # $ % ^ "); return;
            }
            if (TboxPassPodtv.Text.Length == 0) { MessageBox.Show("Введите повтор пароля"); return; }
            if (TboxPass.Text != TboxPassPodtv.Text) { MessageBox.Show("Пароль и его подтверждение не совпадают"); return; }
            if (TboxFirstName.Text.Length == 0) { MessageBox.Show("Введите Имя"); return; }
            if (TboxSecondName.Text.Length == 0) { MessageBox.Show("Введите фамилию"); return; }
            if (countryCodeTextBox.Text.Length == 0) { MessageBox.Show("Выберите страну"); return; }
            DateTime n1 = DateOfbirth.DisplayDate;
            if ((DateTime.Now.Year - n1.Year) < 10) { MessageBox.Show("Бегуны младше 10 лет не принимаются на марафон"); return; }
            if (n1.Year > DateTime.Now.Year) { MessageBox.Show("Дата рождения введена не верно"); return; }
            WpfApp1.marathonDataSet marathonDataSet = ((WpfApp1.marathonDataSet)(this.FindResource("marathonDataSet")));
            WpfApp1.marathonDataSetTableAdapters.RunnerTableAdapter runnerTableAdapter = new marathonDataSetTableAdapters.RunnerTableAdapter();
            WpfApp1.marathonDataSetTableAdapters.UserTableAdapter userTableAdapter = new marathonDataSetTableAdapters.UserTableAdapter();
            runnerTableAdapter.SerchEmail(marathonDataSet.Runner, TboxMail.Text);
            if(marathonDataSet.Runner.Count != 0) { MessageBox.Show("Такой Ьаил уже зарегестрироывн");return; }
            userTableAdapter.InsertUser(TboxMail.Text, TboxPass.Text, TboxFirstName.Text, TboxSecondName.Text, "R");
            runnerTableAdapter.InserеRunner(TboxMail.Text, genderComboBox.Text, DateOfbirth.SelectedDate, countryCodeTextBox.Text, fotoname.Text);
            RegisterForAnEvent registerForAnEvent = new RegisterForAnEvent();
            Runner.CountryCode = countryCodeTextBox.Text;
            Runner.Email = TboxMail.Text;
            Runner.Gender = genderComboBox.Text;
            Runner.Photo = fotoname.Text;
            registerForAnEvent.Show();
            Close();
        }
    }
}
