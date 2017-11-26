using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadingApplication
{
    class ThreadStaticExample
    {
        [ThreadStatic]
        static int count = 0;

        //static void Main(string[] args)
        //{
        //    Thread threadA = new Thread(() =>
        //    {
        //        for (int i = 0; i <= 10; i++)
        //        {
        //            Console.WriteLine("Thread A_count = " + count++);
        //        }
        //    });

        //    Thread threadB = new Thread(() =>
        //    {
        //        for (int i = 0; i <= 10; i++)
        //        {
        //            Console.WriteLine("Thread B_count = " + count++);
        //        }
        //    });

        //    threadA.Start();
        //    threadB.Start();

        //    Console.ReadKey();
        //}
    }
}
