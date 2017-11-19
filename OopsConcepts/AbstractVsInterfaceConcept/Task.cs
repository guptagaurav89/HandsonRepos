using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractVsInterfaceConcept
{
    abstract class Task : ITask
    {
        public virtual void Start()
        {
            Console.WriteLine("Abstract Class Task Start");
        }
    }
}
