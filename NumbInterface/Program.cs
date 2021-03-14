using System;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {

            var simp = new SimpleLongNumber();

            Console.WriteLine(simp);

        }
    }

    interface INumber
    {
        public dynamic Value { get; set; }

        INumber add(INumber number);
        INumber sub(INumber number);
        int compareTo(INumber number);
    }

    class SimpleLongNumber : INumber
    {
        public dynamic Value { get; set; }
        
        public INumber add(INumber number)
        {
            return Value + number.Value;
        }

        public int compareTo(INumber number)
        {
            if (number.Value < Value) return 1;
            else if (number.Value > Value) return -1;
            else return 0;
        }

        public INumber sub(INumber number)
        {
            return Value - number.Value;
        }

        public override string ToString()
        {
            return Value;
        }
    }

    class VeryLongNumber : INumber
    {
        public dynamic Value { get; set; }

        public INumber add(INumber number)
        {
            return Value + number.Value;
        }

        public int compareTo(INumber number)
        {
            if (number.Value < Value) return 1;
            else if (number.Value > Value) return -1;
            else return 0;
        }

        public INumber sub(INumber number)
        {
            return Value - number.Value;
        }
    }

    class NotNaturalNumberException : Exception
    {
        public NotNaturalNumberException(string massage) : base(massage) { }
    }
}