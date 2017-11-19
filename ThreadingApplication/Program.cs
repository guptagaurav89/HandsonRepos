using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Threading App");
            ThreadApp tapp = new ThreadApp(3);
            tapp.Execute();

            Console.ReadKey();
        }        
    }
}
