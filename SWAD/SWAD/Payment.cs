using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

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


        private Booking booking;
        public Booking Booking
        {
            get { return booking; }
            set
            {
                if (booking != value)
                {
                    booking = value;
                    value.Payment = this;
                }
            }

        }
        public Payment() { }

        public Payment(int i, double a, string t, string s)
            {
                id = i;
                amount = a;
                transactionid = t;
                status=s;
                
            }

        public void createPayment()
        {
            Payment payment = new Payment();
            
          
        }

        public bool validate(string name , string cardNo, string cvv,string expiryDate)
        {
            // Check if any field is empty
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(cardNo) ||
                string.IsNullOrEmpty(cvv) || string.IsNullOrEmpty(expiryDate))
            {
                return false;
            }

            // Validate card number (16 digits)
            if (!Regex.IsMatch(cardNo, @"^\d{16}$"))
            {
                Console.WriteLine("Card number must be 16 digits.");
                return false;
            }

            // Validate CVV (3 digits)
            if (!Regex.IsMatch(cvv, @"^\d{3}$"))
            {
                Console.WriteLine("CVV must be 3 digits.");
                return false;
            }

            // Validate expiry date (not later than today)
            if (!DateTime.TryParseExact(expiryDate, "MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expDate))
            {
                Console.WriteLine("Expiry date format is invalid.");
                return false;
            }

            DateTime today = DateTime.Today;
            DateTime lastDayOfExpMonth = new DateTime(expDate.Year, expDate.Month, DateTime.DaysInMonth(expDate.Year, expDate.Month));

            if (lastDayOfExpMonth < today)
            {
                Console.WriteLine("Expiry date must not be earlier than today.");
                return false;
            }

            return true;
        }

            public override string ToString()
            {
                return $"Booking ID: {Id}\nStart Date: {amount}\nStart Time: {transactionid}\nEnd Date: {status}";
            }
        }
}
