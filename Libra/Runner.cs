using System;

namespace Libra
{
    public class Runner
    {
        public static string Pos = "Login";
        public static string ID;
        public static string Email;
        public static string Password;
        public static string PasswordRepeat;
        public static string FirstName;
        public static string LastName;
        public static string Gender;
        public static string Photo;
        public static string CountryCode;
        private double bMI;
        public double CalculationBmi(int Growth, int Weight)
        {
            bMI = Weight / Math.Pow((Convert.ToDouble(Growth) / 100), 2);
            return bMI;
        }
    }
}
