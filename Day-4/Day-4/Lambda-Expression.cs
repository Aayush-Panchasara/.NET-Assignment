using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Day_4
{
    class Lambda_Expression
    {
        
        public static void Main()
        {
            var list = new List<int> { 2, 1, 4, 8, 3, 10, 9, 5, 8, 6 };
            int temp = list[0];

            //Filter even number
            var FilterEvenNum = (List<int> list) =>
            {
                List<int> result = new List<int>();
                foreach (var item in list) { 
                    if(item % 2 == 0)
                    {
                        result.Add(item);
                    }
                }
                return result;
            };

            //Find maximun value
            var FindMax = (List<int> l) =>
            {
                foreach (var item in l)
                {
                    if(temp < item)
                    {
                        temp = item;
                    }
                }
                return temp;
            };  

            //Sort collection
            list.Sort((a,b) =>  a.CompareTo(b));

            
            Console.WriteLine($"Maximum value: {FindMax(list)}");
            var even_list = FilterEvenNum(list);

            Console.WriteLine("Even items in the list");
            foreach (var item in even_list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Sorted Collection");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }


        }
    }
}
