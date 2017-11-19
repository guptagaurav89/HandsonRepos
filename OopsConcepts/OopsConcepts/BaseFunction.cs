using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcepts
{
    public abstract class BaseFunction : IFunction
       // where T : IReference
    {
        public virtual void Execute()
        {
            
        }
    }

    public interface IFunction
    {
        void Execute();
    }
}
