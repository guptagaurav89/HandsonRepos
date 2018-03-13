using APIFramework.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace APIFramework.ReferenceHandling.Database
{
    public class DefaultDatabaseReferenceManager : IManageReference
    {
        private readonly DatabaseReferenceHandlerFactory _apiDatabaseReferenceHandlerFactory;
        public DefaultDatabaseReferenceManager(IResolveGenericTypes typeFactory)
        {
            _apiDatabaseReferenceHandlerFactory =  new DatabaseReferenceHandlerFactory(typeFactory);
        }
        public void Handle<TReference, TParameter>(TReference reference, TParameter parameter)
            where TReference : Reference
            where TParameter : IReferenceParameter
        {
            if (string.IsNullOrEmpty(reference.ReferenceIdentifier))
            {                
                return;
            }

            //_logger.Debug(m => m("Attempting to resolve all pending Reference actions for '{0}'", reference.GetType().Name));

            var handlers = _apiDatabaseReferenceHandlerFactory.Create(reference);
            if (handlers == null || !handlers.Any())
            {
                throw new Exception(reference.GetType().ToString());
            }
            foreach (var handler in handlers)
            {
                try
                {
                    handler.Handle(reference, parameter);
                }
                catch (Exception ex)
                {
                    //var exception = new DatabaseReferenceHandlerFailedException(ex);
                    //_logger.Error(exception.ToString());
                    throw ex;
                }
            }
        }
    }
}
