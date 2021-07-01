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
        public virtual void Display(){Console.WriteLine("Basechild"); DisplayStatic();}

        public static void DisplayStatic(){Console.WriteLine("Base Static");}
        //Static Method cannot be virtual, abstract or override
    }
    /*Sealed*/ public class Firstchild : Basechild 
    //Sealed Class will not able to inherited further
    {
        // public new virtual void Display()
        public override void Display()
        {
            Console.WriteLine("FirstChild");
            DisplayStatic();
        }
        public new static void DisplayStatic(){Console.WriteLine("FirstChild Static");}
    }

    public class Secondchild : Firstchild
    {
        public override void Display()
        {
            Console.WriteLine("SecondChild");
        }
    }
}
