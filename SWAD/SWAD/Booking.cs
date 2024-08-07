using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD
{
    internal class Booking
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime startTime;
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private DateTime endTime;
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        
        private CarOwner carOwner;
        public CarOwner CarOwner
        {
            get { return carOwner; }
            set { carOwner = value; }
        }

        private Vehicle vehicle;
        public Vehicle Vehicle
        {
            get { return vehicle; }
            set
            {
                if (vehicle != value)
                {
                    vehicle = value;
                    value.Booking = this;
                }
            }
        }

        private IcarStation icarStation;
        public IcarStation IcarStation
        {
            get {return icarStation;}
            set
            {
                if (icarStation != value)
                {
                    icarStation = value;
                    value.Booking = this;
                }
            }
        }

        private IcarStation returns;
        public IcarStation Returns
        {
            get { return returns; }
            set
            {
                if (returns != value)
                {
                    returns = value;
                    value.Booking = this;
                }
            }
        }



        public Booking() { }
        public Booking(int i , DateTime sd , DateTime st, DateTime ed, DateTime et)
        {
            id = i;
            startDate = sd;
            startTime = st;
            endDate = sd;
            endTime = st;
        }

        public void setDate(int id,int x,DateTime startdate, DateTime enddate)
        {
            if (id == carOwner.Id)
            {
                carOwner.Bookinglist[x].startDate = startdate;
                carOwner.Bookinglist[x].endDate = enddate;
            }
        }
        public void setTime(int id,int x,DateTime starttime, DateTime endtime)
        {
            if (id == carOwner.Id)
            {
                carOwner.Bookinglist[x].startTime = starttime;
                carOwner.Bookinglist[x].endTime = endtime;
            }
        }
        public void setRentalfee(int id,int x,double fee)
        {
            if (id == carOwner.Id)
            {
                carOwner.Vehiclelist[x].Price = fee;
            }
        }

        public override string ToString()
        {
            return $"Booking ID: {Id}\nStart Date: {StartDate}\nStart Time: {StartTime}\nEnd Date: {EndDate}\nEnd Time: {EndTime}";
        }

    }
}
