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

        private int price;
        public int Price
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
        public override string ToString()
        {
            return $" ID: {Id}, Brand: {Brand},Model: {Model}, Type: {Type}, Mileage: {Mileage}, Price: {Price}, Available: {Availability}";
        }
    }
}
