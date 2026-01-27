using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Day1
{
    class Procedure_vs_OOPS
    {
        #region [Procedural Programming]

        class Bank_Account_Procedural
        {
            public static int deposit(int currentBalance, int amount)
            {
                if(amount > 0)
                {
                    currentBalance += amount;
                    Console.WriteLine($"Deposit: {amount} Current Balance: {currentBalance}");
                }
                else
                {
                    Console.WriteLine("Invalid amount");
                }
                return currentBalance;
            }
            public static int withdraw(int currentBalance, int amount) 
            {
                if (amount > 0 && amount <= currentBalance) 
                { 
                    currentBalance -= amount;
                    Console.WriteLine($"Withdraw: {amount} Current Balance: {currentBalance}");
                }
                else
                {
                    Console.WriteLine("Invalid amount or Insufficient balance");
                }
                return currentBalance;
            }
            public static void Main()
            {
                long AccountNumber = 123456789;
                string Name = "Aayush";
                int Balance = 1000;

                //Console.Write("Enter Account Number: ");
                //AccountNumber = Convert.ToInt64(Console.ReadLine());
                //Console.Write("Enter Your Name: ");
                //Name = Console.ReadLine();
                //Console.Write("Enter Current Balance: ");
                //Balance = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"CurrentBalance: {Balance}");
                Balance = deposit(Balance, 5000);
                Balance = deposit(Balance, 1000);
                Balance = withdraw(Balance, 2500);
                Balance = withdraw(Balance, 5000);
                Console.WriteLine($"CurrentBalance: {Balance}");

        }
        }

        #endregion

        #region [Object Oriented Programming]

        class Bank_Account_OOPS
        {
            private long AccountNumber;
            public string Name;
            private int Balance;

            public Bank_Account_OOPS(long accountNumber, string name, int balance)
            {
                AccountNumber = accountNumber;
                Name = name;
                Balance = balance;
            }
           
            public void Deposit(int amount)
            {
                if(amount > 0)
                {
                    Balance += amount;
                    Console.WriteLine($"Deposit: {amount} Current Balance: {Balance}");
                }
                else
                {
                    Console.WriteLine("Invalid amount");
                }
            }
            public void Withdraw(int amount)
            {
                if(amount > 0 && amount <= Balance)
                {
                    Balance -= amount;
                    Console.WriteLine($"Withdraw: {amount} Current Balance: {Balance}");
                }
                else
                {
                    Console.WriteLine("Invalid amount or Insufficient balance");
                }
            }
            public int CurrentBalance()
            {
                return Balance;
            }

            public static void Main()
            {
                Bank_Account_OOPS obj = new Bank_Account_OOPS(132568974,"Aayush Panchasara",5000);

                Console.WriteLine($"Current Balance: {obj.CurrentBalance()}");
                obj.Deposit(1000);
                obj.Withdraw(5000);
                obj.Deposit(2000);
                obj.Withdraw(4000);
                Console.WriteLine($"Current Balance: {obj.CurrentBalance()}");
            }
            #endregion

        }
    }
}
