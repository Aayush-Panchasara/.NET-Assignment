using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day_6
{
    class Concurrent_Collection
    {
        //static List<int> list = new List<int>();
        static ConcurrentBag<int> conCurrentList = new ConcurrentBag<int>();

        public static void Add50()
        {
            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(100);
                //list.Add(i);
                conCurrentList.Add(i);
            }
        }
        public static void Add100()
        {
            for (int i = 5; i <= 10; i++)
            {
                Thread.Sleep(100);
                //list.Add(i);
                conCurrentList.Add(i);
            }
        }
        public static void Main()
        {
            Thread t1 = new Thread(Add50);
            Thread t2 = new Thread(Add100);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            foreach (var item in conCurrentList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
