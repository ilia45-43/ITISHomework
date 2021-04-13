using System;
using System.Collections.Generic;
using System.Linq;

namespace _1_Kontrol_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new List<int>();
            a.Add(3);
            a.Add(5);
            a.Add(7);
            a.Add(9);
            Console.WriteLine("Исходный массив");
            foreach (var e in a)
                Console.Write($"{e} ");
            Console.WriteLine();
            Console.WriteLine("Итоговый массив");
            foreach (var e in Q2(a))
                Console.Write($"{e} ");
        }

        static List<int> Q2(List<int> list) // 2 Задание
        {
            List<int> lis = new List<int>();
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
                lis.Add(sum);
            }
            return lis;
        }

        struct SetOfStack // 1 Задание
        {
            public List<Stack<int>> stack;
            public int Count;
            public int Max;

            public SetOfStack(int max)
            {
                this.Max = max;
                stack = new List<Stack<int>>();
                Count = 0;
            }

            public int pop()
            {
                int pop = stack[stack.Count - 1].Pop();
                Count--;
                return pop;
            }

            public void Push(int item)
            {
                if(Count % Max == 0)
                {
                    stack.Add(new Stack<int>());
                    stack[stack.Count - 1].Push(item);
                    Count++;
                }
                else
                {
                    stack[stack.Count - 1].Push(item);
                    Count++;
                }
            }
        }

        static Dictionary<string, int> Max_dct(List<Dictionary<string, int>> list) // 3 Задание
        {
            var lis = new Dictionary<string, int>();

            for (int i = 0; i < list.Count; i++)
                foreach(var e in list[i])
                {
                    if (lis.ContainsKey(e.Key))
                        lis[e.Key] = Math.Max(e.Value, lis[e.Key]);

                    else
                        lis.Add(e.Key, e.Value);
                }

            return lis;
        }
    }
}
