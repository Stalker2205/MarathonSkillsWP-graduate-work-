using System;
using System.Collections.Generic;
using System.Text;

namespace Libra
{
    public class Charity
    {
        private int _id;
        private string _name;
        private string _discription;

        public int ID1
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Name1
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Discription1
        {
            get
            {
                return _discription;
            }

            set
            {
                _discription = value;
            }
        }
    }
}
