using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.ReferenceHandling.Database.Parameters
{
    public class DatabaseParameters : ReferenceParameter
    {
        public string RootIdentity { get; set; }       
        public string UniqueIdentifier { get; set; }
    }
}
