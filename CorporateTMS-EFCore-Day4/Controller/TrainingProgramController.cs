using CorporateTMS_EFCore_Day4.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Controller
{
    internal class TrainingProgramController
    {
        private TrainingProgramService _trService;
        public TrainingProgramController(TrainingProgramService service)
        {
            _trService = service;
        }

        public void ShowOption()
        {
            Console.WriteLine("For Training Program");
            Console.WriteLine("Press 1 for Create Training Program.----------(Task 1)");
            Console.WriteLine("Press 2 for GetAll Training Program.----------(Task 4)");
            Console.WriteLine("Press 3 for Delete Training Program.----------(Task 7)\n");

        }

        public void TakeUserInput()
        {

            ShowOption();
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("Enter Training Program Title:");
                    string title = Console.ReadLine();

                    Console.Write("Enter Training Program Duration:");
                    int duration = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Training Program StartDate:");
                    DateTime startDate = Convert.ToDateTime(Console.ReadLine());

                    Console.Write("Enter Trainer Id :");
                    int trainerId = Convert.ToInt32(Console.ReadLine());

                    _trService.CreateTrainingProgram(title, duration, startDate,trainerId);
                    break;

                case 2:
                    var TrainingProgram = _trService.GetAllTrainingProgram();

                    foreach (var t in TrainingProgram)
                    {
                        Console.WriteLine($"Training Program: {t.Title}");
                        Console.WriteLine($"Trainer: {t.Trainer.Name}");
                        Console.WriteLine($"Duration: {t.Duration}");

                        Console.WriteLine("Enrolled Employees:\n");
                        Console.WriteLine("Id | Name | Department | Score");
                        if(t.Enrollments.Count != 0)
                        {

                        foreach (var item in t.Enrollments)
                        {
                            Console.WriteLine($"{item.EmployeeId} | {item.Employee.Name} | {item.Employee.Department.Name} | {item.PerformanceScore}");
                        }
                        }
                        else
                        {
                            Console.WriteLine("No Enrollments");
                        }
                        Console.WriteLine();

                    }
                    Console.WriteLine();
                    break;
              

                case 3:
                    Console.Write("Enter Training Program Id:");
                    int DeleteId = Convert.ToInt32(Console.ReadLine());

                    _trService.DeleteTrainingProgram(DeleteId);
                    break;




            }

        }

    }
}
