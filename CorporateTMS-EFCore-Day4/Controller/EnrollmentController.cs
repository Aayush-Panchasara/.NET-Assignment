using CorporateTMS_EFCore_Day4.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Controller
{
    internal class EnrollmentController
    {
        private EnrollmentService _enrService;
        public EnrollmentController(EnrollmentService service)
        {
            _enrService = service;
        }

        public void ShowOption()
        {
            Console.WriteLine("For Enrollment");
            Console.WriteLine("Press 1 for Add Enrollment.----------(Task 3)");
            Console.WriteLine("Press 2 for Update Enployee's Preformance Score.----------(Task 6)");

        }

        public void TakeUserInput()
        {

            ShowOption();
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("Enter Employee ID:");
                    int employeeId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Training Program ID:");
                    int trainingId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Enrollment Date:");
                    DateTime enrollmentDate = Convert.ToDateTime(Console.ReadLine());


                    _enrService.EnrollEmployee(employeeId, trainingId, enrollmentDate);
                    break;


                case 2:
                    Console.Write("Enter Employee Id:");
                    int empId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter TrainingProgram Id:");
                    int trId= Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Employee Performance Score:");
                    int score= Convert.ToInt32(Console.ReadLine());

                    _enrService.UpdateScore(empId,trId,score);
                    break;





            }

        }
    }
}
