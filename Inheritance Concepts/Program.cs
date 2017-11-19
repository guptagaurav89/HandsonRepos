using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Inheritance_Concepts
{
    class Program
    {
        int i = 10;
        static void Main(string[] args)
        {
            try
            {
                Base objBase = new Base();
                //Base objBase2 = new Base();
                Child objChild = new Child();
                thirdlevelChild objTh = new thirdlevelChild();
                objBase.show();
                objChild.show(12);
                objTh.show();
                //ChildStaticClass clsObj = new ChildStaticClass();
                //clsObj.show();
                
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
               // Program.Main(args);
                Console.ReadKey();
            }

        }
    }

    /// Base Class
    class Base    
    /// sealed class Base
    /// sealed class cannot be inherited
    {
        int privBaseVar;
        protected static int staticBaseVar;

        //Static Constructor
        static Base()        
        {
            staticBaseVar = 0;
        }

        //Non-Parameterised Constructor
        public Base()
        {
            staticBaseVar++;
            privBaseVar = 10;
        }

        public Base(int var)
        {

            staticBaseVar++;
            privBaseVar = var;
        }


        ///Protected Method
        ///Access private data member for child class
        protected void Set()
        {
            privBaseVar = 20;
        }
        public void show()
        {
            Console.WriteLine("Base Class Instance");
            Console.WriteLine(" Private Var : " + privBaseVar);
            Console.WriteLine(" Static Var Count: " + staticBaseVar);
        }
    }
    class Child : Base
    {
        int privChildVar;
        static int staticChildVar;
        static Child()
        {            
            staticChildVar = 0;
        }
        public Child() :base(20)
        {
            staticChildVar++;
            privChildVar = 100;            
        }
        //public new void  show()
        //{

        //    Console.WriteLine("Child Class Instance");
        //    base.show();
        //    Console.WriteLine(" Private Var : " + privChildVar);
        //    Console.WriteLine(" Static Var Count: " + staticChildVar);
        //}
        public void show(int val)
        {

            Console.WriteLine("Child Class Instance");
            base.show();
            Console.WriteLine(" Private Var : " + privChildVar);
            Console.WriteLine(" Static child Var Count: " + staticChildVar);
        }
    }
    class thirdlevelChild : Child
    {
        int privChildVar;
        static int staticChildVar;
        public void show()
        {
            Console.WriteLine("ThirdLevel Child Class Instance");
            base.show();
            Console.WriteLine(" Private Var : " + privChildVar);
            Console.WriteLine(" Static child Var Count: " + staticChildVar);
        }
    }
}
