using APIFramework.Commands;
using APIFramework.Operations.DefaultFunctions.Parameters;
using APIFramework.Operations.Functions;
using APIFramework.Processing;
using APIFramework.ReferenceHandling;
using APIFramework.ReferenceHandling.Database.Parameters;
using APIFramework.References;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Module
{
    public class FirstCommandProcessor : BaseCommandProcessor<FirstCommand>
    {
        public override string Name
        {
            get
            {
                return "First Command";
            }
        }

        private ICreateFunctions FunctionFactory;

        private IManageReference DatabaseManager;        

        public FirstCommandProcessor(IManageReference databaseManager,ICreateFunctions functionFactory)
        {
            DatabaseManager = databaseManager;
            FunctionFactory = functionFactory;
        }

        protected override Task OnProcessingAsync(FirstCommand command)
        {
            //Reference<Database> reference = new FirstReference() as Reference<Database>;
            //reference.ReferenceIdentifier = "First";
            if (command.FirstRefenceProp != null)
            {
                var parameters = new GetDatabaseReferenceParameters
                {
                    Reference = command.FirstRefenceProp,
                };
                FunctionFactory.Create<GetDatabaseReferenceParameters>(parameters).ExecuteFunction();
            }
            var taskCompletionSource = new TaskCompletionSource();
            taskCompletionSource.SetResult();
            return taskCompletionSource.Task;
        }
    }
}
