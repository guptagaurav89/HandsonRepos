using APIFramework.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Commands
{
    public class FirstCommand : Command
    {
        private FirstReference _FirstReferenceProp;
        public FirstReference FirstRefenceProp
        {
            get { return _FirstReferenceProp; }
            set { _FirstReferenceProp = value; }
        }
    }
}
