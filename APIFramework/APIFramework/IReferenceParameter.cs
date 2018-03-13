using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework
{
    public interface IReferenceParameter
    {

    }

    public interface IReferenceParameter<TType> : IReferenceParameter
    where TType : ReferenceParameter
    {
        TType Data { get; set; }
    }

    public abstract class ReferenceParameter
    {
    }
}
