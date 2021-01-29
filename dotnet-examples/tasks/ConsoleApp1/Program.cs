using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// This program creates 100 Tasks each task waits between 1 and 5 Seconds and the return the wait time
    /// Here you can find and approach to await all tasks making the excution faster than sequential
    /// </summary>
    class Program
    {
        static async Task Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var tasks = new List<Task<int>>();
            for (int i = 0; i < 100; i++)
            {
                tasks.Add(RandomWaitAndReturnRandom());
            }

            var waits = await Task.WhenAll(tasks);
            var totalWait = waits.Sum();

            stopwatch.Stop();
            
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.WriteLine("Total milisecs: {0}", totalWait);
        }

        private static async Task<int> RandomWaitAndReturnRandom()
        {
            var random = new Random();
            var wait = random.Next(1000,5000);
            Console.WriteLine($"Im going to wait {wait} miliseconds");
            await Task.Delay(wait);
            return wait;
        }
    }
}
