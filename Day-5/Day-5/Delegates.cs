using System;
using System.Collections.Generic;
using System.Text;

namespace Day_5
{
    public delegate void MathOperation(int a, int b);
    class Delegates
    {
        public static void Add(int a, int b)
        {
            Console.WriteLine($"Addition of {a} and {b}: {a+b}");
        }
        public static void Substract(int a, int b)
        {
            Console.WriteLine($"Substraction of {a} and {b}: {a-b}");
        }
        public static void Multiply(int a, int b)
        {
            Console.WriteLine($"Multiplication of {a} and {b}: {a*b}");
        }
        public static void Divide(int a, int b)
        {
            Console.WriteLine($"Division of {a} and {b}: {a/b}");
        }
   
        public static void Main()
        {
            MathOperation mp = new MathOperation(Add);
            mp += Substract;
            mp += Multiply;
            mp += Divide;

            mp(15, 8);
            mp.Invoke(10, 4);

        }
    }
}
