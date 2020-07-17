using System;

namespace GarbageCollectorExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RecursiveSum(4000));
            Console.ReadKey();
        }

        static int RecursiveSum(int n)
        {
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
            Console.WriteLine("Total bytes Thread: {0}", GC.GetAllocatedBytesForCurrentThread());
            return n <= 0 ? 0 : (n + RecursiveSum(n - 1));
        }
    }
}
