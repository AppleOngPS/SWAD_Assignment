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


        private Booking booking;
        public Booking Booking
        {
            get { return booking; }
            set
            {
                if (booking != value)
                {
                    booking = value;
                    value.IcarStation = this;
                }
            }
        }
        private Booking booking2;
        public Booking Booking2
        {
            get { return booking2; }
            set
            {
                if (booking2 != value)
                {
                    booking2 = value;
                    value.Returns = this;
                }
            }
        }


    }


}
