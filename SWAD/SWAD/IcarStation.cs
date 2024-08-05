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
    }
}
