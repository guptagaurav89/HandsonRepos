using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace APIFramework
{
    public static class IoC
    {
        private static IUnityContainer _container;
        public static IUnityContainer Container
        {
            get { return _container ?? (_container = new UnityContainer()); }
        }
    }
}
