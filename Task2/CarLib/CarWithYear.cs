using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLib
{
    public class CarWithYear:Car
    {
        public int Year { get; set; }
        public CarWithYear(string brand, int power, int placeCount, int year)
            :base(brand,power,placeCount)
        {
            Year = year;
        }
        protected override double Q() => base.Q() - (1.5 * (DateTime.Now.Year - Year));
    }
}
