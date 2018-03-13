using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.ReferenceHandling.Database.Parameters
{
    public class DefaultDatabaseReferenceParameters : IReferenceParameter<DatabaseParameters>
    {
        public DatabaseParameters Data { get; set; }
    }
}
