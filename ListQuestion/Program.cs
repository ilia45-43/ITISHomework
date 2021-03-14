using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniQuests1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var a = new int[10] { 1, 4, 2, 9, 8, 1, 11, 20, 30, 25 };
            var lis = new list<int>();
            //lis.Count = a.Length;
            var b = new int[11] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            var str = new string[5] { "faf", "asd", "fasd", "xvbxc", "sdgsv" };

            //lis.RemoveAt(9);
            lis.Add(1);
            lis.Add(2);
            lis.Add(3);
            lis.RemoveAt(5);

            foreach (var e in lis.Mas)
                Console.Write($"{e} ");

            Console.WriteLine();
            Console.WriteLine(lis.Count);
        }
    }

    class list <T>
    {
        public T[] Mas { get; set; }
        public int Count { get; set; }
        private T[] m = new T[1];


        public list(T[] mas)
        {
            Mas = mas;
        }

        public list()
        {
            Mas = m;
        }

        private string Adding(int max, int len)
        {
            string a = "";

            for (int i = 0; i < max - len; i++)
                a += "_";
            return a;
        }

        public void Sort()
        {
            Array.Sort<T>(Mas, 0, Mas.Length);
        }

        public void Add(T item)
        {
            var len = Count;
            if ((Count + 1) > Mas.Length)
                upSize();

            Mas[len] = item;

            Count++;
        }

        public void AddRange(T[] mas)
        {
            int len = Count;
            int count = 0;
            while((Mas.Length - Count) < mas.Length)
                upSize();

            for (int i = len; i < len + mas.Length; i++)
            {
                Mas[i] = mas[count];
                count++;
                Count++;
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Mas.Length; i++)
                if (Mas[i].Equals(item))
                    return i;
            return -1;
        }

        public void Insert(int index, T item)
        {
            if ((index < Mas.Length) && (index >= Count))
            {
                Mas[index] = item;
                Count++;
            }
            else
            {
                if (index >= Mas.Length)
                {
                    while (index >= Mas.Length)
                        upSize();
                    Mas[index] = item;
                    Count++;
                }
                else
                {
                    InsertingUp(index, item);
                    Count++;
                }
            }
        }

        private void InsertingUp(int index, T item)
        {
            if (Mas.Length < (Count + 1))
                upSize();

            T[] temp = new T[Mas.Length];

            for (int i = 0; i < Count; i++)
            {
                if (index != i)
                    temp[i] = Mas[i];
                else
                {
                    temp[i] = item;
                    for (int j = i + 1; j < Count + 1; j++)
                        temp[j] = Mas[j - 1];
                    break;
                }
            }
            Mas = temp;
        }

        public bool Remove(T item)
        {
            int n = 0;
            T[] temp = new T[Count - 1];

            if (!Mas.Contains(item))
                return false;

            for (int i = 0; i < Count - 1; i ++)
            {
                if (!Mas[n].Equals(item))
                {
                    temp[i] = Mas[n];
                    n++;
                }
                else
                {
                    n++;
                    i--;
                }
            }
            Mas = temp;
            Count--;
            return true;
        }

        public void RemoveAt(int index)
        {
            int n = 0;
            T[] temp = new T[Count - 1];

            if (index > Count)
                throw new Exception("Index out of range");

            for (int i = 0; i < Count - 1; i++)
            {
                if (n != index)
                {
                    temp[i] = Mas[n];
                    n++;
                }
                else
                {
                    n++;
                    i--;
                }
            }
            Mas = temp;
            Count--;
        }

        private void upSize()
        {
            T[] temp = new T[Mas.Length * 2];

            for (int i = 0; i < Count; i++)
                temp[i] = Mas[i];

            Mas = temp;
        }

    }
}
