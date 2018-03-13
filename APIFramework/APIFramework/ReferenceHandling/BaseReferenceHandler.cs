using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.ReferenceHandling
{
    public abstract class BaseReferenceHandler<TReference, TParameter> : IHandleReferences<TReference>
        where TReference : class, Reference
        where TParameter : class, IReferenceParameter
    {
        public virtual void Handle(Reference reference, IReferenceParameter parameters)
        {
            if (reference is TReference)
            {
                Execute((TReference)reference, (TParameter)parameters);
            }
        }

        protected abstract void Execute(TReference reference, TParameter parameter);
    }
}
