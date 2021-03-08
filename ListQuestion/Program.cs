using System;

namespace MiniQuests1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] a = new int[10] { 1, 4, 2, 9, 8, 0, 11, 20, 30, 25 };

            var lis = new list(a);
            
            foreach (var e in lis.ChangeMin())
            {
                Console.Write($"{e} ");
            }
        }
    }

    class list
    {
        public int[] Mas { get; set; }

        public list(int[] mas)
        {
            Mas = mas;
        }

        public int[] ChangeMin()
        {
            int minn = 99999999;
            int maxx = 0;
            int indexF = 0, indexS = 0;

            for (int i = 0; i < Mas.Length; i++)
            {
                if (Mas[i] > maxx)
                {
                    maxx = Mas[i];
                    indexF = i;
                }
                if (Mas[i] < minn)
                {
                    minn = Mas[i];
                    indexS = i;
                }
            }
            Mas[indexF] = minn;
            Mas[indexS] = maxx;
            return Mas;
        }
    }
}
