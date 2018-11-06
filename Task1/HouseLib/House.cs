using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseLib
{
    public class House
    {
        public Door Door { get; private set; }
        public List<Window> Windows { get; private set; }
        public House(Door door, List<Window> windows)
        {
            Door = door;
            Windows = windows;
        }
        public override string ToString()
        {
            return "house with " + Windows.Count.ToString() + " windows"; 
        }
    }
}
