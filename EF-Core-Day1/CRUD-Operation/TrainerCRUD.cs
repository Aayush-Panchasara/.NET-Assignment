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
        AppContextDB context;
        public TrainerCRUD(AppContextDB context)
        {
            this.context = context;
        }

        public void StartCRUDOperation()
        {

            bool flag = false;
            while (!flag)
            {
                Console.WriteLine("What operations You want to perform On Trainer Table?");
                Console.WriteLine("Press 1 For Insert");
                Console.WriteLine("Press 2 For Update");
                Console.WriteLine("Press 3 For Delete");
                Console.WriteLine("Press 4 For Selection");


                int operation = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (operation)
                    {
                        case 1: AddTrainer(); break;
                        case 2: UpdateTrainer(); break;
                        case 3: DeleteTrainer(); break;
                        case 4: GetAllTrainer(); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.Write("\nDo you Want to continue TrainerCRUD?(y/n): ");
                char option = Convert.ToChar(Console.ReadLine());

                if (option == 'n')
                {
                    flag = true;
                }
                else if (option == 'y')
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Invalid Input Operation Stops");
                    break;
                }
            }

        }

        public void AddTrainer()
        {
            Console.WriteLine("For Trainer Insertion");
            Console.Write("Enter the Trainer Name: ");
            string Name = Console.ReadLine();

            Console.Write("Enter Trainer Experience(In Years): ");
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
        
        public void UpdateTrainer()
        {
            Console.WriteLine("For Trainer Updation:");
            Console.WriteLine("Enter the ID of Trainer that You want to update : ");
            int Id = Convert.ToInt32(Console.ReadLine());

            var trainer = context.Trainers.Where(t => t.Id == Id).FirstOrDefault();
            if (trainer == null)
            {
                throw new Exception($"Trainer with ID {Id} does not exists");
            }

            Console.WriteLine("What fields Do yo want to update?");
            Console.WriteLine("Press 1 for Name");
            Console.WriteLine("Press 2 for Experience");
            Console.WriteLine("Press 3 for Name & Experience");

            int option = Convert.ToInt32(Console.ReadLine());


            switch (option)
            {
                case 1:
                    Console.Write("Enter Trainer's New FullName: ");
                    string NewName = Console.ReadLine();
                    trainer.Name = NewName;
                    break;
                case 2:
                    Console.Write("Enter Trainer New Experience : ");
                    int NewExp = Convert.ToInt32(Console.ReadLine());
                    trainer.ExperienceInYear = NewExp;
                    break;
                case 3:
                    Console.Write("Enter Trainer's New FullName: ");
                    string NewName1 = Console.ReadLine();

                    Console.Write("Enter Trainer's New Experience: ");
                    int NewExp2 = Convert.ToInt32(Console.ReadLine());
                    trainer.Name = NewName1;
                    trainer.ExperienceInYear = NewExp2;
                    break;
            }

            try
            {
                context.SaveChanges();
                Console.WriteLine("\nTrainer Updated Successfully\n");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Updation Failed: {ex.Message}");
            }
        }

        public void DeleteTrainer()
        {
            Console.WriteLine("For Trainer Deletion:");
            Console.WriteLine("Enter the ID of Trainer that You want to Delete : ");
            int Id = Convert.ToInt32(Console.ReadLine());

            var trainer = context.Trainers.Where(t => t.Id== Id).FirstOrDefault();
            if (trainer == null)
            {
                throw new Exception($"Trainer with ID {Id} does not exists");
            }

            context.Trainers.Remove(trainer);

            try
            {
                context.SaveChanges();
                Console.WriteLine("\nTrainer Deleted Successfully\n");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Deletion Failed: {ex.Message}");
            }
        }

        public void GetAllTrainer()
        {
            var trainers = context.Trainers.ToList();
            Console.WriteLine("\nTrainer List: \n");
            foreach (var trainer in trainers)
            {

                Console.WriteLine($"{{Id={trainer.Id} Name={trainer.Name} Experience={trainer.ExperienceInYear}}}");
            }
            Console.WriteLine();
        }

        public void TrainerWithBatches() {
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

        public void BatchesWithSpecificTrainer() 
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
