using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Day3
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

    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }

        public static List<Student> students;

        public Student(int rollno, string name, int marks)
        {
            RollNo = rollno;
            Name = name;
            Marks = marks;
        }

        public static void AddStudents()
        {
            students = new List<Student>()
            {
                new Student(201,"Will",95),
                new Student(202,"Mike",85),
                new Student(203,"Dustin",55),
                new Student(204,"Eleven",35),
                new Student(205,"Lukas",39),
                new Student(206,"Max",50)
            };
        }
    }

    public class OrderItem
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public static List<OrderItem> products;

        public OrderItem(string productName, int price)
        {
            ProductName = productName;
            Price = price;
        }

        public static void AddProducts()
        {
            products = new List<OrderItem>() {
                new OrderItem("Bat",1000),
                new OrderItem("Ball",120),
                new OrderItem("Speaker",5000), 
                new OrderItem("Shirt",500),
                new OrderItem("Speaker",5000),
                new OrderItem("Laptop", 100000), 
                new OrderItem("Mouse",250),
                new OrderItem("Shoes", 1500), 
                new OrderItem("Shirt",1100), 
                new OrderItem("Jeans",1000)
            };
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public List<OrderItem> orderItems { get; set; } = new List<OrderItem>();

        public static List<Order> orders;

        public Order(int orderId, string customerName, List<OrderItem> item)
        {
            OrderId = orderId;
            CustomerName = customerName;
            orderItems = item;
        }
        public void AddOrderItem()
        {

        }
        public static void AddOrders()
        {

            orders = new List<Order>()
            {
                new Order(1001,"Will",new List<OrderItem>() { new OrderItem("Bat",1000) ,new OrderItem("Ball",120),}),
                new Order(1002,"Max",new List<OrderItem>() { new OrderItem("Speaker",5000), new OrderItem("Shirt",500) }),
                new Order(1003,"Steve",new List<OrderItem>() { new OrderItem("Laptop", 100000), new OrderItem("Mouse",250) }),
                new Order(1004,"Nancy",new List<OrderItem>() { new OrderItem("Chair", 2500),new OrderItem("Laptop", 100000)}),
                new Order(1005,"Henry",new List<OrderItem>() { new OrderItem("Shoes", 1500), new OrderItem("Shirt",1100), new OrderItem("Jeans",1000)}),

            };

        }

    }
    internal class Utilities
    {
    }
}
