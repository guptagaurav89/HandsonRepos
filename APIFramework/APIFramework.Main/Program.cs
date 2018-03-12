using APIFramework.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace APIFramework.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupContainer(IoC.Container);
            Console.WriteLine("hello world");
            Console.ReadKey();
        }

        private static void SetupContainer(IUnityContainer container)
        {
            container.InstallModules();
        }
    }
}
