using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Day2
{
    interface INotification
    {
        void Notify();

    }

    public class EmailNotification : INotification
    {
        public void Notify() {
            Console.WriteLine("Email Notification...");
        }
    }

    public class SMSNotification : INotification 
    {
        public void Notify()
        {
            Console.WriteLine("SMS Notification...");
        }
    }
    internal class Notification_System
    {
        public static void Main(string[] args) {
            INotification email = new EmailNotification();
            email.Notify();

            INotification sms = new SMSNotification();
            sms.Notify();
        }

    }
}
