using Parallel_Programming.TaskProgramming;
using System;

namespace Parallel_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            WaitingForTimeToPass.ExecuteMain();

            Console.WriteLine("Main program done, press any key.");
            Console.ReadKey();
        }
    }
}
