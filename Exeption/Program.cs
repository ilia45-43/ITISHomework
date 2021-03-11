using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var mas = new int[2] { 1, 2 };

            string name = null;

            try
            {
                SimpleMethod(0,0);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                SimpleMethod(mas);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                SimpleMethod(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static double SimpleMethod(int x, int y)
        {
            return x / y;

            // Все остальные ексепошоны
        }

        static void SimpleMethod(int[] mas)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(mas[i]);
            }
        }

        static void SimpleMethod(string name)
        {
            if (name == null)
                throw new ArgumentNullException("User is NUUUUUUUUUUUL");
        }
    }


}
