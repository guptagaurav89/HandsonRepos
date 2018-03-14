using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Operations.Functions
{
    public interface IFunction
    {
        string Name { get; }

        string Description { get; }

        void ExecuteFunction(/*IFunctionExecutionContext executionContext*/);

    }

    public interface IFunction<TParameters> : IFunction
        where TParameters : IFunctionParameters
    {
        TParameters Parameters { get; set; }
    }
}
