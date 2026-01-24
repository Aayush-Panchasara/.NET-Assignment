using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Day_6
{
     class Async_Await_Part2
    {
        static void RunSynchronous()
        {
            FetchDataSync(1);
            FetchDataSync(2);
            FetchDataSync(3);
        }

        static void FetchDataSync(int id)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Fetched data for ID {id}");
        }
        static async Task RunAsynchronous()
        {
            var task1 = FetchDataAsync(1);
            var task2 = FetchDataAsync(2);
            var task3 = FetchDataAsync(3);

            await Task.WhenAll(task1, task2, task3);
        }

        static async Task FetchDataAsync(int id)
        {
            await Task.Delay(1000);
            Console.WriteLine($"Fetched data for ID {id}");
        }
        static async Task Main(string[] args)
        {
            // 1.Synchronous 
            Console.WriteLine("1. Running Synchronous (Blocking) execution...");
            var syncWatch = Stopwatch.StartNew();
            RunSynchronous();
            syncWatch.Stop();
            Console.WriteLine($"Sync Total Time: {syncWatch.ElapsedMilliseconds} ms\n");

            // 2.Asynchronous 
            Console.WriteLine("2. Running Asynchronous (Non-Blocking) execution...");
            var asyncWatch = Stopwatch.StartNew();
            await RunAsynchronous();
            asyncWatch.Stop();
            Console.WriteLine($"Async Total Time: {asyncWatch.ElapsedMilliseconds} ms");

            Console.WriteLine($"Async was {syncWatch.ElapsedMilliseconds / asyncWatch.ElapsedMilliseconds}x faster.");
        }

        
        
    }
}

