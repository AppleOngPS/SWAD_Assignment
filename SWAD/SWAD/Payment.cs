using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD
{
    internal class Payment
    {
        
            private int id;
            public int Id
            {
                get { return id; }
                set { id = value; }
            }

            private double amount;
            public double Amount
            {
                get { return amount; }
                set { amount = value; }
            }
            private string transactionid;
            public string Transactionid
            {
                get { return transactionid; }
                set { transactionid = value; }
            }
            private string status;
            public string Status
            {
                get { return status; }
                set { status = value; }
            }
       



            public Payment(int i, double a, string t, string s)
            {
                id = i;
                amount = a;
                transactionid = t;
                status=s;
                
            }


            public override string ToString()
            {
                return $"Booking ID: {Id}\nStart Date: {amount}\nStart Time: {transactionid}\nEnd Date: {status}";
            }
        }
}
