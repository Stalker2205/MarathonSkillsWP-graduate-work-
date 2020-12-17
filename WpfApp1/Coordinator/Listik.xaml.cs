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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для List.xaml
    /// </summary>
    public partial class Listik : Window
    {
        public Listik()
        {
            string string1 = "";
            InitializeComponent();
            for (int i = 0; i < Perem.list.Count; i++)
            {
                string1 = string1 + Perem.list[i] + "\n";
            }
            Tbox1.Text = string1;
        }
    }
}
