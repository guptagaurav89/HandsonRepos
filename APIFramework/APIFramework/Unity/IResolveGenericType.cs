using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Unity
{
    public interface IResolveGenericTypes
    {
        /// <summary>
        /// Resolves an instance of TService
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        TService Resolve<TService>();

        /// <summary>
        /// Resolves the specified service type.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        object Resolve(Type serviceType);

        /// <summary>
        /// Resolves all.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        IEnumerable<object> ResolveAll(Type serviceType);

        /// <summary>
        /// Resolves a service with the specified name.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        TService Resolve<TService>(string name);

        /// <summary>
        /// Resolves the specified service type.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        object Resolve(Type serviceType, string name);

        /// <summary>
        /// Determines whether the specified service type is registered.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        bool IsRegistered(Type serviceType);

        /// <summary>
        /// Determines whether the specified service type is registered.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        bool IsRegistered(Type serviceType, string name);
    }
}
