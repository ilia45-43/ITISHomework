using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Linq;

namespace ListExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> arraysList = Methods.Reading();

            arraysList = Methods.Fix(arraysList);

            arraysList = Methods.PrioritySort(arraysList);
            arraysList = Methods.OrderDateSort(arraysList);
            arraysList = Methods.ShipDateSort(arraysList);
            arraysList = Methods.Remove(arraysList);

            Methods.PrintArray(arraysList);
        }


        class Methods
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

            public static List<string[]> Remove(List<string[]> mas)
            {
                List<string[]> temp = new List<string[]>();
                for (int i = 0; i < mas.Count - 1; i++)
                    temp.Add(mas[i]);
                return temp;
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

                for (int i = 0; i < mas.Count; i++)
                {
                    var el = mas[i];

                    Console.WriteLine(
                        "{0,3} {1,10} {2,10} {3,15} {4,15}" +
                        "{5,10} {6,10} {7,10} {8,15} {9,15}" +
                        "{10,10} {11,10} {12,20} {13,30} {14,30}" +
                        "{15,30} {16,30} {17,30} {18,100} {19,15} {20,10} {21,10}",
                        i, el[0], el[1], el[2], el[3], el[4],
                        el[5], el[6], el[7], el[8], el[9],
                        el[10], el[11], el[12], el[13], el[14],
                        el[15], el[16], el[17], el[18], el[19], el[20]);

                }
            }

            public static List<string[]> PrioritySort(List<string[]> mas)
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

            public static List<string[]> ShipDateSort(List<string[]> mas)
            {
                return mas.OrderBy(x => DateTime.Parse(x[20])).ToList();
            }
        }

    }
}
