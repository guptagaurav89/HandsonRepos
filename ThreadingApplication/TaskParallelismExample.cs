using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingApplication
{
    class TaskParallelismExample
    {
        public static void Main(string[] args)
        {
            Task<int> t = new Task<int>(n => Sum((int)n), 121);
            t.Start();

            //Task t1 = new Task(delegate { Print(1); });
            //Task t2 = new Task(() => Print(2));
            //t1.Start();
            //t2.Start();
            Print(t.Result);

            ///Task.Factory = better performance than new Task 
            ///Used in .Net 4.0
            Task mytask = Task.Factory.StartNew(() => { Console.WriteLine("Inside Task Factory Action"); });
            mytask.Wait();

            ///Task.Run = manage task effeciently than Factory
            ///Used in .Net 4.5
            Task newtask = Task.Run(() => { Console.WriteLine("Task.Run was implemented in .Net 4.5"); });
            newtask.Wait();


            ////Sequential Programming
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //Console.WriteLine("Sequential Programming");
            //for (int i = 3; i <= 50; i++)
            //{
            //    Console.WriteLine(i);
            //}
            //stopwatch.Stop();
            //Console.Error.WriteLine("Sequential loop time in milliseconds: {0}",
            //                        stopwatch.ElapsedMilliseconds);

            //stopwatch.Reset();
            ////Data Parallelism
            //Console.WriteLine("Data parallelism");
            ////ParallelOptions
            ////CancellationTokenSource

            ////Task.Factory.Continue

            //stopwatch.Start();
            //Parallel.For(3, 50, n => { Console.WriteLine(n); if (n == 44) { return; } });
            //stopwatch.Stop();
            //Console.Error.WriteLine("parallel loop time in milliseconds: {0}",
            //                        stopwatch.ElapsedMilliseconds);

            Console.ReadLine();
        }

        private static int Sum(int a)
        {
            return a + 10;
        }
        private static void Print(int x)
        {
            Console.WriteLine("This is new line " + x);
        }
    }
}
