using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Day1
{
    class Tasks_assignement
    {
        public static void Task1(List<Employee> employees)
        {
            var resultTask1 = employees
                              .Where(emp => emp.EmpSalary > 25000)
                              .Select(emp => emp);


            Console.WriteLine("Task 1: All employee whose salary is greater than 25000");
            foreach (var item in resultTask1)
            {
                Console.WriteLine($"EmployeeID: {item.EmpId}, EmployeeName: {item.EmpName}, Salary: {item.EmpSalary}");
            }

            /*
             THEORY : 
            1)Where() => Where clause is used to perform filtering based on some condition and it will return only those columns, datafields that follow the condition.
                
            Here where clause find all the employee whose salary is greater than 25000

            2)Select() => Select clause is use for projection means to select from the database tables, collection etc. It is use to select either single or multiple fields based on requirements.
             
            Here selece clause return the employee whose salary is greater that 25000           
             */



        }
        public static void Task2(List<Employee> employees) {

            var resultTask2 = employees
                              .Where(emp => emp.Dname == "IT")
                              .Select(emp => new { emp.EmpName, emp.EmpSalary });

            Console.WriteLine("Task 2: Employee having department as IT");
            foreach (var item in resultTask2)
            {
                Console.WriteLine($"EmployeeName: {item.EmpName}, Salary: {item.EmpSalary}");
            }

            /*
            
             THEORY : 
            1)Where() =>  Here where clause find all the employee whose department is 'IT'.

            2)Select() => Here select clause return the employee name and salary whoes department is 'IT'.            
             */


            
        }
        public static void Task3(List<Employee> employees) {

            var resultTask3 = employees
                                 .Where(emp => emp.EmpSalary > 30000)
                                 .OrderBy(emp => emp.EmpSalary)
                                 .Select(emp => emp);

            Console.WriteLine("Task 3: All employee whose salary is greater than 30000");
            foreach (var item in resultTask3)
            {
                Console.WriteLine($"EmployeeID: {item.EmpId}, EmployeeName: {item.EmpName}, Salary: {item.EmpSalary}");
            }

            /*
            
             THEORY : 
            1)Where() =>  Here where clause find all the employee whose salary is greater than 30000.

            2)OrderBy() => Orderby clause is use to sort the based on some columns/fields, it also support sorting based on more than one field.

            First it will sort based on first field which is mention in the where clause and if it is unable to distanguish between some data then it will sort that data based on second filed.

            2)Select() => Here select clause return the employee whoes salary is greater than 30000.
             */



        }
        public static void Task4(List<Employee> employees) {

            var resultTask4 = employees
                                  .OrderBy(emp => emp.Dname)
                                  .ThenBy(emp => emp.EmpName)
                                  .Select(emp => emp);

            Console.WriteLine("Task 4: List of employees sorted based on Department and further by Employee name");
            foreach (var item in resultTask4)
            {
                Console.WriteLine($"EmployeeID: {item.EmpId}, EmployeeName: {item.EmpName}, Department: {item.Dname}");
            }

            /*
            
             THEORY : 
            1)OrderBy() =>  Sort the employee based on department name.


            2)ThenBy() => If some department name is same then it will sort those by employee name which is mention in the ThenBy() clause.

            2)Select() => It will retun the list of employees.            
             */

        }
        public static void Task5(List<Student> students) {

            var resultTask5 = students
                              .Select(std => new { std.Name, std.Marks, Result = std.Marks > 40 ? "Pass" : "Fail" });

            Console.WriteLine("Task 5: List of students including result field");
            foreach (var item in resultTask5)
            {
                Console.WriteLine($"Name: {item.Name}, Marks: {item.Marks}, Result: {item.Result}");
            }

            /*
            
             THEORY : 
            
            1)Select() => Here we return multiple fields and we create a new field result based on marks it contain either PASS or FAIL value.
            
            I use the select clause to select some existing fields and also able to create a new field based on some condition.
             */


        }
        public static void Task6(List<Employee> employees) {

            var resultTask6 = employees
                              .Select(emp => new { emp.EmpName, emp.Dname, emp.City });

            Console.WriteLine("Task 6: List of all the employees");
            foreach (var item in resultTask6)
            {
                Console.WriteLine($"EmployeeName: {item.EmpName}, Department: {item.Dname}, City: {item.City}");
            }

            /*
            
             THEORY : 
            Anonymous type is used to encapsulate a set of reaad-only properties into single, Anonymous return a temporary object without explicitely define a class.
            
            The actual type/class name is generated by the compiler internally which is not accessible at source level.
             */
        }
        public static void Task7(List<Order> orders) {

            var resultTask7 = orders
                          .SelectMany(o => o.orderItems)
                          .Select(item => item.ProductName);

            Console.WriteLine("Task 7: List of order items");
            foreach (var item in resultTask7)
            {
                Console.WriteLine($"Items: {item}");
            }

            /*
             Theory : 

            1) SelectMany =>  selectmany is same as select clause the difference is that it flattens the result into a single list, that makes easy to works with inner elements.

            Here i have order class and it contain a list of orderItems so to flattens the orderItems i use the selectMany clause which only flattern to one level. for further flattring we can use multiple selectMany clauses.
             */
        }
        public static void Task8(List<Order> orders) {

            var resultTask8 = orders
                              .Select(o => new { o.CustomerName, ProductName = o.orderItems.Select(item => item.ProductName) });

            Console.WriteLine("Task 8: List of customer with their productname");
            foreach (var item in resultTask8)
            {
                foreach (var item1 in item.ProductName)
                {

                    Console.WriteLine($"Customer: {item.CustomerName}, ProductName: {item1}");
                }
            }

            /*
            Here i use multiple/nested select clause for achieve the result.

             */

        }
        public static void Task9(List<Employee> employees) {

            var resultTask9 = employees
                           .Select(emp => emp.EmpName)
                           .ToList();

            Console.WriteLine("Task 9: List of all Employee");
            foreach (var item in resultTask9)
            {
                Console.WriteLine($"Items: {item}");
            }

            /*
             ToList => It will convert the result into a generic list of employee name. That is want i wanted to convert the result into the collection.
             
             */
        }
        public static void Task10(List<Employee> employees) {

            //Using Methods Syntax   
            var resultTask10M = employees
                              .Where(emp => emp.EmpSalary > 25000)
                              .Select(emp => emp);

            //Using Query syntax
            var resultTask10Q = from emp in employees
                                where emp.EmpSalary > 25000
                                select emp;


            Console.WriteLine("Task 10: Query using method syntax");
            foreach (var item in resultTask10M)
            {
                Console.WriteLine($"EmployeeName: {item.EmpName}");
            }

            Console.WriteLine("Task 10: Query using Query syntax");
            foreach (var item in resultTask10Q)
            {
                Console.WriteLine($"EmployeeName: {item.EmpName}");
            }

            /*
             Here i write to same query in two different syntax, techanically both are same.

            Working : C# compiler doesn't have the defination for the keyworks used in the query inorder to execute the query first it will convert query syntax into method syntax (keywords to methods calls) and execute the query. 
            
            Their is zero impact on performance if you write any syntax.

            Query syntax is introduce for developer's ease, means if developer have knowledge about SQL then it finds easy to write query syntax.
             
             */


        }
        public static void Main()
        {
            Employee.AddEmployees();
            List<Employee> employees = Employee.employees;

            Student.AddStudents();
            List<Student> students = Student.students;

            Order.AddOrders();
            List<Order> orders = Order.orders;

            //Task 1 -----
            //Task1(employees);

            //Task 2 ------
            //Task2(employees);

            //Task 3 ------
            //Task3(employees);

            //Task 4 ------
            //Task4(employees);

            //Task 5 ------
            //Task5(students);

            //Task 6 ------
            //Task6(employees);

            //Task 7 ------
            //Task7(orders);

            //Task 8 ------
            //Task8(orders);

            //Task 9 ------
            Task9(employees);

            //Task 10 ------
            //Task10(employees);





        }
    }
}
