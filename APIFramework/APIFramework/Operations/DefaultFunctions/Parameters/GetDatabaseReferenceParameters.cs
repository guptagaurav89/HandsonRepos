using APIFramework.Operations.Functions;
using APIFramework.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Operations.DefaultFunctions.Parameters
{
    public class GetDatabaseReferenceParameters : IFunctionParameters
    {
        public Reference<Database> Reference { get; set; }
    }
}
