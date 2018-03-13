using APIFramework.Processing;
using APIFramework.ReferenceHandling;
using APIFramework.ReferenceHandling.Database;
using APIFramework.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;
using Unity.RegistrationByConvention;

namespace APIFramework
{
    public class FrameworkInstaller : IUnityInstaller
    {
        public void Configure(IUnityContainer container)
        {
            container.RegisterType<IResolveGenericTypes, UnityGenericTypeResolver>(new HierarchicalLifetimeManager());
            container.RegisterType<IManageReference, DefaultDatabaseReferenceManager>();

            var allClasses = AllClasses.FromAssemblies(typeof(FrameworkInstaller).Assembly);
            var handlerTypes = allClasses.Where(t => typeof(IHandleReferences).IsAssignableFrom(t)).ToArray();

            container.RegisterTypes(handlerTypes, t => t.GetInterfaces()
                .Where(it => it.IsGenericType && typeof(IHandleReferences<>).IsAssignableFrom(it.GetGenericTypeDefinition())
                ));

            var commandProcessors = allClasses.Where(t => !t.IsInterface && !t.IsAbstract && t.GetInterfaces().Any(i => i.IsGenericType && typeof(IProcessCommands<>).IsAssignableFrom(i.GetGenericTypeDefinition())));
            container.RegisterTypes(commandProcessors, t => t.GetInterfaces().Where(i => i.IsGenericType && typeof(IProcessCommands<>).IsAssignableFrom(i.GetGenericTypeDefinition())));

        }
    }
}
