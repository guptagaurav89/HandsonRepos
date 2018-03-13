using APIFramework.Processing;
using APIFramework.ReferenceHandling;
using APIFramework.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.RegistrationByConvention;

namespace APIFramework.Module
{
    public class ModuleInstaller : IUnityInstaller
    {
        public void Configure(IUnityContainer container)
        {
            var allTypes = AllClasses.FromAssemblies(typeof(ModuleInstaller).Assembly).ToArray();

            var handlerTypes = allTypes.Where(t => typeof(IHandleReferences).IsAssignableFrom(t)).ToArray();

            container.RegisterTypes(
               handlerTypes,
               t => t.GetInterfaces().Where(it => it.IsGenericType && typeof(IHandleReferences<>).IsAssignableFrom(it.GetGenericTypeDefinition())),
               t => t.GetInterfaces().Where(it => it.IsGenericType && typeof(IHandleReferences<>).IsAssignableFrom(it.GetGenericTypeDefinition())).FirstOrDefault().GetGenericArguments().FirstOrDefault().Name);

            var commandProcessors = allTypes.Where(t => !t.IsInterface && !t.IsAbstract && t.GetInterfaces().Any(i => i.IsGenericType && typeof(IProcessCommands<>).IsAssignableFrom(i.GetGenericTypeDefinition())));
            container.RegisterTypes(commandProcessors, t => t.GetInterfaces().Where(i => i.IsGenericType && typeof(IProcessCommands<>).IsAssignableFrom(i.GetGenericTypeDefinition())));

        }
    }
}
