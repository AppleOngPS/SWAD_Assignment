using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD
{
    internal class Delivery
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int amount;
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private string location;
        public string Location
        {
            get { return location; }
            set { location = value; }
        }


        private Booking pickupBooking;
        public Booking PickupBooking
        {
            get { return pickupBooking; }
            set
            {
                if (pickupBooking != value)
                {
                    pickupBooking = value;
                    value.Deliverypickup = this;

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
                    value.DeliveryReturn = this;
                }
            }

        }

        public Delivery() { }

        public Delivery(int i , int a , string l)
        {
            id = i;
            amount = a;
            location = l;
             

        }
        public void addAddress(string street, string block, string road, string city, string postalCode)
        {
            string fullAddress = $"Street: {street}, Block: {block}, Road: {road}, City: {city}, Postal Code: {postalCode}";
            int x= Program.renter.TrackUpComingRental.Count()-1;
            Program.renter.TrackUpComingRental[x].Deliverypickup.location = fullAddress;
            // Ensure that there are bookings in the list
            if (x >= 0)
            {
                if (Program.pickupOption == 1)
                {
                    // Update the address for the last booking's pickup delivery
                    Program.renter.TrackUpComingRental[x].Deliverypickup.Location = fullAddress;
                    Console.WriteLine("Address updated for the latest booking.");
                }
                else if (Program.pickupOption == 2)
                {
                    Program.renter.TrackUpComingRental[x].DeliveryReturn.Location = fullAddress;
                    Console.WriteLine("Address updated for the latest booking.");
                }
            }
            else
            {
                Console.WriteLine("No bookings available to update the address.");
            }
        }

        public override string ToString()
        {
            return $"id: {id}\namount: {amount}\nlocation: {location}";
        }
    }
}

