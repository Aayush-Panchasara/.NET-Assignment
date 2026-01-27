using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Day1
{
    public partial class Student
    {
        public int Id;
        public int Standard;
        public string SchoolName;
        public string Location;

        public Student(string name, int age, string fatherName, int id, int standard, string schoolName, string location)
        {
            Name = name;
            Age = age;
            FatherName = fatherName;
            Id = id;
            Standard = standard;
            SchoolName = schoolName;
            Location = location;
        }

        public void DisplayCompleteInfo()
        {
            Console.WriteLine("Student Info");
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Father Name: {FatherName}");
            Console.WriteLine($"Standard: {Standard}th");
            Console.WriteLine($"School Name: {SchoolName}");
            Console.WriteLine($"Location: {Location}");
        }
    }
    internal class PartialClass_Academic_Info
    {
        public static void Main()
        {
            Student s1 = new Student("Aayush Panchasara", 21, "Ashokbhai Panchasara", 002, 12, "Jawahar Navodaya Vidyalaya","Dhrangadhra");

            s1.DisplayCompleteInfo();
        }
    }
}
