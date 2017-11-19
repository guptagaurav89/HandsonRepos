using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadingApplication
{
    class ThreadApp
    {
        int count;
        public ThreadApp(int i)
        {
            count = i;
        }
        public void Execute()
        {
            Console.WriteLine("Before start thread");
            //Thread[] threads = new Thread(new ParameterizedThreadStart(object))[4];
            for (int i = 1; i <= count; i++)
            {
                var t = new Thread(new ThreadStart(this.processThread));
                t.Start();
                t.IsBackground = true;
                Thread.Sleep(2);
                //t.Join();
                
            }
            Console.WriteLine("After start thread");
        }

        public void processThread()
        {
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine("Count : " + i);
                Thread.Sleep(10);
            }
            
        }
    }
}
