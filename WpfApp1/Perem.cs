﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Perem
    {
        public static string CharityName;
        public static string CharityDescription;
        public static string LogoName;
        public static int Price;
        public static string PeopleName;
        public static string Runner;
        public static string PhotoName;
        public static int CharityID;
        private static DateTime Starting = Convert.ToDateTime("01.01.2021 18:30:25");
        public static TimeSpan datetim()
        {
            TimeSpan timeSpan = Starting.Subtract(DateTime.Now);
            return timeSpan;
        }
    }
}
