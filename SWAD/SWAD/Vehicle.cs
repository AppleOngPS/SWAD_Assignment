using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD
{
    internal class Vehicle
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string make;
        public string Make
        {
            get { return make; }
            set { make = value; }
        }
        private string model;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private int mileage;
        public int Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }
        private string photo;
        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private bool availability;
        public bool Availability
        {
            get { return availability; }
            set { availability = value; }
        }
        private string brand;
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public Vehicle() { }

        public Vehicle(int id, string make, string model, int mileage, string photo, double price, bool availability, string brand, string type)
        {
            this.id = id;
            this.make = make;
            this.model = model;
            this.mileage = mileage;
            this.photo = photo;
            this.price = price;
            this.availability = availability;
            this.brand = brand;
            this.type = type;
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
                    value.Vehicle = this;
                }
            }
        }
        private CarOwner carOwner;
        public CarOwner CarOwner
        {
            get { return carOwner; }
            set { carOwner = value; }
        }
        public void getListOfVehicle()
        {
         
                foreach (Vehicle vehicle in Program.carOwner.Vehiclelist)
                {
                    Console.WriteLine($"Id: {vehicle.Id} Brand:{vehicle.Brand} Make:{vehicle.Make} Model:{vehicle.Model} Type:{vehicle.Type} Mileage: {vehicle.Mileage}  Price: {vehicle.Price}");
                }
                
        }
        public void getVehicle(int vehicleid)
        {
            findVehicle(vehicleid);
        }
        public void findVehicle(int vehicleid)
        {
            Console.WriteLine(vehicleid);
            // Search for the vehicle with the given ID
            foreach (Vehicle vehicle in Program.carOwner.Vehiclelist)
            {
                if (vehicle.Id == vehicleid)
                {
                    Console.WriteLine("Vehicle Found:");
                    Console.WriteLine($"Id: {vehicle.Id} | Brand: {vehicle.Brand} | Make: {vehicle.Make} | Model: {vehicle.Model} | Type: {vehicle.Type} | Mileage: {vehicle.Mileage} | Price: {vehicle.Price:C}");
                    vehicle.Booking = new Booking();
                    vehicle.Booking.createBookingSlot();
                }

            }


        }
        public void getAvailableDateTime(int boookingId)
        {
            
           booking = Program.carOwner.Bookinglist[boookingId];
        }
        public void getetAvailableVehicle()
        {

        }
        public override string ToString()
        {
            return $" ID: {Id}, Brand: {Brand},Model: {Model}, Type: {Type}, Mileage: {Mileage}, Price: {Price}, Available: {Availability}";
        }
    }
}
