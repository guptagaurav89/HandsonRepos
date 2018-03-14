using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Operations.Functions
{
    public abstract class BaseFunction<TParameters> : IFunction<TParameters>
        where TParameters : IFunctionParameters
    {
        public abstract string Description
        {
            get;            
        }

        public abstract string Name
        {
            get;
        }

        public TParameters Parameters
        {
            get;
            set;
        }

        protected ICreateFunctions FunctionFactory { get; private set; }

        protected BaseFunction(ICreateFunctions functionFactory)
        {            
            FunctionFactory = functionFactory;
        }

        public void ExecuteFunction()
        {
            Console.WriteLine("Inside Base Function");
            try
            {
                OnProcessing();
            }
            catch(Exception)
            {
                throw;
            }
        }

        protected abstract void OnProcessing();
    }
}
