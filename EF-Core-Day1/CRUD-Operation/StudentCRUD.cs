using EF_Core_Day1.Data;
using EF_Core_Day1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Channels;

namespace EF_Core_Day1.CRUD_Operation
{
    internal class StudentCRUD
    {
        AppContextDB context;
        public StudentCRUD(AppContextDB context)
        {
            this.context = context;
        }
        public void StartCRUDOperation()
        {

                bool flag = false;
                while (!flag)
                {
                    Console.WriteLine("What operations You want to perform On Student Table?");
                    Console.WriteLine("Press 1 For Insert");
                    Console.WriteLine("Press 2 For Update");
                    Console.WriteLine("Press 3 For Delete");
                    Console.WriteLine("Press 4 For Selection");


                    int operation = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        switch (operation)
                        {
                            case 1: AddStudent(); break;
                            case 2: UpdateStudent(); break;
                            case 3: DeleteStudent(); break;
                            case 4: GetAllStudent(); break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                    Console.Write("\nDo you Want to continue StudentCRUD?(y/n): ");
                    char option = Convert.ToChar(Console.ReadLine());

                    if (option == 'n')
                    {
                        flag = true;
                    }
                    else if (option == 'y')
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input Operation Stops");
                        break;
                    }
                }
            
        }

        public void AddStudent()
        {
            string Name, Email;
            Console.WriteLine("For Insertion:");
            Console.Write("Enter Student's FullName: ");
            Name = Console.ReadLine();

            Console.Write("Enter Student's Email: ");
            Email = Console.ReadLine();

            Student student = new Student() { Name = Name, Email = Email, CreatedDate = DateOnly.FromDateTime(DateTime.Now) };

            var result = context.Students.Add(student);
          

            try
            {
                var state = context.Entry(student).State;
                Console.WriteLine($"State before: {state}");
                context.SaveChanges();
                state = context.Entry(student).State;
                Console.WriteLine($"State after: {state}");
                Console.WriteLine("\nStudent Inserted Successfully\n");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Insertion Failed: {ex.Message}");
            }
        }

        public void UpdateStudent()
        {
            Console.WriteLine("For Updation");
            Console.WriteLine("Enter the ID of Student that You want to update : ");
            int Id = Convert.ToInt32(Console.ReadLine());

            var student = context.Students.Where(s => s.Id == Id).FirstOrDefault();
            if (student == null)
            {
                throw new Exception($"Student with ID {Id} does not exists");
            }

            Console.WriteLine("What fields Do yo want to update?");
            Console.WriteLine("Press 1 for Name");
            Console.WriteLine("Press 2 for Email");
            Console.WriteLine("Press 3 for Name & Email");

            int option = Convert.ToInt32(Console.ReadLine());


            switch (option)
            {
                case 1: 
                    Console.Write("Enter Student's New FullName: ");
                    string NewName = Console.ReadLine();
                    student.Name = NewName;
                    break;
                case 2:
                    Console.Write("Enter Student's New Email: ");
                    string NewEmail = Console.ReadLine();
                    student.Email = NewEmail;
                    break;
                case 3:
                    Console.Write("Enter Student's New FullName: ");
                    string NewName1 = Console.ReadLine();

                    Console.Write("Enter Student's New Email: ");
                    string NewEmail2 = Console.ReadLine();
                    student.Name = NewName1;
                    student.Email = NewEmail2;
                    break;
            }

            try
            {
                var state = context.Entry(student).State;
                Console.WriteLine($"State before: {state}");
                context.SaveChanges();
                state = context.Entry(student).State;
                Console.WriteLine($"State after: {state}");
                Console.WriteLine("\nStudent Updated Successfully\n");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Updation Failed: {ex.Message}");
            }


        }

        public void DeleteStudent()
        {
            Console.WriteLine("For Deletion: ");
            Console.WriteLine("Enter the ID of Student that You want to Delete : ");
            int Id = Convert.ToInt32(Console.ReadLine());

            var student = context.Students.Where(s => s.Id == Id).FirstOrDefault();
            if (student == null)
            {
                throw new Exception($"Student with ID {Id} does not exists");
            }

            context.Students.Remove(student);

            try
            {
                var state = context.Entry(student).State;
                Console.WriteLine($"State before: {state}");
                context.SaveChanges();
                state = context.Entry(student).State;
                Console.WriteLine($"State after: {state}");
                Console.WriteLine("\nStudent Deleted Successfully\n");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Deletion Failed: {ex.Message}");
            }
        }

        public void GetAllStudent()
        {
            var students = context.Students;
            Console.WriteLine("\nStudent List: \n");
            foreach (var student in students)
            {

                Console.WriteLine($"{{Id={student.Id} FullName={student.Name} Email={student.Email}}}");
            }
            Console.WriteLine();
        }

        public void EnrollStudentInCourse()
        {
            Console.WriteLine("For Student Enrollment");
            Console.Write("Enter the student name you want to enroll : ");
            string StName = Console.ReadLine();

            Console.Write("Enter the course name in which you want to enroll : ");
            string CoName = Console.ReadLine();

            var student = context.Students.Where(s => s.Name == StName).FirstOrDefault();
            var course = context.Courses.Where(c => c.Title == CoName).FirstOrDefault();

            if(course != null && student != null)
            {
                student.Courses.Add(course);
            }else if (course == null)
            {
                throw new Exception($"{CoName} course does not exists.");
            }
            else
            {
                throw new Exception($"Student with name {StName} does not exists.");
            }


            try
            {
                var state = context.Entry(student).State;
                Console.WriteLine($"State before: {state}");
                context.SaveChanges();
                state = context.Entry(student).State;
                Console.WriteLine($"State after: {state}");
                Console.WriteLine($"Student with name {StName}, Successfully enrolled in {CoName} course.");
            }catch(Exception ex)
            {
                Console.WriteLine($"Enrollment Failed: {ex.Message}");
            }

        }
        
       
    }
}
