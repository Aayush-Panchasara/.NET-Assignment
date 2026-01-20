using System;
using System.Collections.Generic;
using System.Text;

namespace Day_3
{
    class InsufficientBalance : Exception
    {
        public InsufficientBalance(String msg) : base(msg) { }
    }
    class Exception_Ass1
    {
        int balance;
        public Exception_Ass1(int balance)
        {
            this.balance = balance;
        }
        public void CheckBalance()
        {
            Console.WriteLine($"Current balance: {balance}");
        }
        public void Withdraw(int amount)
        {
            if(amount > balance)
            {
                throw new InsufficientBalance("Available balance is insufficient");
            }
            balance -= amount;
            this.CheckBalance();
        }

        public static void Main(string[] args)
        {
            Exception_Ass1 user = new Exception_Ass1(5000);
            user.CheckBalance();
            try
            {
                user.Withdraw(4000);
                user.Withdraw(500);
                user.Withdraw(1000);
            }
            catch (InsufficientBalance ex) { 
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally is always execute");
            }

            
        }
    }
}
