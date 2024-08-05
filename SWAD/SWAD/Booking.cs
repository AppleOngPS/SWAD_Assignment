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

        private TimeOnly startTime;
        public TimeOnly StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private TimeOnly endTime;
        public TimeOnly EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private DateOnly startDate;
        public DateOnly StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        private DateOnly endDate;
        public DateOnly EndDate
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
        public Booking(int i , DateOnly sd , TimeOnly st, DateOnly ed, TimeOnly et)
        {
            id = i;
            startDate = sd;
            startTime = st;
            endDate = sd;
            endTime = st;
        }


        public override string ToString()
        {
            return $"Booking ID: {Id}\nStart Date: {StartDate}\nStart Time: {StartTime}\nEnd Date: {EndDate}\nEnd Time: {EndTime}";
        }

    }
}
