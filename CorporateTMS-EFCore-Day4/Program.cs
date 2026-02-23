using CorporateTMS_EFCore_Day4.Controller;
using CorporateTMS_EFCore_Day4.Repository.Data;
using CorporateTMS_EFCore_Day4.Repository.Model;
using CorporateTMS_EFCore_Day4.Repository.Repositories;
using CorporateTMS_EFCore_Day4.Services;

namespace CorporateTMS_EFCore_Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using(var context = new AppDBContext())
            {
                //Employee
                EmployeeRepository empRepo = new EmployeeRepository(context);
                EmployeeService empService = new EmployeeService(empRepo);
                EmployeeController empController = new EmployeeController(empService);

                //Department
                DepartmentRepository deptRepo = new DepartmentRepository(context);
                DepartmentServices deptServices = new DepartmentServices(deptRepo);
                DepartmentController deptController = new DepartmentController(deptServices);

                //TrainingProgram
                TrainingProgramRepository trRepo = new TrainingProgramRepository(context);
                TrainingProgramService trService = new TrainingProgramService(trRepo);
                TrainingProgramController trController = new TrainingProgramController(trService);

                //ENrollments
                EnrollmentRepository enrRepo = new EnrollmentRepository(context);
                EnrollmentService enrollmentService = new EnrollmentService(enrRepo);
                EnrollmentController enrController = new EnrollmentController(enrollmentService);

                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Press 1 To Manage Employee");
                    Console.WriteLine("Press 2 To Manage Department");
                    Console.WriteLine("Press 3 To Manage TrainingProgram");
                    Console.WriteLine("Press 4 To Manage Enrollments\n");

                    int option = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        switch (option)
                        {
                            case 1: empController.TakeUserInput(); break;
                            case 2: deptController.TakeUserInput(); break;
                            case 3: trController.TakeUserInput(); break;
                            case 4: enrController.TakeUserInput(); break;
                        }
                    }catch(Exception e)
                    {
                        Console.WriteLine($"Error : {e.Message}"); 
                    }
                   

                    Console.WriteLine("Do you want to continue?(y/n)");
                    char ch = Convert.ToChar(Console.ReadLine());

                    if(ch == 'n')
                    {
                        flag = false;
                    }
                    else if(ch == 'y')
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
            }
        }
    }
}
