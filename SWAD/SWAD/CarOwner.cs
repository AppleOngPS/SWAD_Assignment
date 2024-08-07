using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD
{
    internal class CarOwner : Account
    {

        private double earning;
        public double Earning
        {
            get { return earning; }
            set { earning = value; }
        }

        public List<Vehicle> Vehiclelist { get; set; } = new List<Vehicle>();
        public List<Booking> Bookinglist { get; set; }= new List<Booking>();
        public CarOwner() { }
        public CarOwner(int id, string n, int c, DateTime dob,double e=0):base(id,n,c,dob)
        {
            
            earning = e;

        }


        public override string ToString()
        {
            return $"earning: {earning}";
        }
    }

}

