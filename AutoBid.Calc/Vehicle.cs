using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Calc
{
    public enum VehicleType
    { 
        Common = 0, 
        Luxury = 1
    }
    public class Vehicle
    {
        public double Price { get; set; }
        public VehicleType VehType { get; set;}

    }
}
