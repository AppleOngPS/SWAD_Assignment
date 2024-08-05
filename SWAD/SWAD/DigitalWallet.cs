using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD
{
    internal class DigitalWallet:Payment
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double balance;
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        private int cvv;
        public int Cvv
        {
            get { return cvv; }
            set { cvv = value; }
        }
        private DateOnly expiryDate;
        public DateOnly ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }




        public DigitalWallet(string n, double b, int c, DateOnly e, int i, double a, string t, string s) : base(i, a, t, s)
        {
            name = n;
            balance = b;
            cvv = c;
            expiryDate = e;


        }


        public override string ToString()
        {
            return $"name: {name}\nbalance: {balance}\ncvv: {cvv}\nexpiryDate Date: {expiryDate}";
        }
    }
}

