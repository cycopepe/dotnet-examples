using System;
using System.Reflection.Metadata.Ecma335;

namespace dotnet_examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sum(4000));
            Console.ReadKey();
        }

        static int Sum(int n)
        {
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
            Console.WriteLine("Total bytes Thread: {0}", GC.GetAllocatedBytesForCurrentThread());
            return n <= 0 ? 0 : (n + Sum(n - 1));
        }
    }
}
