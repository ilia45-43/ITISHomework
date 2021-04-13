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
            
        }

        static LinkedList<string> Q1(LinkedList<string> list,string name)
        {
            LinkedList<string> lis = new LinkedList<string>();
            lis = list;
            lis.AddLast(name);
            lis = new LinkedList<string>(lis.OrderBy(x => x));
            return lis;
        }

        static LinkedList<string> Q2(LinkedList<string> list1, LinkedList<string> list2)
        {
            LinkedList<string> lis = new LinkedList<string>();
            lis = list1;
            
            foreach (var e in list2)
            {
                lis.AddLast(e);
            }

            lis = new LinkedList<string>(lis.OrderByDescending(x => x));

            return lis;
        }

        static LinkedList<int> Q3A(LinkedList<int> list)
        {
            var lis = new LinkedList<int>();
            foreach (var e in list)
                if (e % 2 == 0)
                    lis.AddLast(e);
            return new LinkedList<int>(lis.OrderBy(x => x));
        }

        static LinkedList<int> Q3B(LinkedList<int> list)
        {
            var lis = new LinkedList<int>();
            foreach (var e in list)
                if (e >= 0)
                    lis.AddLast(e);
            return new LinkedList<int>(lis.OrderBy(x => x));
        }

        static LinkedList<string> Q6(LinkedList<string> list)
        {
            var lis = new LinkedList<string>();

            foreach (var e in list)
            {
                if (e.Contains("itmathrepetitor"))
                {
                    lis.AddLast("silence");
                }
                else
                {
                    lis.AddLast(e);
                }
            }
            return lis;
        }
    }

    class Colectons3
    {
        public LinkedList<int> list { get; set; }

        public Colectons3(LinkedList<int> mas)
        {
            list = mas;
        }

        public void Sorting()
        {
            List<int> lis = new List<int>();
            List<int> indexs = new List<int>();
            List<int> counts = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if ((list.GetEnumerator >= 0) || (i % 2 == 0))
                {
                    lis.Add(list[i]);
                    indexs.Add(i);
                }
                else
                    counts.Insert(indexs[i], lis[i]);

                list = counts;
            }
        }
    }

    class Colectons2
    {
        public LinkedList<string> list { get; set; }

        private LinkedList<string> list1 { get; set; }
        private LinkedList<string> list2 { get; set; }

        public Colectons2(LinkedList<string> mas1, LinkedList<string> mas2)
        {
            list1 = mas1;
            list2 = mas2;
        }

        public void Combination()
        {
            list = list1;
            list.AddRange(list2);
            list = new LinkedList<string>(list.OrderBy(x => x));
        }
    }

    class ExcelSortDatePrioryty
    {
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
