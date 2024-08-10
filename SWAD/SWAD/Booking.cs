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

        private IcarStation icarStationpickup;
        public IcarStation IcarStationPickup
        {
            get {return icarStationpickup; }
            set
            {
                if (icarStationpickup != value)
                {
                    icarStationpickup = value;
                    value.PickupBooking = this;
                }
            }
        }

        private IcarStation icarStationreturn;
        public IcarStation IcarStationReturn
        {
            get { return icarStationreturn; }
            set
            {
                if (icarStationreturn != value)
                {
                    icarStationreturn = value;
                    value.ReturnBooking = this;
                }
            }
        }

        private Delivery deliverypickup;
        public Delivery Deliverypickup
        {
            get { return deliverypickup; }
            set
            {
                if (deliverypickup != value)
                {
                    deliverypickup = value;
                    value.PickupBooking = this;
                }
            }
        }

        private Delivery deliveryReturn;
        public Delivery DeliveryReturn
        {
            get { return deliveryReturn; }
            set
            {
                if (deliveryReturn != value)
                {
                    deliveryReturn = value;
                    value.ReturnBooking = this;
                }
            }
        }


        private Payment payment;
        public Payment Payment
        {
            get { return payment; }
            set 
            {
                if(payment != value)
                {
                    payment = value;
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

        public void setDateTime(DateTime startdate,DateTime starttime, DateTime enddate,DateTime endtime)
        {
            //int x=Program.carOwner.Bookinglist.Count()-1;
            Program.BookingSlot.startDate = startdate;
            Program.BookingSlot.endDate = enddate;
            Program.BookingSlot.startTime = starttime;
            Program.BookingSlot.endTime = endtime;
            
        }
      
        public void setRentalfee(double fee)
        {
            //int x = Program.carOwner.Bookinglist.Count() - 1;
            foreach(Vehicle vehicle in Program.carOwner.Vehiclelist)
            {
                Console.WriteLine(Program.vehicleid);
                if(vehicle.Id ==Program.vehicleid)
                {
                    int x = Program.carOwner.Vehiclelist.IndexOf(vehicle);
                   
                    Program.BookingSlot.Vehicle = Program.carOwner.Vehiclelist[x];
                    Program.BookingSlot.Vehicle.Price = fee;
                    //Program.carOwner.Vehiclelist[x].Price = fee;
                    break;

                }
            }

           
            
        }

        public void createBookingSlot()
        {
            Program.BookingSlot = new Booking();
        }
        public void addtoListOfBookingSlot(Booking bookingSlot)
        {
            Program.carOwner.Bookinglist.Add(bookingSlot);
        }

        public override string ToString()
        {
            return $"Booking ID: {Id}\nStart Date: {StartDate}\nStart Time: {StartTime}\nEnd Date: {EndDate}\nEnd Time: {EndTime}";
        }

    }
}
