using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Day2
{
    interface ILogging
    {
        void Log();
    }
    interface IAuditing
    {
        void Log();
    }

    public class Interface_Implementation : ILogging, IAuditing
    {
         void ILogging.Log()
        {
            Console.WriteLine("Logs: ILogging Implemantation");
        }
         void IAuditing.Log()
        {
            Console.WriteLine("Logs: IAuditing Implementation");
        }

    }
    internal class Explicit_Interface
    {
        public static void Main()
        {
            //Method 1
            //ILogging logging = new Interface_Implementation();
            //logging.Log();
            //IAuditing auditing = new Interface_Implementation();
            //auditing.Log();

            //Method 2
            Interface_Implementation i1 = new Interface_Implementation();
            ((ILogging)i1).Log();
            ((IAuditing)i1).Log();
        }
    }
}
