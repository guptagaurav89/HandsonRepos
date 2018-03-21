using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousConcept
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    Console.WriteLine("hleoo");

        //    AsyncProcess bootsrapper = new AsyncProcess();

        //    Console.ReadKey();
        //}
          
        static void Main(string[] args)
        {
            callMethod();
            Console.WriteLine("Main Method " + Thread.CurrentThread.ManagedThreadId);        
            Console.ReadKey();
        }

        public static async void callMethod()
        {
            Console.WriteLine("Calling 1nd Method " + Thread.CurrentThread.ManagedThreadId);
            Task<int> task = Method1();
            Console.WriteLine("Calling 2nd Method " + Thread.CurrentThread.ManagedThreadId);
            Method2();
            Console.WriteLine("Waiting 1nd Method " + Thread.CurrentThread.ManagedThreadId);
            int count = await task;
            Console.WriteLine("Calling 3rd Method " + Thread.CurrentThread.ManagedThreadId);
            Method3(count);
        }

        public static async Task<int> Method1()
        {
            Console.WriteLine("Inside 1nd Method " + Thread.CurrentThread.ManagedThreadId);
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(" Method 1 " + Thread.CurrentThread.ManagedThreadId);
                    count += 1;
                }
            });
            return count;
        }


        public static void Method2()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(" Method 2 " + Thread.CurrentThread.ManagedThreadId);
            }
        }


        public static void Method3(int count)
        {
            Console.WriteLine("Total count is " + count + " " + +Thread.CurrentThread.ManagedThreadId);
        }
    }
}
