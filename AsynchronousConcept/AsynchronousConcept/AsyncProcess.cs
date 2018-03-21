using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousConcept
{
    public class AsyncProcess
    {
        public async Task ProcessAsync()
        {
            Console.WriteLine("Async Process Start");
            await ExecuteAsync();
            Console.WriteLine("Async Process End");
        }

        private async Task ExecuteAsync()
        {

        }
    }
}
