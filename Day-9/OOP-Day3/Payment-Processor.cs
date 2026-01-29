using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Day3
{
    public class PaymentProcessor
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Parent class: Payment processing....");
        }
        public virtual void ProcessPayment(int id)
        {
            Console.WriteLine($"Parent class: Payment processing for id {id}");
        }
        public void ProcessPayment(int id,string name)
        {
            Console.WriteLine($"Parent class: Payment processing for id= {id} Name= {name}");
        }
    }

    public class UPI : PaymentProcessor
    {
        public override void ProcessPayment(int id)
        {
            Console.WriteLine($"UPI Payment processing for id {id}");
        }
    }

    public class CreditCard : PaymentProcessor
    {
        public override void ProcessPayment(int id)
        {
            Console.WriteLine($"Credit Card Payment processing for id {id}");
        }
    }
    internal class Payment_Processor
    {

        public static void Main()
        {
            PaymentProcessor p1 = new PaymentProcessor();
            //p1.ProcessPayment();
            //p1.ProcessPayment(1);
            //p1.ProcessPayment(2, "Aayush");


            PaymentProcessor p2 = new UPI();
            //p2.ProcessPayment();
            //p2.ProcessPayment(2);

            PaymentProcessor p3 = new CreditCard();
            //p3.ProcessPayment();
            //p3.ProcessPayment(3);
        }
    }
}
