using APIFramework.Commands;
using Nito.AsyncEx.Synchronous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APIFramework.Processing
{
    public abstract class BaseCommandProcessor<TCommand> : IProcessCommands<TCommand>
        where TCommand : Command
    {
        public abstract string Name { get; }

        //protected readonly IBootstrapProcessing Bootstrapper;

        public virtual void Process(TCommand command)
        {
            try
            {
                OnProcessingAsync(command).WaitAndUnwrapException(CancellationToken.None);
            }
            catch(Exception)
            {

            }
        }

#pragma warning disable 1998
        protected async virtual Task OnProcessingAsync(TCommand command)
#pragma warning restore 1998
        {

        }
    }
}
