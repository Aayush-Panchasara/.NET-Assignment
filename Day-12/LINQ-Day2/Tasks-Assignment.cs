using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Day2
{
    
    internal class Tasks_Assignment
    {
        public static void ExecuteTask1(List<Employee> employees,List<Department> departments)
        {
            var HighestSalary = employees.Max(emp => emp.EmpSalary);
            var LowestSalary = employees.Min(emp => emp.EmpSalary);
            var TotalSalary = employees.Sum(emp => emp.EmpSalary);
            var AverageSalary = employees.Average(emp => emp.EmpSalary);

            var result = from emp in employees
                         join dept in departments on emp.DepartmentId equals dept.DepId
                         group dept by dept.DepName into g
                         select (new { DepartName = g.Key, Count = g.Count() });

            Console.WriteLine($"Highest Salary: {HighestSalary}");
            Console.WriteLine($"Lowest Salary: {LowestSalary}");
            Console.WriteLine($"Total Salary: {TotalSalary}");
            Console.WriteLine($"Average Salary: {AverageSalary}");

            Console.WriteLine("Department wise employee count");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            /*
             THEORY:
            1)Aggeragate functions => It is used to perform mathematical operation on a column/field and return a single value as a result of the query.
                                    
                a)Count() => Count the total number of elements/item in the collection and return it.
                b)Min() => Find the minimum value in a collection
                c)Max() => Find the maximum value in a collection
                d)Sum() => Count the total sum of elements in the collection
                e)Average() => Calculate the average value

            Here I use aggeragate function for finding maximum salary, minimum salary, total salary and average salary

            2)Join => It perform inner join and return only the matched column in the database.

            Here i used inner join inorder to access the deptname value because if i used only employee table then i have only deptID and i want deptname in my result.

            3)Group => it will make the group of elements/fields based on specified column.

            Here i use group to make a group of employee based on deptname
            'g' is a temporary identifier for the group and which store some valuse which we can use further. (such has 'Key' )

             */
        }
        public static void ExecuteTask2(List<Employee> employees, List<Department> departments)
        {
            //Query 1
            var result1 = from employee in employees
                         join dept in departments on employee.DepartmentId equals dept.DepId
                         select new { employee.EmpName, dept.DepName };

            //Query 2
            var result2 = from dept in departments
                          join emp in employees on dept.DepId equals emp.DepartmentId into empGroup
                          select (new {DepartmentName = dept.DepName, Employees = empGroup });

            Console.WriteLine("Employee with their department Name");
            foreach (var item in result1)
            {
                Console.WriteLine($"EmployeeName: {item.EmpName}, DepartmentName: {item.DepName}");
            }
            Console.WriteLine();
            Console.WriteLine("Department with employees list");
            foreach (var item in result2)
            {
                int i = 0;
                Console.WriteLine(item.DepartmentName);
                foreach (var item1 in item.Employees)
                {
                    Console.WriteLine($"{++i}){item1.EmpName}");
                }
                Console.WriteLine();
            }

            /*
             THEORY :

            Query 1 => It is simple inner join inorder to return employee name along with departmentname

            Query2 => GroupJoin()/into : It will also perform the grouping but it will return a collection of matched item based on a common field.
                                         It is intenally join + groupby in a single step.

            Here empGroup is a collection of employee based on deptId which is acts as a common field.
             */
        }
        public static void ExecuteTask3(List<Employee> employees, List<Department> departments)
        {
            var result = from emp in employees
                         join dept in departments on emp.DepartmentId equals dept.DepId
                         group emp by dept.DepName into g
                         select (new
                         {
                             DepartmentName = g.Key,
                             TotalSalary = g.Sum(emp => emp.EmpSalary),
                             AverageSalary = g.Average(emp => emp.EmpSalary),
                             TotalEmployee = g.Count()
                         });
            Console.WriteLine("Department-wise Total salary, Average salary and Total number of employee");

            foreach (var item in result)
            {
                Console.WriteLine($"Department Name: {item.DepartmentName}");
                Console.WriteLine($"1)Total salary: {item.TotalSalary}");
                Console.WriteLine($"2)Average salary: {item.AverageSalary}");
                Console.WriteLine($"3)Total Employees: {item.TotalEmployee}");
                Console.WriteLine();
            }

            /*
             THEORY:
            Here i use join + grouping + aggegaration in a single query

            Join => to access the delpname

            group => grouping the employee based on deptname. 'g' contain all the fields of emp, key field and other methods and aggeragate functions.

            In anonymous type and some fields like Delpname, total salary, average salary and calculate the result with the help of aggeragate function.
             
             */
        }
        public static void ExecuteTask4(List<Employee> employees, List<Department> departments)
        {
            var AverageSalary = employees.Average(emp => emp.EmpSalary);

            //These query return Enumerable collection.
            var HighestSalaryOfHREnumerable = from emp in employees
                                    join dept in departments
                                    on emp.DepartmentId equals dept.DepId
                                    group emp by dept.DepName into g
                                    where g.Key == "HR"
                                    select g.Max(g =>  g.EmpSalary);


            //Here we extract the integer value from the enumerable collection.
            int HighestSalaryOfHRInt = 0;
            foreach (var item in HighestSalaryOfHREnumerable)
            {
                HighestSalaryOfHRInt = item;
            }

            //Query 1
            var result1 = from emp in employees
                          where emp.EmpSalary > AverageSalary
                          select emp.EmpName;

            
            //Query 2
            var result2 = from emp in employees
                          where emp.EmpSalary > HighestSalaryOfHRInt
                          select emp.EmpName;


            Console.WriteLine("Name of employee whose salary is greater than average salary of all employee\n");
            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Name of employee whoes salary is greater than highest salary of HR department employee\n");
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

            /*
             THEORY :

            Query1 => First i separately calculate the average salary of employee with the help of aggeragate function and then i simply compare each employee's salary with the average salary and filter the employee whoes salary is greater than average salary of the employee.

            Query2 => First i will calculate the highest salary of "HR" department with the help of join, grouping and filtering at last selection.

            join : use to access the deptname field.
            group : group by employee based on deptname and store the result into 'g'
            filtering(where) : here first i will filter the data based on department name and calculate the maximum salary for "HR" department using 'g'

            It will return the Enumerable collection so first i will fetch the integer value of the maximun salary form collection. and store it into a integer variable which is "HighestSalaryOfHRInt"

            Then i write simple query to fetch all the employee whoes salary is greater than maximum salary of "HR".             
             */

        }
        public static void ExecuteTask5(List<int> list1, List<int> list2)
        {
            var commonElement = list1.Intersect(list2);

            var OnlyPresentInList1 = list1.Except(list2);

            var presentInBothList = list1.Union(list2);

            Console.Write("Common elements: ");
            foreach (var item in commonElement) Console.Write($"{item}  ");
            Console.WriteLine("\n");

            Console.Write("Element present in list1 but not in list2: ");
            foreach (var item in OnlyPresentInList1) Console.Write($"{item}  ");
            Console.WriteLine("\n");

            Console.Write("Elements Present in both the lists");
            foreach (var item in presentInBothList) Console.Write($"{item}  ");
            Console.WriteLine("\n");

            /*
             THEORY:
            1)Intersect() => It will return common/shared element.It will return collection of elements that are present in both the collection It automatically handle duplicates and only return it once.

            2)Except => Return the difference. It will return the collection of element which are present in first collection and not present in second collection

            3)Union() => It will contains collection of all the element that are either present in first collection or present in second collection it will also include the common elements (It will remove duplicate entries)
             
             
             */
        }


        public static void Main()
        {
            Employee.AddEmployees();
            List<Employee> employees = Employee.employees;

            Department.AddDepartments();
            List<Department> departments = Department.departments;

            List<int> list1 = new List<int>() { 1,7,2,6,9,4,5};
            List<int> list2 = new List<int>() { 9,4,5,0,1,8,3};

            //ExecuteTask1(employees,departments);
            //ExecuteTask2(employees,departments);
            //ExecuteTask3(employees,departments);
            //ExecuteTask4(employees,departments);
            ExecuteTask5(list1, list2);
        }
    }
}
