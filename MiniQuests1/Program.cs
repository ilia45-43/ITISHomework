using System;

namespace MiniQuests1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] a = new int[10] { 1, 4, 2, 9, 8, 0, 11, 20, 30, 25 };

            foreach (var e in ChangeMin(a))
            {
                Console.Write($"{e} ");
            }
        }

        static int[] ChangeMin(int[] mas)
        {
            int minn = 99999999;
            int maxx = 0;
            int indexF = 0, indexS = 0;

            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > maxx)
                {
                    maxx = mas[i];
                    indexF = i;
                }
                if (mas[i] < minn)
                {
                    minn = mas[i];
                    indexS = i;
                }
            }
            mas[indexF] = minn;
            mas[indexS] = maxx;
            return mas;
        }


    }
}
