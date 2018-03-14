using APIFramework.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Operations.Functions
{
    public class DefaultFunctionFactory : ICreateFunctions
    {
        private readonly IResolveGenericTypes _typeFactory;
        public DefaultFunctionFactory(IResolveGenericTypes typeFactory)
        {
            _typeFactory = typeFactory;
        }
        public IFunction<TParameters> Create<TParameters>(TParameters parameters = default(TParameters)) where TParameters : IFunctionParameters
        {
            if (_typeFactory.IsRegistered(typeof(IFunction<TParameters>)))
            {
                Console.WriteLine("Attempting to resolve '{0}'", typeof(IFunction<TParameters>));

                var operation = _typeFactory.Resolve<IFunction<TParameters>>();
                operation.Parameters = parameters;
                return operation;
            }
            throw new Exception("No Function Registered");
        }
    }
}
