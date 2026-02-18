using EF_Core_Day1.Data;
using EF_Core_Day1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_Day1.CRUD_Operation
{
    internal class CourseCRUD
    {
        public void StartCRUDOperation()
        {
                using (var context = new AppContextDB())
                {

                    bool flag = false;
                    while (!flag)
                    {
                        Console.WriteLine("What operations You want to perform On Course Table?");
                        Console.WriteLine("Press 1 For Insert");
                        Console.WriteLine("Press 2 For Update");
                        Console.WriteLine("Press 3 For Delete");
                        Console.WriteLine("Press 4 For Selection");
                       

                        int operation = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        switch (operation)
                        {
                            case 1: AddCourse(context); break;
                            case 2: UpdateCourse(context); break;
                            case 3: DeleteCourse(context); break;
                            case 4: GetAllCourse(context); break;
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
           
        

        public void AddCourse(AppContextDB context)
        {
            string Title;
            int Fees,Duration;
            Console.WriteLine("For Insertion:");
            Console.Write("Enter Course Title: ");
            Title = Console.ReadLine();

            Console.Write("Enter Course Price: ");
            Fees = Convert.ToInt32(Console.ReadLine());

            Console.Write("Total Duration(In Months): ");
            Duration = Convert.ToInt32(Console.ReadLine());

            Course course = new Course() { Title=Title, Fees=Fees, DurationInMonths=Duration};

            var result = context.Courses.Add(course);


            try
            {
                context.SaveChanges();
                Console.WriteLine("\nCourse Inserted Successfully\n");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Insertion Failed: {ex.Message}");
            }
        }

        public void UpdateCourse(AppContextDB context)
        {
            Console.WriteLine("For Updation");
            Console.WriteLine("Enter the ID of Course that You want to update : ");
            int Id = Convert.ToInt32(Console.ReadLine());

            var course = context.Courses.Where(c => c.CourseId == Id).FirstOrDefault();
            if (course == null)
            {
                throw new Exception($"Course with ID {Id} does not exists");
            }

            Console.Write("Enter Course's New Title: ");
            string NewTitle = Console.ReadLine();

            Console.Write("Enter Course's New Fees: ");
            int NewPrice = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Course's New Duration: ");
            int NewDuration = Convert.ToInt32(Console.ReadLine());


            course.Title = NewTitle;
            course.Fees = NewPrice;
            course.DurationInMonths = NewDuration;

            try
            {
                context.SaveChanges();
                Console.WriteLine("\nCourse Updated Successfully\n");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Updation Failed: {ex.Message}");
            }
        }

        public void DeleteCourse(AppContextDB context)
        {
            Console.WriteLine("For Deletion: ");
            Console.WriteLine("Enter the ID of Course that You want to Delete : ");
            int Id = Convert.ToInt32(Console.ReadLine());

            var course = context.Courses.Where(c => c.CourseId == Id).FirstOrDefault();
            if (course == null)
            {
                throw new Exception($"Student with ID {Id} does not exists");
            }

            context.Courses.Remove(course);

            try
            {
                context.SaveChanges();
                Console.WriteLine("\nCourse Deleted Successfully\n");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Deletion Failed: {ex.Message}");
            }
        }

        public void GetAllCourse(AppContextDB context)
        {
            var courses = context.Courses;
            Console.WriteLine("\nCourse List: \n");
            foreach (var course in courses)
            {

                Console.WriteLine($"{{Id={course.CourseId}, Title={course.Title}, Price={course.Fees}, Duration={course.DurationInMonths}}}");
            }
            Console.WriteLine();
        }

        public void CourseWithStudent(AppContextDB context)
        {
            var course = context.Courses
                                 .Include(c => c.Students)
                                 .ToList();

            foreach (var item in course)
            {
                Console.WriteLine($"\nCourse: {item.Title}");
                if(item.Students.Count != 0)
                {
                    foreach (var item1 in item.Students)
                    {
                        Console.WriteLine($"\tStudent: {item1.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("\tNo Student");
                }
            }

        }

        public void StudentWithSpecificCourse(AppContextDB context)
        {
            Console.Write("Enter the Course name: ");
            string title = Console.ReadLine();

            var course = context.Courses
                                 .Where(t => t.Title == title)
                                 .Include(t => t.Students)
                                 .ToList();
            if (course.Count == 0)
            {
                Console.WriteLine($"{title} course does not exists.");
            }

            foreach (var item in course)
            {
                Console.WriteLine($"\nCourse: {title}");
                if (item.Students.Count != 0)
                {
                    foreach (var item1 in item.Students)
                    {
                        Console.WriteLine($"\tStudent: {item1.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("\tNo student");
                }
            }
        }

    }
}
