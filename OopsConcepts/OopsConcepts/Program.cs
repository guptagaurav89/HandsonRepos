using System;

namespace OopsConcepts
{
    class Program
    {
        static void Main(string[] args)
        {
            Human obj = new Man();
            obj.Walk();

            Human obj1 = new Human();
            obj1.Walk();
            Console.ReadKey();

            //Runtime Polymorphism
            BaseFunction x = new ComponentFunction<ComponentReference>();
            x.Execute();
            x = new DependentComponentFunction<DependentCompReference>();
            x.Execute();
            x = new BaseCustomFunction<CustomReference>();
            x.Execute();
            Console.ReadKey();
        }
    }

    //Method Hiding using New keyword
    //class Human
    //{
    //    public void Walk()
    //    {
    //        Console.WriteLine("human walks");
    //    }
    //}

    //class Man : Human
    //{
    //    public new void Walk()
    //    {
    //        Console.WriteLine("man walks");
    //    }
    //}


    //Method Overriding using virtual and Override keyword
    class Human
    {
        public virtual void Walk()
        {
            Console.WriteLine("human walks");
        }
    }

    class Man : Human
    {
        public override void Walk()
        {
            Console.WriteLine("man walks");
        }
    }
}
