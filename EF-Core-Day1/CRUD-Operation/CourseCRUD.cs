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
        AppContextDB context;

        public CourseCRUD(AppContextDB context)
        {
            this.context = context;
        }

        public void StartCRUDOperation()
        {
            bool flag = false;
            while (!flag)
            {
                Console.WriteLine("What operations You want to perform On Course Table?");
                Console.WriteLine("Press 1 For Insert");
                Console.WriteLine("Press 2 For Update");
                Console.WriteLine("Press 3 For Delete");
                Console.WriteLine("Press 4 For Selection");
                Console.WriteLine("Press 5 To show Course With Student(Eagar Loading)");
                       

                int operation = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (operation)
                {
                    case 1: AddCourse(); break;
                    case 2: UpdateCourse(); break;
                    case 3: DeleteCourse(); break;
                    case 4: GetAllCourse(); break;
                    case 5: CourseWithStudent();break;
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

                Console.Write("\nDo you Want to continue CourseCRUD?(y/n): ");
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
           
       
        public void AddCourse()
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
                var state = context.Entry(course).State;
                Console.WriteLine($"State before: {state}");
                context.SaveChanges();
                state = context.Entry(course).State;
                Console.WriteLine($"State after: {state}");
                Console.WriteLine("\nCourse Inserted Successfully\n");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Insertion Failed: {ex.Message}");
            }
        }

        public void UpdateCourse()
        {
            Console.WriteLine("For Updation");
            Console.WriteLine("Enter the ID of Course that You want to update : ");
            int Id = Convert.ToInt32(Console.ReadLine());

            var course = context.Courses.Where(c => c.CourseId == Id).FirstOrDefault();
            if (course == null)
            {
                throw new Exception($"Course with ID {Id} does not exists");
            }

            Console.WriteLine("What fields Do yo want to update?");
            Console.WriteLine("Press 1 for Title");
            Console.WriteLine("Press 2 for Price");
            Console.WriteLine("Press 3 for Duration");
            Console.WriteLine("Press 4 for All Fields");

            int option = Convert.ToInt32(Console.ReadLine());


            switch (option)
            {
                case 1:
                    Console.Write("Enter Course New Title: ");
                    string NewTitle = Console.ReadLine();
                    course.Title = NewTitle;
                    break;
                case 2:
                    Console.Write("Enter Course New Price: ");
                    int NewPrice = Convert.ToInt32(Console.ReadLine());
                    course.Fees = NewPrice;
                    break;
                case 3:
                    Console.Write("Enter Course New Duration: ");
                    int NewDuration = Convert.ToInt32(Console.ReadLine());
                    course.DurationInMonths = NewDuration;
                    break;
                case 4:
                    Console.Write("Enter Course New Title: ");
                    string NewTitle1 = Console.ReadLine();

                    Console.Write("Enter Course New Fees: ");
                    int NewPrice1 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Course New Duration: ");
                    int NewDuration1 = Convert.ToInt32(Console.ReadLine());

                    course.Title = NewTitle1;
                    course.Fees = NewPrice1;
                    course.DurationInMonths = NewDuration1;
                    break;
            }

            try
            {
                var state = context.Entry(course).State;
                Console.WriteLine($"State before: {state}");
                context.SaveChanges();
                state = context.Entry(course).State;
                Console.WriteLine($"State after: {state}");
                Console.WriteLine("\nCourse Updated Successfully\n");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Updation Failed: {ex.Message}");
            }
        }

        public void DeleteCourse()
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
                var state = context.Entry(course).State;
                Console.WriteLine($"State before: {state}");
                context.SaveChanges();
                state = context.Entry(course).State;
                Console.WriteLine($"State after: {state}");
                Console.WriteLine("\nCourse Deleted Successfully\n");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Deletion Failed: {ex.Message}");
            }
        }

        public void GetAllCourse()
        {
            var courses = context.Courses;
            Console.WriteLine("\nCourse List: \n");
            foreach (var course in courses)
            {

                Console.WriteLine($"{{Id={course.CourseId}, Title={course.Title}, Price={course.Fees}, Duration={course.DurationInMonths}}}");
            }
            Console.WriteLine();
        }

        public void CourseWithStudent()
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

        public void StudentWithSpecificCourse()
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
