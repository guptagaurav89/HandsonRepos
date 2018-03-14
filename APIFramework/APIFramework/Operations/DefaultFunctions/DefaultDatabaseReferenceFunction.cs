using APIFramework.Operations.DefaultFunctions.Parameters;
using APIFramework.Operations.Functions;
using APIFramework.ReferenceHandling;
using APIFramework.ReferenceHandling.Database.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Operations.DefaultFunctions
{
    public class DefaultDatabaseReferenceFunction : BaseFunction<GetDatabaseReferenceParameters>
    {
        public override string Description
        {
            get
            {
                return "DatabaseFunction";
            }
        }

        public override string Name
        {
            get
            {
                return "DefaultDatabaseReferenceFunction";
            }
        }

        private IManageReference DatabaseManager;
        public DefaultDatabaseReferenceFunction(IManageReference databaseManager,ICreateFunctions functionFactory)
            : base(functionFactory)
        {
            DatabaseManager = databaseManager;
        }

        protected override void OnProcessing()
        {
            var referenceParams = new DefaultDatabaseReferenceParameters
            {
                Data = new DatabaseParameters
                {
                    RootIdentity = "First"
                }
            };

            DatabaseManager.Handle(Parameters.Reference, referenceParams);
        }
    }
}
