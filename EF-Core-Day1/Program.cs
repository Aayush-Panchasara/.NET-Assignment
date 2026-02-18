using EF_Core_Day1.CRUD_Operation;
using EF_Core_Day1.Data;
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
                Console_Menu menu = new Console_Menu();
                menu.StartConsoleMenu(context);
            }

        } 
        
    }
}
