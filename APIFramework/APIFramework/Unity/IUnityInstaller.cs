using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace APIFramework.Unity
{
    public interface IUnityInstaller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        void Configure(IUnityContainer container);
    }
}
