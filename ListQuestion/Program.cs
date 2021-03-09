using System;

namespace MiniQuests1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[10] { 1, 4, 2, 9, 8, 0, 11, 20, 30, 25 };
            var str = new string[5] { "faf", "asd", "fasd", "xvbxc", "sdgsv" };

            var lisStr = new list();

            var lisInt = new list(a);

            foreach (var e in lisStr.ChangeMin())
            {
                Console.Write($"{e} ");
            }

            foreach (var e in lisStr.all_eq(str))
            {
                Console.Write($"{e} ");
            }
        }
    }

    class list
    {
        public int[] Mas { get; set; }
        public string[] MasStr { get; set; }

        public list(int[] mas)
        {
            Mas = mas;
        }
        public list (string[] masStr)
        {
            MasStr = masStr;
        }

        public list(){ }

        public int[] ChangeMin()
        {
            int minn = 99999999;
            int maxx = 0;
            int indexF = 0, indexS = 0;

            for (int i = 0; i < Mas.Length; i++)
            {
                if (Mas[i] > maxx)
                {
                    maxx = Mas[i];
                    indexF = i;
                }
                if (Mas[i] < minn)
                {
                    minn = Mas[i];
                    indexS = i;
                }
            }
            Mas[indexF] = minn;
            Mas[indexS] = maxx;
            return Mas;
        }

        public string[] all_eq(string[] mas)
        {
            string[] newMas = new string[mas.Length];
            int maxStr = 0;

            for (int i = 0; i < mas.Length; i++)
                if (mas[i].Length > maxStr)
                    maxStr = mas[i].Length;

            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i].Length < maxStr)
                {
                    newMas[i] = mas[i] + Adding(maxStr, mas[i].Length);
                }
                else
                {
                    newMas[i] = mas[i];
                }
            }

            return newMas;
        }

        private string Adding(int max, int len)
        {
            string a = "";

            for (int i = 0; i < max - len; i++)
                a += "_";
            return a;
        }
    }
}
