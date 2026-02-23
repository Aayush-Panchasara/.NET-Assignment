using CorporateTMS_EFCore_Day4.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Controller
{
    internal class DepartmentController
    {
        private DepartmentServices _deptService;
        public DepartmentController(DepartmentServices service)
        {
            _deptService = service;
        }

        public void ShowOption()
        {
            Console.WriteLine("For Department");
            Console.WriteLine("Press 1 for Add Department");
            Console.WriteLine("Press 2 for GetAll Department");
            Console.WriteLine("Press 3 for GetAll Department By Id");
            Console.WriteLine("Press 4 for Update Department");
            Console.WriteLine("Press 5 for Delete Department");
            Console.WriteLine("Press 6 for Department Report.----------(Task 5)\n");

        }

        public void TakeUserInput()
        {

            ShowOption();
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("Enter Department Name:");
                    string name = Console.ReadLine();

                    Console.Write("Enter Department Location:");
                    string location = Console.ReadLine();

                    _deptService.CreateDepartment(name, location);
                    break;

                case 2:
                    var Departments = _deptService.GetDepartments();

                    foreach (var e in Departments)
                    {
                        Console.WriteLine($"Id:{e.Id}, Name:{e.Name}, Location:{e.Location}, EmployeeCount:{e.Employees.Count}");
                    }
                    Console.WriteLine();
                    break;

                case 3:
                    Console.Write("Enter Department Id:");
                    int Id = Convert.ToInt32(Console.ReadLine());

                    var dept = _deptService.GetDepartmentById(Id);

                    Console.WriteLine($"Id:{dept.Id}, Name:{dept.Name}, Location:{dept.Location}, EmployeeCount:{dept.Employees.Count}");
                    Console.WriteLine();
                    break;

                case 4:
                    Console.Write("Enter Department Id:");
                    int UpdateId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Department Name:");
                    string newName = Console.ReadLine();

                    Console.Write("Enter Department Location:");
                    string newLocation = Console.ReadLine();

                    _deptService.UpdateDepartment(UpdateId, newName,newLocation);
                    break;

                case 5:
                    Console.Write("Enter Department Id:");
                    int DeleteId = Convert.ToInt32(Console.ReadLine());

                    _deptService.DeleteDepartment(DeleteId);
                    break;

                case 6:
                    var departments = _deptService.DepartmentReport();

                    foreach (var item in departments)
                    {
                        Console.WriteLine($"Department: {item.Name}");
                        Console.WriteLine($"Total Employees: {item.Employees.Count}");
                        var count = 0;
                        foreach (var item1 in item.Employees)
                        {
                            if(item1.Enrollments.Count > 0)
                            {
                            count++;
                            }
                        }
                            Console.WriteLine($"Enrolled Employee: {count}\n");
                    }


                    break;



            }

        }
    }
}

