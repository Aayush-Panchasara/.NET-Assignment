using CorporateTMS_EFCore_Day4.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Controller
{
    internal class EmployeeController
    {
        private EmployeeService _empService;
        public EmployeeController(EmployeeService service) {
            _empService = service;
        }

        public void ShowOption()
        {
            Console.WriteLine("For Employee");
            Console.WriteLine("Press 1 for Add Employee.----------(Task 2)");
            Console.WriteLine("Press 2 for GetAll Employee");
            Console.WriteLine("Press 3 for GetAll Employee By Id");
            Console.WriteLine("Press 4 for Update Employee");
            Console.WriteLine("Press 5 for Delete Employee\n");

        }

        public void TakeUserInput()
        {
            
            ShowOption();
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option) 
            {
                case 1:
                    Console.Write("Enter Employee Name:");
                    string name = Console.ReadLine();

                    Console.Write("Enter Employee Email:");
                    string email = Console.ReadLine();

                    Console.Write("Enter Employee's DepartmentId:");
                    int deptId = Convert.ToInt32(Console.ReadLine());

                    _empService.CreateEmployee(name, email, deptId);
                    break;

                case 2:
                    var Employees = _empService.GetEmployees();

                    foreach (var e in Employees)
                    {
                        Console.WriteLine($"Id:{e.Id}, Name:{e.Name}, Email:{e.Email}, Department:{e.Department.Name}");
                    }
                    Console.WriteLine();
                    break;

                case 3:
                    Console.Write("Enter Employee Id:");
                    int Id = Convert.ToInt32(Console.ReadLine());

                    var emp = _empService.GetEmployeesById(Id);

                    Console.WriteLine($"Id:{emp.Id}, Name:{emp.Name}, Email:{emp.Email}, Department:{emp.Department.Name}");
                    Console.WriteLine();
                    break;

                case 4:
                    Console.Write("Enter Employee Id:");
                    int UpdateId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Employee Name:");
                    string newName = Console.ReadLine();

                    Console.Write("Enter Employee Email:");
                    string newEmail = Console.ReadLine();

                    _empService.UpdateEmployee(UpdateId, newEmail, newName);
                    break;

                case 5:
                    Console.Write("Enter Employee Id:");
                    int DeleteId = Convert.ToInt32(Console.ReadLine());

                    _empService.DeleteEmployee(DeleteId);
                    break;




            }

        }
    }
}
