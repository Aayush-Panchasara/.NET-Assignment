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

            StudentCRUD studentCRUD = new StudentCRUD();
            CourseCRUD courseCRUD = new CourseCRUD();
            BatchCRUD batchCRUD = new BatchCRUD();
            TrainerCRUD trainerCRUD = new TrainerCRUD();
            bool flag = false;
            while (!flag) 
            {
                Console.WriteLine("What operations You want to perform?");
                Console.WriteLine("Press 1 For ADD Student");
                Console.WriteLine("Press 2 For ADD Course");
                Console.WriteLine("Press 3 To Show All Students");
                Console.WriteLine("Press 4 To Show All Courses");
                Console.WriteLine("Press 5 For Enroll Student in Course");
                Console.WriteLine("Press 6 For ADD Batch");
                Console.WriteLine("Press 7 To show Course with students");
                Console.WriteLine("Press 8 To show Trainer with Batches");
                Console.WriteLine("Press 9 To show Student with Specific Course");
                Console.WriteLine("Press 10 To show Batches with Specific Trainer");


                int operation = Convert.ToInt32(Console.ReadLine());
                try
                {
                    switch (operation)
                    {
                        case 1: studentCRUD.AddStudent(context); break;
                        case 2: courseCRUD.AddCourse(context); break;
                        case 3: studentCRUD.GetAllStudent(context); break;
                        case 4: courseCRUD.GetAllCourse(context); break;
                        case 5: studentCRUD.EnrollStudentInCourse(context);break;
                        case 6: batchCRUD.AddBatch(context); break;
                        case 7: courseCRUD.CourseWithStudent(context); break;
                        case 8: trainerCRUD.TrainerWithBatches(context); break;
                        case 9: courseCRUD.StudentWithSpecificCourse(context); break;
                        case 10:trainerCRUD.BatchesWithSpecificTrainer(context); break;
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
