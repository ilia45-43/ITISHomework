using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> arraysList = Reading();

            arraysList = Fix(arraysList);
            arraysList = PrioritySortDate(arraysList);
            PrintArray(arraysList);
        }

        public static List<string[]> Reading()
        {
            string path = @"C:\Users\ilia7\Desktop\ITISHomework\ListExcel\Sample - Superstore Sales.csv";
            List<string> list = new List<string>();
            List<string[]> arraysList = new List<string[]>();

            using (StreamReader sr = new StreamReader(path))
            {
                int count = 0;
                while (count < 150)
                {
                    count++;
                    list.Add(sr.ReadLine());
                }
            }
            for (int i = 0; i < list.Count; i++)
                arraysList.Add(list[i].Split(';'));
            return arraysList;
        }

        public static List<string[]> Fix(List<string[]> mas)
        {
            List<string[]> temp = new List<string[]>();
            for (int i = 1; i < mas.Count - 1; i++)
                temp.Add(mas[i]);
            return temp;
        }

        public static void PrintArray(List<string[]> mas)
        {
            Console.BufferWidth = 2000;

            Console.WindowWidth = 200;
            Console.WindowHeight = 60;

            for (int i = 0; i < mas.Count; i++)
            {
                var el = mas[i];

                Console.WriteLine(
                    "{0,3} | {1,5} | {2,6} | {3,11} | {4,15} |" +
                    "{5,4} | {6,10}|  {7,4} | {8,15} | {9,10} |" +
                    "{10,10} | {11,10} | {12,20} | {13,21} | {14,21} |" +
                    "{15,16} | {16,16} | {17,30} | {18,96} | {19,12} | {20,5} | {21,10} |",
                    i, el[0], el[1], el[2], el[3], el[4],
                    el[5], el[6], el[7], el[8], el[9],
                    el[10], el[11], el[12], el[13], el[14],
                    el[15], el[16], el[17], el[18], el[19], el[20]);
            }
        }

        public static List<string[]> PrioritySortDate(List<string[]> mas)
        {
            List<string[]> finishMas = new List<string[]>();

            List<string[]> masNotS = new List<string[]>();
            List<string[]> masLow = new List<string[]>();
            List<string[]> masMed = new List<string[]>();
            List<string[]> masHig = new List<string[]>();
            List<string[]> masCrit = new List<string[]>();

            for (int i = 1; i < mas.Count; i++)
            {
                if (mas[i][3] == "Low") masLow.Add(mas[i]);
                else if (mas[i][3] == "Not Specified") masNotS.Add(mas[i]);
                else if (mas[i][3] == "Medium") masMed.Add(mas[i]);
                else if (mas[i][3] == "Critical") masCrit.Add(mas[i]);
                else masHig.Add(mas[i]);
            }

            masNotS = OrderDateSort(masNotS);
            masLow = OrderDateSort(masLow);
            masMed = OrderDateSort(masMed);
            masHig = OrderDateSort(masHig);
            masCrit = OrderDateSort(masCrit);

            finishMas.AddRange(masNotS);
            finishMas.AddRange(masLow);
            finishMas.AddRange(masMed);
            finishMas.AddRange(masHig);
            finishMas.AddRange(masCrit);

            masLow.Clear();
            masNotS.Clear();
            masHig.Clear();
            masCrit.Clear();
            masMed.Clear();

            return finishMas;
        }

        public static List<string[]> OrderDateSort(List<string[]> mas)
        {
            return mas.OrderBy(x => DateTime.Parse(x[2])).ToList();
        }
    }
}
