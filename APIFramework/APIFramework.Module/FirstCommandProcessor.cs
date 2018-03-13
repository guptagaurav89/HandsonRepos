using APIFramework.Commands;
using APIFramework.Processing;
using APIFramework.ReferenceHandling;
using APIFramework.ReferenceHandling.Database.Parameters;
using APIFramework.References;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private IManageReference DatabaseManager;
        public FirstCommandProcessor(IManageReference databaseManager)
        {
            DatabaseManager = databaseManager;
        }

        protected override Task OnProcessingAsync(FirstCommand command)
        {
            var reference = new FirstReference();
            reference.ReferenceIdentifier = "First";
            var referenceParams = new DefaultDatabaseReferenceParameters
            {
                Data = new DatabaseParameters
                {
                    RootIdentity = "First"                    
                }
            };

            DatabaseManager.Handle(reference, referenceParams);
            var taskCompletionSource = new TaskCompletionSource();
            taskCompletionSource.SetResult();
            return taskCompletionSource.Task;
        }
    }
}
