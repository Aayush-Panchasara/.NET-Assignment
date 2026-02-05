using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Net.Http.Headers;
using System.Text;
using System.Transactions;
using System.Xml.XPath;

namespace LINQ_Day3
{
    internal class Tasks_assignments
    {
        #region [Task 1]

        public static void ExecuteTask1(List<Employee> employees)
        {
            var resultMethod = employees.Where(emp => emp.EmpSalary > 30000)
                                        .Select(emp => new { Name = emp.EmpName, Salary = emp.EmpSalary });


            employees.Add(new Employee(106, "Steve", 50000, 3));

            Console.WriteLine("Query execution is not started yet.");



            Console.WriteLine("Employee's name whoes salary is greater that 30000");
            //Execution start here
            foreach (var item in resultMethod)
            {
                Console.WriteLine($"Name: {item.Name}, Salary: {item.Salary}");
            }

            /*
             Theory : 

            Here the execution type is deferred because it is default execution type, and we just write normal query. if we use a method calls like ToList(), ToArray(), also a methods that return a single valuse like aggeragate function also force to execute query immediately.
             */

        }
        #endregion

        #region [Task 2]

        public static void ExecuteTask2(List<Student> students)
        {
            
            var resultMethod = students.Where(std => std.Marks > 40)
                                       .Select(std => new { std.Name, std.Marks })
                                       .ToList();

            students[3].Marks = 80;

            var freshResult = students.Where(std => std.Marks > 40)
                                      .Select(std => new {std.Name, std.Marks})
                                      .ToList();

            Console.WriteLine("Student having marks greater than 40.");
            foreach (var item in resultMethod)
            {
                Console.WriteLine($"Student Name: {item.Name}, Marks: {item.Marks}");
            }
            Console.WriteLine();
            Console.WriteLine("Fresh result: Execute query after addition");
            foreach (var item in freshResult)
            {
                Console.WriteLine($"Student Name: {item.Name}, Marks: {item.Marks}");
            }


            /*
             Theory :
            Deferred execution => It will not execute query immediately, it will only execute query when you use the result (like printing the result). If you modify the data between query and iteration over the result then it will include the newly added data.

            Immediate execution =>It will execute query immediately, but we have to explictly mention by using a method like ToList(), ToDictionary(), etc.
            in immediate execution if you same as above then the result set will not contain the newly add data even if it follow the condition.
             
             
             */
        }

        #endregion

        #region [Task 3]

        public static void ExecuteTask3(List<Order> orders)
        {
            //Query 1 : All product name
            var resultMethod = orders.SelectMany(o => o.orderItems, (o, item) => item.ProductName);


            //Query 2
            var totalProductSold = (orders.SelectMany(o => o.orderItems,(o, item) => item.ProductName)).Count();


            Console.WriteLine($"Total Product Sold: {totalProductSold}");

            Console.WriteLine("All Product Name:");
            foreach (var item in resultMethod)
            {
                Console.WriteLine(item);
            }

            /*
             Theory : 

               Role of SelectMany() => Whenever you have a data in the form of collection inside a collection (like List<List<>>). then you can use selectmany to flattern the collection (from 2D to 1D)
            Here we have List<> of orders, it also have a field called orderItem and it is also a List<>. select many convert the list of list into a single list
             
             */

        }

        #endregion

        #region [Task 4]

         public static void ExecuteTask4(List<Employee> employees, List<Department> departments)
        {
            var resultMethod = departments.GroupJoin(
                                employees,
                                dept => dept.DepId,
                                emp => emp.DepartmentId,
                                (dept, empG) => new { DepartmentName = dept.DepName, Count = empG.Count() });


            Console.WriteLine("Department-wise employee count");
            foreach (var item in resultMethod)
            {
                Console.WriteLine($"DepartmentName:{item.DepartmentName}  Count:{item.Count}");
            }
            /*
             Throey : 
            Here the execution type is deffered. 
            GroupJoin is implemented using deferred execution, The query is not execute until you iterate over the result.

            Count() : Althought i use the count method and it is responsible for immediate execution, but only when called is direclty on a collection, Here it is a part of result set. 
             */
        }

