using System;
using System.Collections.Generic;
using System.Text;

namespace Day_5
{
    class Boxing_Unboxing
    {
        public static void Main()
        {
            int originalValue = 18;
            Console.WriteLine($"Original value: {originalValue}");

            object boxValue = originalValue; //Implicit type-casting
            Console.WriteLine($"After boxing: {boxValue}");

            int unboxValue = (int)boxValue;  //Explicit type-casting
            Console.WriteLine($"After unboxing: {unboxValue}");

        }
    }
}
