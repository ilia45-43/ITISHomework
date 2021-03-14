using System;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {



        }
    }


    class Number<T>
    {
        public T Numb { get; set; }

        public Number (T n)
        {
            Numb = n;
        }

        public Number<T> add(Number<T> n)
        {
            return (dynamic)Numb + (dynamic)n;
        }

        public Number<T> sub(Number<T> n)
        {
            if ((dynamic)n > (dynamic)Numb) throw new NotNaturalNumberException("Не натурал");
            return (dynamic)Numb - (dynamic)n;
        }

        public int comapareTo(Number<T> n)
        {
            if ((dynamic)n < (dynamic)Numb) return 1;
            else if ((dynamic)n > (dynamic)Numb) return -1;
            else return 0;
        }
    }

    class NotNaturalNumberException : Exception
    {
        public NotNaturalNumberException(string massage) : base(massage) { }
    }

    class SimpleLongNumber 
    {
        public int SimpleNum { get; set; }
    }

    class VeryLongNumber
    {
        public int VeryNum { get; set; }
    }


}
