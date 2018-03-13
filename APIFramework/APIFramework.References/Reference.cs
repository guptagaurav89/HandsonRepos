using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.References
{
    public interface Reference
    {
        string ReferenceIdentifier { get; set; }

        string DestinationPropertyName { get; }
    }

    /// <summary>
    /// Marker interface for Reference types
    /// </summary>
    public interface Reference<TType> : Reference
        where TType : ReferenceType
    {
    }

    public abstract class ReferenceType { }

    public class Database : ReferenceType { }
}
