using EF_Core_Day1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_Day1.EF_Loading
{
    internal class Loading
    {
        public static void EagerLoading(AppContextDB context)
        {
            Console.WriteLine("Eager Loading..");

            var result = context.Students.Include(s => s.Courses)
                                         .ThenInclude(c => c.Batches)
                                         .ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"\nStudent: {item.Name}");
                if (item.Courses.Count != 0)
                {
                    foreach (var item1 in item.Courses)
                    {
                        Console.WriteLine($"Course: {item1.Title}");
                        if (item1.Batches.Count != 0)
                        {
                            foreach (var item2 in item1.Batches)
                            {
                                Console.Write($"\tBatch {item2.Id} ");
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("No Batches");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No Courses");
                }
            }
        }

        public static void LazyLoading(AppContextDB context)
        {
            Console.WriteLine("Lazy Loading");

            var students = context.Students.ToList();

            foreach (var item in students)
            {
                Console.Write($"Student Name: {item.Name}, Total Course: {item.Courses.Count}\n");
            }

        }

        public static void ExplicitLoading(AppContextDB context)
        {
            var trainer = context.Trainers.FirstOrDefault();

            Console.WriteLine($"Trainer Name: {trainer.Name}");
            Console.WriteLine($"Batches: {trainer.Batches.Count}");

            context.Entry(trainer)
                   .Collection(t => t.Batches)
                   .Load();

            Console.WriteLine($"Trainer Name: {trainer.Name}");
            Console.WriteLine($"Batches: {trainer.Batches.Count}");
        }
    }
}
