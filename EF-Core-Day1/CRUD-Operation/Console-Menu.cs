using EF_Core_Day1.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_Day1.CRUD_Operation
{
    internal class Console_Menu
    {
       
        public void StartConsoleMenu(AppContextDB context)
        {

            StudentCRUD stCRUD = new StudentCRUD();
            CourseCRUD coCRUD = new CourseCRUD();
            bool flag = false;
            while (!flag) 
            {
                Console.WriteLine("What operations You have to perform On Course Table?");
                Console.WriteLine("Press 1 For ADD Student");
                Console.WriteLine("Press 2 For ADD Course");
                Console.WriteLine("Press 3 For Show All Students");
                Console.WriteLine("Press 4 For Show All Courses");

                int operation = Convert.ToInt32(Console.ReadLine());
                try
                {
                    switch (operation)
                    {
                        case 1: stCRUD.AddStudent(context); break;
                        case 2: coCRUD.AddCourse(context); break;
                        case 3: stCRUD.GetAllStudent(context); break;
                        case 4: coCRUD.GetAllCourse(context); break;
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
}
