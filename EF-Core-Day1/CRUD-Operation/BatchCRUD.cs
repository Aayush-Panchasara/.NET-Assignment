using EF_Core_Day1.Data;
using System;
using System.Collections.Generic;
using System.Text;
using EF_Core_Day1.Model;
using System.Diagnostics.CodeAnalysis;

namespace EF_Core_Day1.CRUD_Operation
{
    internal class BatchCRUD
    {
        public void AddBatch(AppContextDB context)
        {
            Console.WriteLine("For Batch");
            Console.Write("Enter the Starting Date of Batch(Ex. YYYY/MM/DD) : ");
            DateOnly date = DateOnly.FromDateTime(Convert.ToDateTime(Console.ReadLine()));

            Console.Write("Enter the course ID for batch : ");
            int courseId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the trainer ID for batch : ");
            int trainerId = Convert.ToInt32(Console.ReadLine());

            Batch batch = new Batch() { StartDate = date,CourseId=courseId, TrainerId= trainerId};

            var result = context.Batches.Add(batch);

            try
            {
                context.SaveChanges();
                Console.WriteLine("Batch Inserted Successfully.");
            }
            catch (Exception ex) {
                Console.WriteLine($"Batch Insertion Failed: {ex.Message}");
            }


        }
    }
}
