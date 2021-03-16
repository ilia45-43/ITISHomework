using System;

namespace Delegate
{
    class Program
    {
        public delegate double Calc(double r);

        static void Main()
        {
            double r = 4;
            Calc n = Circle;
            n += CircleArea;
            n += BallVolume;
            //Calc GC = Circle;
            //Calc GCA = CircleArea;
            //Calc GBV = BallVolume;
            //Console.WriteLine("D = " + GC(r) + "\n" + "S = " + GCA(r) + "\n" + "V = " + GBV(r));
            Console.WriteLine(n(r));

        }

        static double Circle(double r)
        {
            return 2 * Math.PI * r;
        }

        static double CircleArea(double r)
        {
            return Math.PI * r * r;
        }

        static double BallVolume(double r)
        {
            return (4 / 3) * Math.PI * r * r * r;
        }
    }
}
