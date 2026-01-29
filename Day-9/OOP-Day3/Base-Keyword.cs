using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Day3
{
    public class Base
    {
        public int ID;
        public Base()
        {
            Console.WriteLine("Inside Base class (Parameter less constructor)");
        }
        public Base(int id)
        {
            ID = id;
            Console.WriteLine("Inside Base class (Parameterized constructors)");
        }
    }
    public class Child : Base
    {
        public string Name;

        public Child()
        {
            Console.WriteLine("Inside Child class constructor (Parameter less)");
        }
        public Child(int id) : base(id) 
        {
            Console.WriteLine("Inside Child class constructor (One parameter)");
        }
        public Child(int id, string name) : base(id)
        {
            Name = name;
            Console.WriteLine("Inside Child class constructor (Two parameter)");
        }
    }
    internal class Base_Keyword
    {
        public static void Main()
        {
            Base c1 = new Child();
            Console.WriteLine();
            Base c2 = new Child(5);
            Console.WriteLine();
            Base c3 = new Child(4,"Aayush");
        }
    }
}
