using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Day_3
{
    public class Student
    {
        public int Id;
        public string Name;
        public int Age;
        public Student(int id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }
    }

    public class UsingArray
    {
        public Student[] student;
        public int count;

        public UsingArray(int size)
        {
            student = new Student[size];
            count = 0;
        }

        public void Add(int id, string name, int age)
        {
            if(count < student.Length)
            {
                student[count] = new Student(id, name, age);
                count++;
                Console.WriteLine($"Added: {{Id:{id} Name:{name} Age:{age}}}");
            }
            else
            {
                Console.WriteLine("Array is full");
            }
        }

        public void Search(int id)
        {
            bool b = false;
            for (int i = 0; i < count; i++)
            {
                if (student[i].Id == id)
                {
                    Console.WriteLine($"Found: {{Id:{id}}}");
                    b = true;
                    break;
                }
            }
            if(!b)
            {
                Console.WriteLine("Student not found");
            }
        }
        public void Update(int id, string newName, int newAge)
        {
            bool b = false;
            for (int i = 0; i < count; i++)
            {
                if (student[i].Id == id)
                {
                    student[i].Name = newName;
                    student[i].Age = newAge;
                    Console.WriteLine($"Updated: {{Id:{id} Name:{student[i].Name} Age:{student[i].Age}}}");
                    b = true;
                    break;
                }
            }
            if (!b)
            {
                Console.WriteLine("Student not found");
            }
        }

    }

    public class UsingList
    {
        List<Student> students = new List<Student>();

        public void Add(int id, string name, int age)
        {
            students.Add(new Student(id, name, age));
            Console.WriteLine($"Added: {{Id:{id} Name:{name} Age:{age}}}");
        }

        public void Search(int id)
        {
            bool b = false;
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id)
                {
                    Console.WriteLine($"Found: {{Id:{id}}}");
                    b = true;
                    break;
                }
            }
            if(!b)
            {
                Console.WriteLine("Student not found");
            }
        }
        public void Update(int id, string newName, int newAge)
        {
            bool b = false;
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id)
                {
                    students[i].Name = newName;
                    students[i].Age = newAge;
                    Console.WriteLine($"Updated: {{Id:{id} Name:{students[i].Name} Age:{students[i].Age}}}");
                    b = true;
                    break;
                }
            }
            if (!b)
            {
                Console.WriteLine("Student not found");
            }
        }

    }

    public class UsingDictionary
    {
        Dictionary<int, Student> students = new Dictionary<int, Student>();

        public void Add(int id, string name, int age)
        {
            if (!students.ContainsKey(id))
            {
                students.Add(id, new Student(id, name, age));
                Console.WriteLine($"Added: {{Id:{id} Name:{name} Age:{age}}} ");
            }
            else
            {
                Console.WriteLine($"{id} already exist");
            }
        }

        public void Search(int id)
        {
            if (students.ContainsKey(id))
            {
                Console.WriteLine($"Found: {{Id:{id}}}");
            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }

        public void Update(int id, string newName, int newAge)
        {
            if (students.ContainsKey(id))
            {
                students[id].Name = newName;
                students[id].Age = newAge;
                Console.WriteLine($"Updated: {{Id:{id} Name:{students[id].Name} Age:{students[id].Age}}}");
            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }
    }
    class Array_Ass1
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Using Array:");
            UsingArray ar = new UsingArray(5);

            ar.Add(100, "Aayush", 21);
            ar.Add(101, "Piyush", 22);

            ar.Search(101);

            ar.Update(100, "Aayush Panchasara", 22);
            ar.Search(100);

            Console.WriteLine();

            Console.WriteLine("Using List:");
            UsingList lr = new UsingList();

            lr.Add(100, "Yash", 20);
            lr.Add(101, "Rohit", 22);

            lr.Search(101);

            lr.Update(100, "Yash P", 22);
            lr.Search(100);

            Console.WriteLine();

             Console.WriteLine("Using Dictionary:");
            UsingDictionary dr = new UsingDictionary();

            dr.Add(100, "Mahesh", 40);
            dr.Add(101, "Vinod", 35);

            dr.Search(101);

            dr.Update(100, "Mahesh Panchasara", 42);
            dr.Search(100);


        }
    }
}
