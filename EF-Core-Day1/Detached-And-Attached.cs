using Castle.Core.Logging;
using EF_Core_Day1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_Day1
{
    internal class Detached_And_Attached
    {
        public static void PerformDetached(AppContextDB context)
        {
            var student = context.Students.FirstOrDefault();
            Console.WriteLine($"Student Name Before Updation: {student.Name}");

            context.Entry(student).State = EntityState.Detached;

            Console.Write("Enter student's new name: ");
            student.Name = Console.ReadLine();
            context.SaveChanges();

            student = context.Students.FirstOrDefault();
            Console.WriteLine($"Student Name After Updation: {student.Name}");

        }
        public static void PerformAsNoTracking(AppContextDB context)
        {
            Console.WriteLine("AsNoTracking...");
            var students = context.Students.AsNoTracking();
   
            var student1 = students.FirstOrDefault();
            var student2 = students.FirstOrDefault(s => s.Id==2);
            Console.WriteLine($"Student 1 Name Before Updation: {student1.Name}");
            Console.WriteLine($"Student 2 Name Before Updation: {student2.Name}");


            Console.Write("Enter new Name For Student 1: ");
            student1.Name = Console.ReadLine();
            Console.Write("Enter new Name For Student 2: ");
            student2.Name = Console.ReadLine();

            context.SaveChanges();

            student1 = context.Students.FirstOrDefault();
            student2 = context.Students.FirstOrDefault(s => s.Id == 2);
            Console.WriteLine($"Student 1 Name After Updation: {student1.Name}");
            Console.WriteLine($"Student 2 Name After Updation: {student2.Name}");
        }

        public static void UpdateAttachedData(AppContextDB context)
        {
                var student = context.Students.AsNoTracking().FirstOrDefault();

                Console.WriteLine($"Student Name Before Updation: {student.Name}");


                Console.Write("Enter new Name For Student: ");
                student.Name = Console.ReadLine();

                Console.WriteLine("Before: "+context.Entry(student).State);
                context.Attach(student);
                //context.Entry(student).State = EntityState.Modified;

                Console.WriteLine("After: "+context.Entry(student).State);
                context.SaveChanges();

               var student1 = context.Students.FirstOrDefault();
                Console.WriteLine($"Student 1 Name After Updation: {student1.Name}");
        }
    }
}