        #endregion

        #region [Task 5]

        public static void ExecuteTask5(List<Employee> employees)
        {
            var resultEnumerable = employees
                                    .Where(
                                    emp => {
                                        Console.WriteLine("Printing inside Query");
                                        return emp.EmpSalary > 30000;
                                    })
                                    .Select(emp => new { emp.EmpName, emp.EmpSalary });
            Console.WriteLine("It is possible in case of Enumerable");

            //It is not possible to use printing statements will throw error like lambda expression with statement is not converted to a expression tree.

            //You can use printing statements inside Where() if you use it before the .AsQueryable()
            var resultQueryable = employees
                                    .AsQueryable()
                                    .Where(emp => emp.EmpSalary > 30000)
                                    .Select(emp => new { emp.EmpName, emp.EmpSalary });

            Console.WriteLine("Enumerable result");
            foreach (var item in resultEnumerable)
            {
                Console.WriteLine($"Name:{item.EmpName}, Salary:{item.EmpSalary}");
            }
            Console.WriteLine();
            Console.WriteLine("Queryable result");
            foreach (var item in resultQueryable)
            {
                Console.WriteLine($"Name:{item.EmpName}, Salary:{item.EmpSalary}");
            }

            /*
            Theory : 
            
            IEnumerable => Use to execute the query on the data that are present in the RAM.(in-memory collection).
                           Query execution is done by c# compiler.
                           For execution of the query the whole collection is loaded into RAM first and then the filtering is done.

            IQuerble => Use to execute the query on the data that are stored in the database (out-memory source).
                        Query execution is takes place by database engine.
                        Linq generate the expression tree from the query, Linq Provider will use the expression tree to generate the sql syntax for that query and then the execution is takes place.
                        And only filtered data is loaded into the RAM.
                           

             */


        }

        #endregion

        #region [Task 6]

        public static void ExecuteTask6(List<Employee> employees, List<Department> departments)
        {
            // Wrong way
            var resultNplusOne = employees.Select(emp => new
            {
                emp.EmpName,
                DepartmentName = (departments.Where(dept => dept.DepId == emp.DepartmentId)
                                                               .Select(dept => dept.DepName)
                                                               .First())
            });

            //Correct way
            var resultCorrectWay = employees.Join(
                                    departments,
                                    emp => emp.DepartmentId,
                                    dept => dept.DepId,
                                    (emp, dept) => new { emp.EmpName, dept.DepName });

            Console.WriteLine("Wrong Way:");
            foreach (var item in resultNplusOne)
            {
                Console.WriteLine($"EmployeeName: {item.EmpName}, DepartmentName: {item.DepartmentName}");
            }

            Console.WriteLine();
            Console.WriteLine("Correct Way:");
            foreach (var item in resultCorrectWay)
            {
                Console.WriteLine($"EmployeeName: {item.EmpName}, DepartmentName: {item.DepName}");
            }

            /*
             theory :
            N+1 Problem => The first query is an example of N+1 query problem. In that first i will fetch list of employee name and then in second part a loop is run for each employee to and fetch the department name. Althought the whole task is done in single query instead we use 1+N(inorder to fetch department name for each employee).

            Correct way => It will combine both the collection in a single collection and then return the data in one query.
             */


        }
        #endregion

        #region [Task 7]

        public static void ExecuteTask7(List<OrderItem> products)
        {
            var countBefore = products.Count();

            var resultMethod = (products.Select(p => p.ProductName)).Distinct();

            var countAfter = resultMethod.Count();

            Console.WriteLine($"Count before: {countBefore}\n");

            Console.WriteLine("List of unique product");
            foreach (var item in resultMethod)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"\nCount after: {countAfter}");



            /*
             Theory:
            Distinct() => It will remove duplicate value from the collection.
            Here i want unique product name, Distince() remove the duplicate product from list of products. 

             */
        }
        #endregion

