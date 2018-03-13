using APIFramework.ReferenceHandling;
using APIFramework.ReferenceHandling.Database.Parameters;
using APIFramework.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Module.References
{
    public class FirstReferenceHandler : BaseReferenceHandler<FirstReference, IReferenceParameter<DatabaseParameters>>
    {
        protected override void Execute(FirstReference reference, IReferenceParameter<DatabaseParameters> parameter)
        {
            Console.WriteLine("Inside Database Reference Handler of First Refernce");
        }
    }
}
