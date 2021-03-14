using System;

namespace BaseCLass
{
    class Program
    {
        static void Main(string[] args)
        {
            var bas = new BaseClass(10,10);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    bas[i, j] = i + j;
                }
            }
        }
    }

    class BaseClass
    {
        private int[,] data { get; set; }
        private int[] data1 { get; set; }

        public BaseClass(int x, int y)
        {
            data = new int[x, y];
        }

        public int[] this[int colIndex]
        {
            get
            {
                if (colIndex > data.GetLength(1))
                    throw new IndexOutOfRangeException("");

                var array = new int[data.GetLength(1)];

                for (int i = 0; i < data.GetLength(1); i++)
                {
                    array[i] = data[i, colIndex];
                }

                return array;
            }
            set
            {
                if (colIndex > data.GetLength(1))
                    throw new IndexOutOfRangeException("");

                for (int i = 0; i < value.Length; i++)
                {
                    data[i, colIndex] = value[i];
                }
            }

        }

        public int this[int x, int y]
        {
            get
            {
                return data[x, y];
            }
            set
            {
                data[x, y] = value;
            }
        }
    }
}
