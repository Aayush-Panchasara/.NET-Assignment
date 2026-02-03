using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Day1
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpAge { get; set; }
        public int EmpSalary { get; set; }
        public string Dname { get; set; }
        public string City { get; set; }
        public static List<Employee> employees;

        public Employee(int empId, string empName, int empAge, int empSalary, string dname, string city)
        {
            EmpId = empId;
            EmpName = empName;
            EmpAge = empAge;
            EmpSalary = empSalary;
            Dname = dname;
            City = city;
        }

        public static void AddEmployees()
        {
            employees = new List<Employee>() {
                new Employee(100,"Will",21,32000,"IT","ABC"),
                new Employee(101, "Dustin", 22, 28000, "HR","ABC"),
                new Employee(102, "Mike", 23, 26000, "M","PQR"),
                new Employee(103, "Eleven", 23, 31000, "IT","XYZ"),
                new Employee(104, "Lucas", 25, 21000, "IT","JKL"),
                new Employee(105, "Max", 24, 22000, "M","JKL")
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

        public OrderItem(string productName, int price)
        {
            ProductName = productName;
            Price = price;
        }
    }

    public class Order
    {
        public int OrderId { get; set;  }
        public string CustomerName {  get; set; }
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
        public static void AddOrders() {

            orders = new List<Order>()
            {
                new Order(1001,"Will",new List<OrderItem>() { new OrderItem("Bat",1000) ,new OrderItem("Ball",120),}),
                new Order(1002,"Max",new List<OrderItem>() { new OrderItem("Speaker",5000), new OrderItem("Shirt",500) }),
                new Order(1003,"Steve",new List<OrderItem>() { new OrderItem("Laptop", 100000), new OrderItem("Mouse",250) }),
                new Order(1004,"Nancy",new List<OrderItem>() { new OrderItem("Chair", 2500)}),
                new Order(1005,"Henry",new List<OrderItem>() { new OrderItem("Shoes", 1500), new OrderItem("Shirt",1100), new OrderItem("Jeans",1000)}),

            };

        }

    }
    class Utilities
    {
        
    }
}
