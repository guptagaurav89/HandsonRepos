using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Unity;
using Unity.RegistrationByConvention;

namespace APIFramework.Unity
{
    public static class UnityExtension
    {
        public static IUnityContainer InstallModules(this IUnityContainer container)
        {
            var binPath = AppDomain.CurrentDomain.BaseDirectory;
            var assemblies = Directory
                .GetFiles(binPath, "*.dll")
                .Where(f =>
                {                    
                    try
                    {
                        AssemblyName.GetAssemblyName(f);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                })
                .Select(f =>
                {
                    try
                    {
                        return Assembly.LoadFrom(f);
                    }
                    catch
                    {
                        return null;
                    }
                })
                .Where(asm => asm != null);

            var moduleTypes = AllClasses
                .FromAssemblies(
                    assemblies
                )
                .Where(t => typeof(IUnityInstaller).IsAssignableFrom(t));

            foreach (var moduleType in moduleTypes)
            {
                try
                {
                    var module = (IUnityInstaller)Activator.CreateInstance(moduleType);
                    module.Configure(container);
                    //Logger.Info(m => m("Installed '{0}'", module.GetType().Name));
                }
                catch (Exception ex)
                {
                    //Logger.Error(string.Format("Error configuring container with module '{0}'", moduleType), ex);
                }
            }
            return container;
        }
    }
}
