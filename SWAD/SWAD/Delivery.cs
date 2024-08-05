using System;
using System.Collections.Generic;
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
     




        public Delivery(int i , int a , string l)
        {
            id = i;
            amount = a;
            location = l;


        }


        public override string ToString()
        {
            return $"id: {id}\namount: {amount}\nlocation: {location}";
        }
    }
}

