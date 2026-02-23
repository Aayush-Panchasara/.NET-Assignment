using CorporateTMS_EFCore_Day4.Repository.Model;
using CorporateTMS_EFCore_Day4.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Services
{
    internal class DepartmentServices
    {
        private DepartmentRepository _deptRepo;
        public DepartmentServices(DepartmentRepository deptRepo)
        {
            _deptRepo = deptRepo;
        }

        public void CreateDepartment(string name, string location)
        {
            var Department = new Department() { Name = name, Location = location};

            _deptRepo.Add(Department);

        }
        public List<Department> GetDepartments()
        {

            return _deptRepo.GetAll();

        }
        public Department GetDepartmentById(int id)
        {

            return _deptRepo.Get(id);
        }
        public void UpdateDepartment(int id, string newName, string newLocation)
        {
            var Department = _deptRepo.Get(id);

            Department.Name = newName;
            Department.Location = newLocation;

            _deptRepo.Update(Department, id);


        }
        public void DeleteDepartment(int id)
        {

            _deptRepo.Delete(id);
        }

        public List<Department> DepartmentReport()
        {
            return _deptRepo.GenerateReport();
        }
    }
}

