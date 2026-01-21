using System;
using System.Collections.Generic;
using System.Text;
using OnlyName = Day_4_First.Name;
using NameAndAge = Day_4_Second.Name;



namespace Day_4_First
{
    class Name
    {
        public string name;
        public Name(string name)
        {
            this.name = name; 
        }
        public void Greet()
        {
            Console.WriteLine($"Hello {name}, How are you?");
        }
    }
}

namespace Day_4_Second
{
    public class Name
    {
        public string name;
        public int age;
        public Name(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"{name} is {age} year old.");
        }
    }
}


namespace Day_4
{
     class NameSpace
    {
        public static void Main()
        {
            //General Way
            //Console.WriteLine("Using 'Day_4_First' namespace");
            //Day_4_First.Name user1 = new Day_4_First.Name("Aayush");
            //user1.Greet();
            //Console.WriteLine();

            //Console.WriteLine("Using 'Day_4_Second' namespace");
            //Day_4_Second.Name user2 = new Day_4_Second.Name("Piyush", 21);
            //user2.DisplayInfo();

            //Method 2 ---- (Recommended)
            Console.WriteLine("Using 'Day_4_First' namespace");
            OnlyName user1 = new OnlyName("Aayush");
            user1.Greet();
            Console.WriteLine();

            Console.WriteLine("Using 'Day_4_Second' namespace");
            NameAndAge user2 = new NameAndAge("Piyush", 21);
            user2.DisplayInfo();
        }
    }
}
