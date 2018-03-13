using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.ReferenceHandling
{
    public interface IManageReference
    {
        /// <summary>
        /// Handles the specified operation context.
        /// </summary>
        /// <typeparam name="TReference">The type of the reference.</typeparam>
        /// <typeparam name="TParameter">The type of the parameter.</typeparam>
        /// <param name="reference">The reference.</param>
        /// <param name="parameter">The parameter.</param>
        void Handle<TReference, TParameter>(TReference reference, TParameter parameter)
            where TReference : Reference
            where TParameter : IReferenceParameter;
    }

}
