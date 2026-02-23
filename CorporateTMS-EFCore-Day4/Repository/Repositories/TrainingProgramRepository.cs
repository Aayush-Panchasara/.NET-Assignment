    using CorporateTMS_EFCore_Day4.Repository.Data;
using CorporateTMS_EFCore_Day4.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Repository.Repositories
{
    internal class TrainingProgramRepository
    {
        private AppDBContext _context;
        public TrainingProgramRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Add(TrainingProgram trainingProgram)
        {
            var Trainer = _context.Employees.OfType<Trainer>().FirstOrDefault(e=> e.Id == trainingProgram.TrainerId);

            if (Trainer == null) {

                throw new Exception("Trainer Does not Exists.");
            
            }

            _context.TrainingPrograms.Add(trainingProgram);
            try
            {
                _context.SaveChanges();
                Console.WriteLine("Training Program Added Successfully\n");
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void Update(TrainingProgram trainingProgram, int id)
        {
            var TrainingProgram = _context.TrainingPrograms.FirstOrDefault(e => e.Id == id);

            if (TrainingProgram == null)
            {
                throw new Exception("Training Program Does not exists.");
            }

            TrainingProgram.Title = trainingProgram.Title;
            TrainingProgram.StartDate = trainingProgram.StartDate;
            TrainingProgram.Duration = trainingProgram.Duration;
          


            try
            {
                _context.SaveChanges();
                Console.WriteLine("Training Program Updated Successfully\n");

            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

        }

        public void Delete(int id)
        {
            var TrainingProgram = _context.TrainingPrograms.FirstOrDefault(e => e.Id == id);

            if (TrainingProgram == null)
            {
                throw new Exception("Training Program Does not exists.");
            }

            _context.TrainingPrograms.Remove(TrainingProgram);

            try
            {
                _context.SaveChanges();
                Console.WriteLine("Training Program Deleted Successfully\n");

            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

        }

        public TrainingProgram Get(int id)
        {
            var TrainingProgram = _context.TrainingPrograms.Include(e => e.Trainer).Include(t => t.Enrollments).FirstOrDefault(e => e.Id == id);


            if (TrainingProgram == null)
            {
                throw new Exception("Training Program Does not exists.");
            }
            return TrainingProgram;
        }

        public List<TrainingProgram> GetAll()
        {
            return _context.TrainingPrograms.Include(e => e.Trainer).Include(e => e.Enrollments).ThenInclude(e => e.Employee).ThenInclude(e => e.Department).ToList();   

        }
    }
}
