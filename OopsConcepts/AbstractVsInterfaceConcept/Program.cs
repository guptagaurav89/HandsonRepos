using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractVsInterfaceConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            ITask t1 = new ToolRunTask();
            Task t2 = new ConTask();

            t1.Start();
            t2.Start();
            Console.ReadKey();
        }
    }
}
