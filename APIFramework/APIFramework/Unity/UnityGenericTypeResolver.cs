using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace APIFramework.Unity
{
    class UnityGenericTypeResolver : IResolveGenericTypes    {
        
            private readonly IUnityContainer _container;

            public UnityGenericTypeResolver(IUnityContainer container)
            {
                _container = container;
            }

            public TService Resolve<TService>()
            {
                return _container.Resolve<TService>();
            }

            public object Resolve(Type serviceType)
            {
                return _container.Resolve(serviceType);
            }

            public IEnumerable<object> ResolveAll(Type serviceType)
            {
                return _container.ResolveAll(serviceType);
            }

            public TService Resolve<TService>(string name)
            {
                return _container.Resolve<TService>(name);
            }

            public object Resolve(Type serviceType, string name)
            {
                return _container.Resolve(serviceType, name);
            }

            public bool IsRegistered(Type serviceType)
            {
                return _container.IsRegistered(serviceType);
            }

            public bool IsRegistered(Type serviceType, string name)
            {
                return _container.IsRegistered(serviceType, name);
            }
        
    }
}
