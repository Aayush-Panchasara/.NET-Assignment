using EF_Core_Day1.Data;
using EF_Core_Day1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace EF_Core_Day1.CRUD_Operation
{
    internal class TrainerCRUD
    {
        public void AddTrainer(AppContextDB context)
        {
            Console.WriteLine("For Trainer Insertion");
            Console.Write("Enter the Trainer Name: ");
            string Name = Console.ReadLine();

            Console.Write("Enter Trainer Experience(In Years)");
            int ExpInYear = Convert.ToInt32(Console.ReadLine());

            var trainer = new Trainer() {Name=Name, ExperienceInYear=ExpInYear };

            var result = context.Trainers.Add(trainer);

            try
            {
                context.SaveChanges();
                Console.WriteLine("Trainer Inserted Successfully");
            }
            catch (Exception ex) {
                Console.WriteLine($"Trainer Insertion Failed: {ex.Message}");
            }
        }

        public void TrainerWithBatches(AppContextDB context) {
            var trainer = context.Trainers
                                 .Include(t => t.Batches)
                                 .ToList();

            foreach (var item in trainer)
            {
                Console.WriteLine($"\nTrainer: {item.Name}");
                if (item.Batches.Count != 0)
                {
                    foreach (var item1 in item.Batches)
                    {
                        Console.WriteLine($"\tBatch {item1.Id}: {item1.StartDate}");
                    }
                }
                else
                {
                    Console.WriteLine("\tNo Batches");
                }
            }
        }

        public void BatchesWithSpecificTrainer(AppContextDB context) 
        {
            Console.Write("Enter the Trainer name: ");
            string Name = Console.ReadLine();

            var trainer = context.Trainers
                                 .Where(t => t.Name == Name)
                                 .Include(t => t.Batches)
                                 .ToList();
            if(trainer.Count == 0)
            {
                Console.WriteLine($"Trainer {Name} does not exists.");
            }

            foreach (var item in trainer)
            {
                Console.WriteLine($"\nTrainer: {Name}");
                if(item.Batches.Count != 0)
                {
                    foreach (var item1 in item.Batches)
                    {
                        Console.WriteLine($"\tBatch {item1.Id}: {item1.StartDate}");
                    }
                }
                else
                {
                    Console.WriteLine("\tNo batches");
                }
            }

        }
    }
}
