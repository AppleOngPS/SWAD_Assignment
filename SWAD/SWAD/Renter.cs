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

    }
}
