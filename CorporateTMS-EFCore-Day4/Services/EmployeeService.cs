using CorporateTMS_EFCore_Day4.Repository.Model;
using CorporateTMS_EFCore_Day4.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Services
{
    internal class EmployeeService
    {
        private EmployeeRepository _empRepo;
        public EmployeeService(EmployeeRepository empRepo) {
            _empRepo = empRepo;
        }

        public void CreateEmployee(string name, string email, int deptId) {
            var Employee = new Employee() {Name=name, Email=email, DepartmentId= deptId };

            _empRepo.Add(Employee);
        
        }
        public List<Employee> GetEmployees() {
           
            return _empRepo.GetAll();
        
        }
        public Employee GetEmployeesById(int id) {

            return _empRepo.Get(id);
        }
        public void UpdateEmployee(int id, string newName, string newEmail) {
            var Employee = _empRepo.Get(id);

            Employee.Name = newName;
            Employee.Email = newEmail;

            _empRepo.Update(Employee,id);
            

        }
        public void DeleteEmployee(int id) {

            _empRepo.Delete(id);
        }

    }
}
