using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Day2
{
    interface IUser
    {
        void Method1();
        void Method2();
    }

    interface IAdminUser : IUser
    {
        void Method3();
        void Method4();
    }

    public class User : IUser, IAdminUser
    {
        public void Method1()
        {
            Console.WriteLine("Hello from Method 1...");
        }
        public void Method2()
        {
            Console.WriteLine("Hello from Method 2...");

        }
        public void Method3()
        {
            Console.WriteLine("Hello from Method 3...");

        }
        public void Method4()
        {
            Console.WriteLine("Hello from Method 4...");

        }
    }
    internal class Interface_Inheritance
    {
        public static void Main(string[] args)
        {
            IUser user1 = new User();
            user1.Method1();
            user1.Method2();
            //user1.Method3(); //It does not have access

            IAdminUser user2 = new User();
            user2.Method1();
            user2.Method2();
            user2.Method3();
            user2.Method4();
            
        }
    }
}
