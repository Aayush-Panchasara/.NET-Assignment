using EF_Core_Day1.CRUD_Operation;
using EF_Core_Day1.Data;
using EF_Core_Day1.EF_Loading;
using EF_Core_Day1.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

namespace EF_Core_Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppContextDB())
            {
               

                //    Console_Menu menu = new Console_Menu();
                //    menu.StartConsoleMenu(context);

                //var result = context.Trainers.ToList();

                //var result2 = context.Trainers.Include(t => t.Batches).ToList();

                //var result3 = context.Trainers.Include(t => t.Batches).ThenInclude(b => b.Course).ToList();


                StudentCRUD st = new StudentCRUD(context);
                CourseCRUD co = new CourseCRUD(context);
                TrainerCRUD tr = new TrainerCRUD(context);

                bool flag = true;

                while (flag) {

                    Console.WriteLine("For Operations");
                    Console.WriteLine("Press 1 for Start Student CRUD");
                    Console.WriteLine("Press 2 for Start Course CRUD");
                    Console.WriteLine("Press 3 for Start Trainer CRUD");
                    Console.WriteLine("Press 4 To Perform Eager Loading");
                    Console.WriteLine("Press 5 To Perform Lazy Loading");
                    Console.WriteLine("Press 6 To Perform Explicit Loading");

                    int operation = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        switch (operation)
                        {
                            case 1: st.StartCRUDOperation(); break;
                            case 2: co.StartCRUDOperation(); break;
                            case 3: tr.StartCRUDOperation(); break;
                            case 4: Loading.EagerLoading(context);break;
                            case 5: Loading.LazyLoading(context);break;
                            case 6: Loading.ExplicitLoading(context);break;

                        }
                    }
                    catch (Exception ex) {

                        Console.WriteLine($"Error: {ex.Message}");
                    
                    }
                    Console.Write("\nDo you Want to continue?(y/n): ");
                    char option = Convert.ToChar(Console.ReadLine());

                    if (option == 'n')
                    {
                        flag = false ;
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
}
