using EF_Core_Day1.Data;
using EF_Core_Day1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace EF_Core_Day1.CRUD_Operation
{
    internal class StudentCRUD
    {
        public void StartCRUDOperation()
        {
            using (var context = new AppContextDB())
            {

                bool flag = false;
                while (!flag)
                {
                    Console.WriteLine("What operations You have to perform On Student Table?");
                    Console.WriteLine("Press 1 For Insert");
                    Console.WriteLine("Press 2 For Update");
                    Console.WriteLine("Press 3 For Delete");
                    Console.WriteLine("Press 4 For Selection");


                    int operation = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        switch (operation)
                        {
                            case 1: AddStudent(context); break;
                            case 2: UpdateStudent(context); break;
                            case 3: DeleteStudent(context); break;
                            case 4: GetAllStudent(context); break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                    Console.Write("\nDo you Want to continue?(y/n): ");
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
        }

        public void AddStudent(AppContextDB context)
        {
            string Name, Email;
            Console.WriteLine("For Insertion:");
            Console.Write("Enter Student's FullName: ");
            Name = Console.ReadLine();

            Console.Write("Enter Student's Email: ");
            Email = Console.ReadLine();

            Student student = new Student() { Name = Name, Email = Email, CreatedDate = DateOnly.FromDateTime(DateTime.Now) };

            var result = context.Students.Add(student);
            var state = context.Entry(student).State;

            try
            {
                context.SaveChanges();
                Console.WriteLine("\nStudent Inserted Successfully\n");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Insertion Failed: {ex.Message}");
            }
        }

        public void UpdateStudent(AppContextDB context)
        {
            Console.WriteLine("For Updation");
            Console.WriteLine("Enter the ID of Student that You want to update : ");
            int Id = Convert.ToInt32(Console.ReadLine());

            var student = context.Students.Where(s => s.Id == Id).FirstOrDefault();
            if (student == null)
            {
                throw new Exception($"Student with ID {Id} does not exists");
            }

            Console.Write("Enter Student's New FullName: ");
            string NewName = Console.ReadLine();

            Console.Write("Enter Student's New FullName: ");
            string NewEmail = Console.ReadLine();


            //Console.WriteLine(student.Name);

            student.Name = NewName;
            student.Email = NewEmail;

            try
            {
                context.SaveChanges();
                Console.WriteLine("\nStudent Updated Successfully\n");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Updation Failed: {ex.Message}");
            }


        }

        public void DeleteStudent(AppContextDB context)
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
                context.SaveChanges();
                Console.WriteLine("\nStudent Deleted Successfully\n");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Deletion Failed: {ex.Message}");
            }
        }

        public void GetAllStudent(AppContextDB context)
        {
            var students = context.Students;
            Console.WriteLine("\nStudent List: \n");
            foreach (var student in students)
            {

                Console.WriteLine($"{{Id={student.Id} FullName={student.Name} Email={student.Email}}}");
            }
            Console.WriteLine();
        }
    }
}
