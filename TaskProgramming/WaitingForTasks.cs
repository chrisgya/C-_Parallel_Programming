﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_Programming.TaskProgramming
{
   public static class WaitingForTasks
    {
       public static void ExecuteMain()
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(3));
            var token = cts.Token;

            var t = new Task(() =>
            {
                Console.WriteLine("I take 5 seconds");
                //Thread.Sleep(5000);

                for (int i = 0; i < 5; ++i)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }

                Console.WriteLine("I'm done.");
            });
            t.Start();

            var t2 = Task.Factory.StartNew(() => Thread.Sleep(3000), token);

            //t.Wait();
            //t.Wait(3000);

            // now introduce t2

            //Task.WaitAll(t, t2);
            //Task.WaitAny(t, t2);

            // start w/o token
            try
            {
                // throws on a canceled token
                Task.WaitAll(new[] { t, t2 }, 4000, token);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }

            Console.WriteLine($"Task t  status is {t.Status}.");
            Console.WriteLine($"Task t2 status is {t2.Status}.");

        }
    }
}
