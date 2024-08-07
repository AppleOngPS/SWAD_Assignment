using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD
{
    internal class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ContactNumber { get; set; }

        public DateTime DateofBirth { get; set; }

        public Account() { }

        public Account(int id,string name ,int contactNumber,DateTime dateofBirth)
        {
            Id = id;
            Name = name;
            ContactNumber = contactNumber;
            DateofBirth = dateofBirth;
        }

    }
}
