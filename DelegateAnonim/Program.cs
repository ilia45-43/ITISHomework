using System;

namespace DelegateAnonim
{
    class Program
    {
        delegate int Del1();
        delegate double Del2(Del1[] a);
        static void Main()
        {
            int n = 6;
            Del2 myDelegate;
            myDelegate = delegate (Del1[] a)
            {
                double sum = 0;
                foreach (var i in a)
                    sum += i.Invoke();
                return sum / a.Length;
            };

            var mas = new Del1[n];
            for (int i = 0; i < n; i++)
                mas[i] = NewRandNumb;

            Console.WriteLine(myDelegate.Invoke(mas));
        }

        static int NewRandNumb()
        {
            return new Random().Next(1, 100);
        }
    }
}
