﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Parallel_Programming.ConcurrentCollections
{
   public static class ConcurrentQueueDemo
    {
       public static void excuteMain()
        {
            var q = new ConcurrentQueue<int>();
            q.Enqueue(1);
            q.Enqueue(2);

            // Queue: 2 1 <- front

            int result;
            //int last = q.Dequeue();
            if (q.TryDequeue(out result))
            {
                Console.WriteLine($"Removed element {result}");
            }

            // Queue: 2

            //int peeked = q.Peek();
            if (q.TryPeek(out result))
            {
                Console.WriteLine($"Last element is {result}");
            }
        }
    }
}
