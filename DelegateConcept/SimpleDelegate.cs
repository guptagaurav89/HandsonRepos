using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateConcept
{
    public class SimpleDelegate
    {
        public delegate double DoubleOp(double d);

        //public static void Main(string[] args)
        //{
        //    //DoubleOp[] operations = { MathOperation.Multiplyby2, MathOperation.Square };
        //    Func<double, double>[] operations = { MathOperation.Multiplyby2, MathOperation.Square };

        //    foreach(var oper in operations)
        //    {
        //        Console.WriteLine("using operation " + oper.Method.Name);
        //        ProcessAndDisplay(oper, 2);
        //        ProcessAndDisplay(oper, 3);
        //    }
        //    Console.ReadKey();
        //}

        static void ProcessAndDisplay(Func<double,double> action, double value)
        //static void ProcessAndDisplay(DoubleOp action, double value)
        {
            var result = action(value);
            Console.WriteLine("Value is " + value + ". Result is " + result);
        }
    }

    class MathOperation
    {
        public static double Multiplyby2(double d)
        {
            return d * 2;
        }

        public static double Square(double d)
        {
            return d * d;
        }
    }
}
