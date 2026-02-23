using CorporateTMS_EFCore_Day4.Repository.Data;
using CorporateTMS_EFCore_Day4.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Repository.Repositories
{
    internal class DepartmentRepository
    {
        private AppDBContext _context;
        public DepartmentRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Add(Department department)
        {
            _context.Departments.Add(department);
            try
            {
                _context.SaveChanges();
                Console.WriteLine("Department Added Successfully\n");
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void Update(Department department, int id)
        {
            var Department = _context.Departments.FirstOrDefault(e => e.Id == id);

            if (Department == null)
            {
                throw new Exception("Department Does not exists.");
            }

            Department.Name = department.Name;
            Department.Location = department.Location;

            try
            {
                _context.SaveChanges();
                Console.WriteLine("Department Updated Successfully\n");

            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

        }

        public void Delete(int id)
        {
            var department  = _context.Departments.FirstOrDefault(e => e.Id == id);

            if (department == null)
            {
                throw new Exception("Department Does not exists.");
            }

            _context.Departments.Remove(department);

            try
            {
                _context.SaveChanges();
                Console.WriteLine("Department Deleted Successfully\n");

            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

        }

        public Department Get(int id)
        {
            var department = _context.Departments.Include(e => e.Employees).FirstOrDefault(e => e.Id == id);


            if (department == null)
            {
                throw new Exception("Department Does not exists.");
            }
            return department;
        }

        public List<Department> GetAll()
        {
            return _context.Departments.Include(e => e.Employees).ToList();


        }

        public List<Department> GenerateReport()
        {
            return _context.Departments.Include(d => d.Employees).ThenInclude(e => e.Enrollments).ToList();
        }
    }
}

