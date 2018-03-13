using APIFramework.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.ReferenceHandling
{
    public interface IHandleReferences<TReference> : IHandleReferences
        where TReference : Reference
    {

    }


    /// <summary>
    /// Convenience interface that makes iteasy to register by convention.
    /// </summary>
    public interface IHandleReferences
    {

        /// <summary>
        /// Handles a single <see cref="Reference" /> derived type.
        /// </summary>
        /// <param name="reference">The <see cref="Reference" /> type</param>
        /// <param name="parameters">The parameters.</param>
        void Handle(Reference reference, IReferenceParameter parameters);
    }
}
