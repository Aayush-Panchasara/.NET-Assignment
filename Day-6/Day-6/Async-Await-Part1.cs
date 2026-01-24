using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Day_6
{
    class Async_Await_Part1
    {
        
        public static async Task<string> APICall()
        {
            Console.WriteLine("Inside API"); //4
            await Task.Delay(1000);
            return "Hello From API";
        }
        public static async Task Main()
        {
            Console.WriteLine("First"); //1
            Console.WriteLine("Second"); //2
            Console.WriteLine("Start an API Call"); //3
            var result =  APICall();

            Console.WriteLine("Third"); //5
            Console.WriteLine("Four"); //6

            var responce = await result;
            Console.WriteLine("API call completed");
            Console.WriteLine($"Responce: {responce}");
        }
    }
}
