using System;

namespace Concept2
{
    class Program
    {
        static void Main(string[] args)
        {
            Basechild fc = new Firstchild();
            fc.Display();
            Basechild sc = new Secondchild();
            sc.Display();
            Firstchild sfc = new Secondchild();
            sfc.Display();
        }       
    }

    public class Basechild
    {
        public virtual void Display(){Console.WriteLine("Basechild");}
    }
    public class Firstchild : Basechild
    {
        public new virtual void Display()
        {
            Console.WriteLine("FirstChild");
        }
        // public override void Display()
        // {
        //     Console.WriteLine("FirstChild");
        // }
    }

    public class Secondchild : Firstchild
    {
        public override void Display()
        {
            Console.WriteLine("SecondChild");
        }
    }
}
