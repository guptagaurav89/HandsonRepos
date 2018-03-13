using APIFramework.Commands;
using APIFramework.Processing;
using APIFramework.References;
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
            FirstCommand command = new FirstCommand() { FirstRefenceProp = new FirstReference() { ReferenceIdentifier = "First" } };
            IProcessCommands<FirstCommand> commandProcessor = IoC.Container.Resolve<IProcessCommands<FirstCommand>>();
            commandProcessor.Process(command);
            Console.ReadKey();
        }

        private static void SetupContainer(IUnityContainer container)
        {
            container.InstallModules();
        }
    }
}
