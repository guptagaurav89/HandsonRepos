using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcepts
{
    public interface IReference { }
    public class Reference : IReference
    {
    }

    public class CustomReference : IReference { }
    public class ComponentReference : Reference { }
    public class DependentCompReference : Reference { }

    public class ProdCompReference : Reference { }
}
