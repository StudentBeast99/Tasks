using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLib
{
    public class Car
    {
        public string Brand { get; set; }
        public int Power { get; set; }
        public int PlaceCount { get; set; }
        protected virtual double Q() => 0.1 * Power * PlaceCount;
        public double GetQ() => Q();

        public Car(string brand, int power, int placeCount)
        {
            Brand = brand;
            Power = power;
            PlaceCount = placeCount;
        }
        public override string ToString()
        {
            return Brand + " Power:" + Power.ToString() + " Place Count:" + PlaceCount.ToString() + ((this is CarWithYear)?" Year:" + ((CarWithYear)this).Year:"")+ " Q:" + GetQ();
        }
    }
}
