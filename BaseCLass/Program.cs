using System;

namespace BaseCLass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class BaseClass
    {
        private int[,] data;

        public int SizeX { get; set; }

        public int SizeY { get; set; }

        public BaseClass(int sizeX, int sizeY)
        {
            data = new int[sizeX, sizeY];
            SizeX = sizeX;
            SizeY = sizeY;
        }

        public int this[int indexX, int indexY] // свойство
        {
            get
            {
                return data[indexX, indexY]; 
            }

            set
            {
                data[indexX, indexY] = value;
            }
        }
    }
}
