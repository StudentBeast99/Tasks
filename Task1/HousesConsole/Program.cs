using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseLib;
using static System.Console;
namespace HousesConsole
{
    class Program
    {
        static List<House> houses;
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
        static void Main(string[] args)
        {
            houses = new List<House>();
            while (true)
            {
                switch (WriteMenu(true,"add", "remove", "info", "edit", "exit"))
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Remove();
                        break;
                    case 3:
                        HousesInfo();
                        break;
                    case 4:
                        EditHouse();
                        break;
                    case 5:
                        return;
                }
            }
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
        static void GetSize(out int width, out int height)
        {
            width = 0;
            height = 0;         
            width = GetValue("Width");          
            height = GetValue("Height");
        }

        static void Add()
        {
            WriteLine("input Door Size");
            GetSize(out int width, out int height);
            Door door = new Door(width, height);
            int N = GetValue("Windows Count");
            List<Window> windows = new List<Window>();
            for (int i = 0; i < N; i++)
            {
                GetSize(out width, out height);
                windows.Add(new Window(width, height));
            }
            houses.Add(new House(door, windows));
        }
        static void Remove()
        {
            int index = GetValue("index");
            if (index > 0 && index <= houses.Count)
            {
                houses.RemoveAt(index - 1);
            }
            else
                WriteLine("Not Found");
        }
        private static string[] GetNames()
        {
            string[] names = new string[houses.Count];
            for (int i = 0; i < houses.Count; i++)
            {
                names[i] = houses[i].ToString();
            }
            return names;
        }
        static void HousesInfo()
        {
            WriteLine();
            WriteLine();
            WriteMenu(false, GetNames());
            WriteLine();
            WriteLine();
        }

        static void EditHouse()
        {
            WriteLine();
            WriteLine();
            int index = WriteMenu(true, GetNames());
            if (index > 0 && index <= houses.Count)
            {
                HouseMenu(houses[index-1]);
            }
            else
                WriteLine("Not Found");
        }
        static void HouseMenu(House house)
        {
            while (true)
            {
                switch (WriteMenu(true, "add Window", "remove Window", "info", "edit Door", "edit Window", "exit"))
                {
                    case 1:
                        AddWindows(house);
                        break;
                    case 2:
                        RemoveWindow(house);
                        break;
                    case 3:
                        HouseInfo(house);
                        break;
                    case 4:
                        EditDoor(house.Door);
                        break;
                    case 5:
                        SelectWindow(house.Windows);
                        break;
                    case 6:
                        return;
                }
            }
        }
        static void AddWindows(House house)
        {
            GetSize(out int width, out int height);
            house.Windows.Add(new Window(width, height));
        }
        static void RemoveWindow(House house)
        {
            int index = GetValue("index");
            if (index > 0 && index <= house.Windows.Count)
            {
                house.Windows.RemoveAt(index - 1);
            }
            else
                WriteLine("Not Found");
        }
        static string[] WindowsNames(List<Window> windows)
        {
            string[] names = new string[windows.Count];
            for (int i = 0; i < windows.Count; i++)
            {
                names[i] = windows[i].ToString();
            }
            return names;
        }
        static void HouseInfo(House house)
        {
            WriteLine();
            WriteLine();
            WriteLine(house.Door.ToString());
            WriteLine();
            WriteLine("windows:");
            WriteMenu(false, WindowsNames(house.Windows));
            WriteLine();
            WriteLine();
        }
        static void EditDoor(Door door)
        {
            while (true)
            {
                WriteLine();
                WriteLine(door.ToString());
                WriteLine("is unlocked " + door.IsUnlocked);
                WriteLine("is opened " + door.IsOpened);
                switch (WriteMenu(true, "open", "close", "lock", "unlock", "edit", "exit"))
                {
                    case 1:
                        door.Open();
                        break;
                    case 2:
                        door.Close();
                        break;
                    case 3:
                        door.Lock();
                        break;
                    case 4:
                        door.Unlock();
                        break;
                    case 5:
                        GetSize(out int Width, out int Height);
                        door.Width = Width;
                        door.Height = Height;
                        break;

                    case 6:
                        return;
                }
            }

        }
        static void SelectWindow(List<Window> windows)
        {
            int index = WriteMenu(true, WindowsNames(windows));
            EditWindow(windows[index - 1]);
        }
        static void EditWindow(Window window)
        {
            while (true)
            {
                WriteLine();
                WriteLine(window.ToString());
                WriteLine("is opened " + window.IsOpened);
                switch (WriteMenu(true, "open", "close", "edit", "exit"))
                {
                    case 1:
                        window.Open();
                        break;
                    case 2:
                        window.Close();
                        break;
                    case 3:
                        GetSize(out int width, out int height);
                        window.Width = width;
                        window.Height = height;
                        break;

                    case 4:
                        return;
                }
            }

        }
    }
}
