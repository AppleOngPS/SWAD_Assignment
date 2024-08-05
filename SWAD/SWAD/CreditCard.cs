using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD
{
    internal class  CreditCard:Payment    
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int balance;
        public int Balance
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

        


        public CreditCard(string n, int b, int c, DateOnly e,int i,string a, string t, string s): base( i ,  a, t, s)
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

