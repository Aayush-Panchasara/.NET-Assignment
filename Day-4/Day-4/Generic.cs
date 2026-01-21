using System;
using System.Collections.Generic;
using System.Text;

namespace Day_4
{
    public class GenericRepo<T>
    {
        public List<T> items = new List<T>();

        public void AddItem(T item)
        {
            items.Add(item);
            Console.WriteLine($"Item Added: {item}");
        }

        public void PrintItem()
        {
            Console.WriteLine("Current Items:");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            
        }

        public void UpdateItem(T oldItem, T newItem)
        {
            int index = items.IndexOf(oldItem);

            if (index != -1)
            {
                items[index] = newItem;
                Console.WriteLine($"Item Updated: {newItem}");
            }
            else
            {
                Console.WriteLine("Item not found");
            }
        }

        public void DeleteItem(T item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                Console.WriteLine($"Item Deleted: {item}");
            }
            else
            {
                Console.WriteLine("Item not found");
            }
        }
    }
        class Generic
    {
        public static void Swap<T>(ref T a,ref T b)
        {
            T temp = a;
            a = b;
            b = temp;  
        }

        
        public static void Main()
        {
            //Swap method code
            int a = 4, b = 5;
            double d1 = 4.5d, d2 = 7.8d;
            Console.WriteLine($"Before: a={a} b={b}");
            Swap<int>(ref a, ref b);
            Console.WriteLine($"After: a={a} b={b}");

            Console.WriteLine($"Before: d1={d1} d2={d2}");
            Swap<double>(ref d1, ref d2);
            Console.WriteLine($"After: d1={d1} d2={d2}");
            Console.WriteLine();

            //Repository class

            //Console.WriteLine("String Repo");
            //GenericRepo<string> names = new GenericRepo<string>();

            //names.AddItem("Aayush");
            //names.AddItem("Piyush");
            //names.PrintItem();

            //names.UpdateItem("Aayush", "Aayush Panchasara");
            //names.DeleteItem("Piyush");
            //names.PrintItem();

            Console.WriteLine("Integer Repo");
            GenericRepo<int> numbers = new GenericRepo<int>();

            numbers.AddItem(100);
            numbers.AddItem(200);
            numbers.PrintItem();
            numbers.UpdateItem(100, 150);
            numbers.PrintItem();


        }
    }
}
