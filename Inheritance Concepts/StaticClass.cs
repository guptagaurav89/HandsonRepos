using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Inheritance_Concepts
{
    static class StaticClass
    {
        static int privVar;
        public static void show()
        {
            Console.WriteLine("privVar value : " + privVar);
        }
    }

    class ChildStaticClass 
    {
        public void show()
        {
            Console.WriteLine("Inside child Class");
        }
    }
}
