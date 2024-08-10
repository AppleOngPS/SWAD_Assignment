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

        public IcarStation() { }

        public IcarStation(int id,string l)
        {
            Id = id;
            Location = l;
        }
        public List<IcarStation> getAvailableIcarStation()
        {
           List<IcarStation> icarStations = new List<IcarStation>();
            icarStations.Add(new IcarStation(1, "Clementi Branch"));
            icarStations.Add(new IcarStation(2, "Jurong Branch"));
            icarStations.Add(new IcarStation(3, "Tampines Branch"));
            return icarStations;

        }
        public void selecticarstation()
        {
            foreach (Booking booking in Program.renter.TrackUpComingRental)
            {
                if (booking.Id == Program.bookingId)
                {
                    int x = Program.renter.TrackUpComingRental.IndexOf(booking);
                    Console.WriteLine($"qqq{x}");
                    // Ensure that there are bookings in the list
                    if (x >= 0)
                    {
                        if (Program.pickupOption == 1)
                        {
                            // Update the address for the last booking's pickup delivery
                            Program.renter.TrackUpComingRental[x].IcarStationPickup.Location = Program.location;
                            Console.WriteLine("Address updated for the latest booking.");
                        }
                        else if (Program.pickupOption == 2)
                        {
                            Program.renter.TrackUpComingRental[x].IcarStationReturn.Location = Program.location;
                            Console.WriteLine("Address updated for the latest booking.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No bookings available to update the address.");
                    }
                }
            }
        }

    }
}