        #region [Task 8]

        public static void ExecuteTask8(List<Employee> employees)
        {
            var resultMethod = employees.ToDictionary(emp => emp.EmpId, emp => emp.EmpName);

           
            Console.WriteLine(resultMethod.GetType());
            Console.WriteLine("Printing dictionary: ");
            foreach (var item in resultMethod)
            {
                Console.WriteLine(item);
            }


            /*
             theory :
            
            Dictionary stored the data in key-value pair and key must be unique, it does not allow duplicate keys
            In order to create a dictionary it will process entire collection at that moment. 
            Another reason is that it will require all the element to be present inorder to check for the unique keys, in deferred execution you can update the data before the iterate over the result (means before the query execution) then it is not possible for dictionary to check for unique keys.

             */
        }

        #endregion

        #region [Task 9]

        public static void ExecuteTask9(List<Employee> employees, List<Department> departments)
        {
            var resultMethod = departments.Join(
                                  employees,
                                  dept => dept.DepId,
                                  emp => emp.DepartmentId,
                                  (dept, emp) => new { EmployeeName = emp.EmpName, DepartmentName = dept.DepName })
                                   .Where(x => x.DepartmentName == "IT")
                                   .Select(x => x.EmployeeName);

           

            Console.WriteLine("List of employee whose department is IT :");
            foreach (var item in resultMethod)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Print second time :");
            foreach (var item in resultMethod)
            {
                Console.WriteLine(item);
            }

            employees[0].DepartmentId = 3;

            Console.WriteLine();
            Console.WriteLine("Print after addition");
            foreach (var item in resultMethod)
            {
                Console.WriteLine(item);
            }
            /*
             Theory : 

            For first foreach loop it will execute the query and strored the result in the variable, and when you print the second time then also it will execute the query and return the result.

            Before printing the result again you will modify the data and then you print 3rd time, so because of deferred execution query process on modified data and the result is different from prevoius two.

             */

        }

        #endregion

        #region [Task 10]

        /*
         THEORY:
        LINQ best practice ensures that the written query is readable, effecient for both In-memory collections(which is LINQ to object) and databased (which is LINQ to sql/Entities).

        1)When to use ToList() => By default the execution type is deferred in which it will not execute query immediately it will only execute the query when you iterate over the result.
        If you want immediate execution then we use ToList() (It is not only one method with that we can achieve the immediate execution) it will force the query to run immediately.

        2)Avoid multiple enumeration => Linq query use deferred execution, query is not execute until the we want to use the result. So if you use the result multiple time then each time the query gets executed. which is impact the performance.

        3)Use Any() instead of Count() > 0 => If you want to find the existance of any element in your collection/database tables then Any() is far better than Count() > 0, because with Any() it will stop execution when it first time find the element, while Count() traverse the entire collection and then check the condition.

        4)Avoid loops if LINQ is possible => Avoiding loops and use linq increases the code readability, for small operation loops perform well as compare to linq.

        5)N+1 query problem => It is like if you have to fetch the data, It is possible to fetch the data in a single query instead the query written by you is perform N+1 query inorder to fetch the same result.

        In Task 6 i will demonstrate the N+1 problem example and solution of that problem.


         */
        #endregion
        public static void Main()
        {
            Employee.AddEmployees();
            List<Employee> employees = Employee.employees;

            Order.AddOrders();
            List<Order> orders = Order.orders;

            Student.AddStudents();
            List<Student> students = Student.students;

            Department.AddDepartments();
            List<Department> departments = Department.departments;

            OrderItem.AddProducts();
            List<OrderItem> products = OrderItem.products;


            //ExecuteTask1(employees);
            //ExecuteTask2(students);
            //ExecuteTask3(orders);
            //ExecuteTask4(employees, departments);
            ExecuteTask5(employees);
            //ExecuteTask6(employees, departments);
            //ExecuteTask7(products);
            //ExecuteTask8(employees);
            //ExecuteTask9(employees, departments);

        }

    }
}
