using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD
{
    internal class CarOwner : Account
    {
        private string registerCar;
        public string RegisterCar
        {
            get { return registerCar; }
            set { registerCar = value; }
        }

        private double earning;
        public double Earning
        {
            get { return earning; }
            set { earning = value; }
        }
        

        public CarOwner(string r, double e)
        {
            registerCar = r;
            earning = e;

        }


        public override string ToString()
        {
            return $"registerCar: {registerCar}\nearning: {earning}";
        }
    }

}

