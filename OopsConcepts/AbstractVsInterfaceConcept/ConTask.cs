using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractVsInterfaceConcept
{
    class ConTask : Task
    {
        public override void Start()
        {
            Console.WriteLine("ConTAsk Task Start");
        }

        public virtual void Start(int i)
        {
            Console.WriteLine("No Modifier Con Task Start");
        }

        /* public new void Start()
        {
            Console.WriteLine("ConTAsk Task Start");
        }*/
    }
}
