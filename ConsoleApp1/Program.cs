using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SimpleMethod(0,0);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static double SimpleMethod(int x, int y)
        {
            //var ex = new Exception("УЛЮУЛЮУЛЮ");

            return x / y;
        }
    }


}
