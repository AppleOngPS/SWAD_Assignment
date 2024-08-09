using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD
{
    internal class IcarStation
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }
        private string location;
        public string Location { get { return location; } set { location = value; } }


        private Booking pickupBooking;
        public Booking PickupBooking
        {
            get { return pickupBooking; }
            set
            {
                if (pickupBooking != value)
                {
                    pickupBooking = value;
                    value.IcarStationPickup = this;

                }

            }
        }

        private Booking returnBooking;
        public Booking ReturnBooking
        {
            get { return returnBooking; }
            set
            {
                if (returnBooking != value)
                {
                    returnBooking = value;
                    value.IcarStationReturn = this;
                }
            }



        }

    }
}
