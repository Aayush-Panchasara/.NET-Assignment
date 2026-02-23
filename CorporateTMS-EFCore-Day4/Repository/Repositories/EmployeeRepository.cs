using CorporateTMS_EFCore_Day4.Repository.Data;
using CorporateTMS_EFCore_Day4.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CorporateTMS_EFCore_Day4.Repository.Repositories
{
    internal class EmployeeRepository
    {
        private AppDBContext _context;
        public EmployeeRepository(AppDBContext context) {
            _context = context;
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            try {
                _context.SaveChanges();
                Console.WriteLine("Employee Added Successfully\n");
            }
            catch(DbUpdateException e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void Update(Employee employee, int id) 
        {
            var Employee = _context.Employees.FirstOrDefault(e => e.Id == id);

            if(Employee == null)
            {
                throw new Exception("Employee Does not exists.");
            }

            Employee.Name = employee.Name;
            Employee.Email = employee.Email;

            try
            {
                _context.SaveChanges();
                Console.WriteLine("Employee Updated Successfully\n");

            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

        }

        public void Delete(int id) 
        {
            var Employee = _context.Employees.FirstOrDefault(e => e.Id == id);

            if (Employee == null)
            {
                throw new Exception("EMployee Does not exists.");
            }

            _context.Employees.Remove(Employee);

            try
            {
                _context.SaveChanges();
                Console.WriteLine("Employee Deleted Successfully\n");

            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

        }

        public Employee Get(int id)
        {
            var Employee = _context.Employees.Include(e => e.Department).Include(e => e.Enrollments).FirstOrDefault(e => e.Id == id);


            if (Employee == null)
            {
                throw new Exception("EMployee Does not exists.");
            }
            return Employee;
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.Include(e => e.Department).Include(e => e.Enrollments).ToList();


        }
    }
}
