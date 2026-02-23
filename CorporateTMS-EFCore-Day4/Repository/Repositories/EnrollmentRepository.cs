using CorporateTMS_EFCore_Day4.Repository.Data;
using CorporateTMS_EFCore_Day4.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Repository.Repositories
{
    internal class EnrollmentRepository
    {
        private AppDBContext _context;
        public EnrollmentRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Add(Enrollment enrollment)
        {

            var Employee = _context.Employees.OfType<Employee>().FirstOrDefault(e => e.Id == enrollment.EmployeeId);

            var TrainingProgram = _context.TrainingPrograms.FirstOrDefault(t => t.Id == enrollment.TrainerProgramId);

            if (TrainingProgram == null) {
                throw new Exception("Training Program does not exists.");
            
            }
            if (Employee == null) {
                throw new Exception("Employee does not exists.");
            }


            _context.Enrollments.Add(enrollment);
            try
            {
                _context.SaveChanges();
                Console.WriteLine("Employee Enroll in training Successfully\n");
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void Update(Enrollment enrollment) {

            var Enrollment = _context.Enrollments.FirstOrDefault(e => e.EmployeeId == enrollment.EmployeeId && e.TrainerProgramId == enrollment.TrainerProgramId);

            if (Enrollment == null) {
                throw new Exception("Employee is not enrolled in Training Program");
            }

            Enrollment.PerformanceScore = enrollment.PerformanceScore;

            try
            {
                _context.SaveChanges();
                Console.WriteLine("Employee's Performance Score Updated Successfully\n");
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

        }

    }
}
