using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcepts
{
    public class BaseComponentFunction<T> : BaseFunction
        where T:Reference
    {
        public override void Execute()
        {
            Console.WriteLine("Hello World");

        }
    }
    public class BaseCustomFunction<T> : BaseFunction
        where T : CustomReference
    {
        public override void Execute()
        {
            Console.WriteLine("Hello World.This is different.");

        }
    }
    public class ComponentFunction<T> : BaseComponentFunction<T>
        where T : ComponentReference
    {

    }

    public class DependentComponentFunction<T> : BaseComponentFunction<T>
       where T : DependentCompReference
    {

    }
}
