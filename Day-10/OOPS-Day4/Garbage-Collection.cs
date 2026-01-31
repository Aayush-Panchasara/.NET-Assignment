using System;
using System.Collections.Generic;
using System.Text;

namespace OOPS_Day4
{
    public class GCDemo
    {
        public int id;
        public GCDemo(int id) {
            this.id = id;
            Console.WriteLine($"Object with id {id} is Created.");
        }

        ~GCDemo()
        {
            Console.WriteLine($"Object with id {id} is Collected.");
        }
    }
    class Garbage_Collection
    {
        public static void Main()
        {
            for (int i = 0; i < 5; i++)
            {
                GCDemo g1 = new GCDemo(i);
            }
            GC.Collect(); // Scan the heap for unreachable objects.
            GC.WaitForPendingFinalizers(); // wait for finalizer to finish the execution
        }
    }
}
