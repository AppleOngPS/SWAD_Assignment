using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD
{
    internal class Renter : Account
    {
        private string driverLicence;
        public string DriverLicence
        {
            get { return driverLicence; }
            set { driverLicence = value; }
        }
        private bool backgroundcheckStatus;
        public bool BackgroundCheckStatus { get { return backgroundcheckStatus; } set { backgroundcheckStatus = value; } }
        private double monthlyrentalminimum;
        public double MonthlyRentalMinimum {  get { return monthlyrentalminimum; } set { monthlyrentalminimum = value;} }
       
        public List<Booking> TrackUpComingRental { get; set; } = new List<Booking>();
        public List<Booking> BookingHistory { get;set; } = new List<Booking>();

        public Renter() { }
        public Renter(int id, string n, int c, DateTime dob,string dl,bool bs,double m=0) :base(id, n, c, dob)
        {
            driverLicence = dl;
            backgroundcheckStatus = bs;
            monthlyrentalminimum = m;
        }


        public void getlistofUpComingBooking(int bookingid)
        {
            foreach (Booking booking in Program.renter.TrackUpComingRental)
            {
                if (booking.Id == bookingid)
                {
                    int x = Program.renter.TrackUpComingRental.IndexOf(booking);
                  //return Program.renter.TrackUpComingRental[x];
                }
            }
        }
    }
}
