using System;
using System.Collections.Generic;
using System.Text;

namespace Day_5
{
    public static class StringExtension
    {
        public static int UniqueCharacterCount(this string str)
        {
            int count = 0;
            if (str == null || str == string.Empty) { 
                return count; 
            }
            HashSet<char> characters = new HashSet<char>(str.ToLower());
            count = characters.Count;

            return count;
        }
    }
     class Extension_Methods
    {
        public static void Main()
        {
            string name = "Aaaaayyyyush";
            Console.WriteLine($"Length: {name.Length}");
            Console.WriteLine($"Unique Character: {name.UniqueCharacterCount()}");
        }
    }
}
