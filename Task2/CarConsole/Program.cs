using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLib;
using static System.Console;

namespace CarConsole
{
    class Program
    {
        static List<Car> cars;
        static int WriteMenu(bool needResult, params string[] inp)
        {
            for (int i = 0; i < inp.Length; i++)
            {
                WriteLine("{0}) {1}", i + 1, inp[i]);
            }
            while (true && needResult)
            {
                if (int.TryParse(ReadLine(), out int result) && result > 0 && result <= inp.Length)
                    return result;
            }
            return -1;
        }
        static int GetValue(string message)
        {
            while (true)
            {
                Write("input " + message + ":");
                if (int.TryParse(ReadLine(), out int result))
                    return result;
            }
        }
        static bool GetBool(string message)
        {
            while (true)
            {
                Write(message + " (y/n):");
                string t = ReadLine().ToUpper();
                if (t == "Y" || t == "N")
                    return t == "Y";
            }
        }
        static void Main(string[] args)
        {
            cars = new List<Car>();
            while (true)
            {
                Clear();
                switch (WriteMenu(true,"add", "remove", "info"))
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Remove();
                        break;
                    case 3:
                        Info();
                        break;
                }
            }
        }
        static void Add()
        {
            Clear();
            Write("input Brand: ");
            string brand = ReadLine();
            int power = GetValue("power");
            int placeCount = GetValue("place count");
            if(GetBool("With Year?"))
            {
                int year = GetValue("year");
                cars.Add(new CarWithYear(brand, power, placeCount, year));
            }
            else
                cars.Add(new Car(brand, power, placeCount));
        }
        static void Remove()
        {
            Clear();
            int index = GetValue("index");
            if (index > 0 && index <= cars.Count)
            {
                cars.RemoveAt(index - 1);
            }
            else
                WriteLine("Not Found");
        }
        static void Info()
        {
            Clear();
            string[] info = new string[cars.Count];
            for (int i = 0; i < cars.Count; i++)
            {
                info[i] = cars[i].ToString();
            }
            WriteMenu(false, info);
            ReadLine();
        }
    }
}
