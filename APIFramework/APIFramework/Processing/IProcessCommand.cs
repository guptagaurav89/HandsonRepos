using APIFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Processing
{
    public interface IProcessCommands<in TCommand>
       where TCommand : Command
    {

        string Name { get; }
        /// <summary>
        /// Process the command, returning any <see cref="Message"/>'s that were generated as part of the processing.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>A collection of <see cref="Message"/>'s generated when processing</returns>
        /// <exception cref="CommandProcessorException"></exception>
        /// <exception cref="Exception"></exception>
        void Process(TCommand command);
    }
}
