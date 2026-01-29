using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Day3
{
    public class Parent
    {
        public virtual void Greet()
        {
            Console.WriteLine("Good Morning from Parent class");
        }

        public void SayHello()
        {
            Console.WriteLine("Hello from Parent class");
        }
    }

    public class Derived : Parent
    {
        public override void Greet()
        {
            Console.WriteLine("Good Morning from Derived class");
        }
        public new void SayHello() {
            Console.WriteLine("Hello from Derived class");
        }
    }
    internal class Method_Hiding
    {
        
        public static void Main()
        {
            Parent p1 = new Derived();
            p1.SayHello(); //It will call parent method because it has a reference of parent class.
            p1.Greet();

            Derived p2 = new Derived();
            p2.SayHello(); //Call Derived method
            p2.Greet();
        }
    }
}
