﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_Programming.ParallelLinq
{
    public class AsParallelExample
    {
        static void ExecuteMain()
        {
            const int count = 50;

            // let's generate an array of numbers from 1 to 20
            var items = Enumerable.Range(1, count).ToArray();

            // now we can get the cubed value of each element in the array using
            var results = new int[count];
            items.AsParallel().ForAll(x =>
            {
                int newValue = x * x * x;
                Console.Write($"{newValue} ({Task.CurrentId})\t");
                results[x - 1] = newValue;
            });
            Console.WriteLine();
            Console.WriteLine();

            foreach (var i in results)
                Console.Write($"{i}\t");
            Console.WriteLine();

            // now let's get an enumeration
            // by default, the sequence is quite different to our nicely laid out array
            // but....                    .AsOrdered()
            // also...                    .AsUnordered()
            var cubes = items.AsParallel().AsOrdered().Select(x => x * x * x);

            // this evaluation is delayed: you actually calculate the values only
            // when iterating or doing ToArray()

            foreach (var i in cubes)
                Console.Write($"{i}\t");
            Console.WriteLine();
        }
    }
}
