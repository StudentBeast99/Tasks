using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseLib
{
    public class Window
    {
        private int width;
        public int Width
        {
            get => width;
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException();
                width = value;
            }
        }
        private int height;
        public int Height
        {
            get => height;
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException();
                height = value;
            }
        }

        public bool IsOpened { get; private set; }
        public void Open()
        {
            IsOpened = true;
        }

        public void Close() => IsOpened = false;
        public Window(int width, int height)
        {
            Width = width;
            Height = height;
            IsOpened = false;
        }
        public override string ToString()
        {
            return width.ToString() + "x" + height.ToString() + " window";
        }
    }
}