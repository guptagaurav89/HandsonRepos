using APIFramework.ReferenceHandling;
using APIFramework.References;
using APIFramework.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace APIFramework.ReferenceHandling.Database
{
    public class DatabaseReferenceHandlerFactory
    {
        private readonly IResolveGenericTypes _typeFactory;
        public DatabaseReferenceHandlerFactory(IResolveGenericTypes typeFactory)
        {
            
            _typeFactory = typeFactory;
        }
        public IEnumerable<IHandleReferences> Create<TReference>(TReference reference)
           where TReference : Reference
        {
            var referenceHandlerType = typeof(IHandleReferences<>).MakeGenericType(reference.GetType());
            //_logger.Debug(m => m("Attempting to resolve '{0}'", referenceHandlerType.Name));
            //if (_typeFactory.IsRegistered(referenceHandlerType))
            //{
            return _typeFactory.ResolveAll(referenceHandlerType).Cast<IHandleReferences>();
            //}
            //return null;
        }
    }
}
