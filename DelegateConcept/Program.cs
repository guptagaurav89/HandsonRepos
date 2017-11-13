using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateConcept
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    DelegateClass dc = new DelegateClass();
        //    string s = "11";
        //    bool isvalid = dc.isValid(s, DateTime.Parse);
            
        //    Console.WriteLine("val : " +isvalid);

        //    //isvalid = dc.isValid(s, int.Parse);
        //    Console.ReadKey();
        //}
    }

    class DelegateClass
    {
        public delegate DateTime fnFormat(string s);

        public bool isValid(string s, fnFormat test)
        {
            bool chk;
            if (string.IsNullOrEmpty(s))
                chk = false;
            else
            {
                try
                {
                    var dt = test(s);
                    chk = true;
                }
                catch (Exception)
                {
                    chk = false;
                }
            }
            return chk;
        }
    }
}
