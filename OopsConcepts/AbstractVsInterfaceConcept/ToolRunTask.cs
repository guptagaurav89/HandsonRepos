using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractVsInterfaceConcept
{
    class ToolRunTask : ITask
    {
        public void Start()
        {
            Console.WriteLine("ToolRun Task Start");
        }
    }
}
