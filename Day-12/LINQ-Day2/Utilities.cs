using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Day2
{   
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpSalary { get; set; }
        public int DepartmentId { get; set; }
        public static List<Employee> employees;

        public Employee(int empId, string empName, int empSalary, int departmentId)
        {
            EmpId = empId;
            EmpName = empName;
            EmpSalary = empSalary;
            DepartmentId = departmentId;
        }

        public static void AddEmployees()
        {
            employees = new List<Employee>() {
                new Employee(100,"Will",32000,1),
                new Employee(101, "Dustin",28000, 3),
                new Employee(102, "Mike",26000, 2),
                new Employee(103, "Eleven",31000, 1),
                new Employee(104, "Lucas",21000, 1),
                new Employee(105, "Max",22000,2)
            };
        }
    }

    public class Department
    {
        public int DepId { get; set; }
        public string DepName { get; set; }
        public static List<Department> departments;

        public Department(int depId, string depName)
        {
            DepId = depId;
            DepName = depName;
        }

        public static void AddDepartments()
        {
            departments = new List<Department>()
            {
                new Department(1,"IT"),
                new Department(2,"Marketing"),
                new Department(3,"HR"),
                new Department(4,"Finance"),
            };
        }
    }
    internal class Utilities
    {
    }
}
