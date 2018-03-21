using Nito.AsyncEx;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousConcept
{
    public class AsyncProcess
    {
        private readonly IProducerConsumerCollection<string> _collection;

        private readonly AsyncLock _mutex;
        private readonly AsyncConditionVariable _completedOrIsEmpty;
        private readonly AsyncConditionVariable _completedOrNotEmpty;
        private readonly CancellationTokenSource _cancelled;
        private readonly CancellationTokenSource _completed;
        private readonly CancellationTokenSource _cancelledOrCompleted;
        private bool Empty { get { return _collection.Count == 0; } }

        //public ProcessingCollection(IProducerConsumerCollection<T> collection)
        //{
        //    _completed = new CancellationTokenSource();
        //    _mutex = new AsyncLock();
        //    _cancelled = new CancellationTokenSource();
        //    _cancelledOrCompleted = CancellationTokenSource.CreateLinkedTokenSource(_cancelled.Token, _completed.Token);
        //    _completedOrIsEmpty = new AsyncConditionVariable(_mutex);
        //    _completedOrNotEmpty = new AsyncConditionVariable(_mutex);
        //    _collection = collection ?? new ConcurrentQueue<T>();
        //}

        public void CompleteAdding()
        {
            using (_mutex.Lock())
            {
                if (_completed.IsCancellationRequested)
                    return;
                _completed.Cancel();
                _completedOrIsEmpty.NotifyAll();
                _completedOrNotEmpty.NotifyAll();
            }
        }
        public async Task ProcessAsync()
        {
            Console.WriteLine("Async Process Start");
            //AddRootFunction<T>(context, parameters);

            //var completion = AwaitCompletionAsync(context);

            ////create a timeout cancellationToken
            ////start the processing tasks
            //await Task
            //    .WhenAll(
            //        _executor.ExecuteAsync(context),
            //        _evaluator.ExecuteAsync(context));

            //await completion;
            Console.WriteLine("Async Process End");
        }

        private async Task ExecuteAsync()
        {

        }

        //private static async Task AwaitCompletionAsync(IProcessingContext context)
        //{
        //    do
        //    {
        //        await Task.WhenAll(
        //            context.InteractionCollection.IsEmptyAsync(),
        //            context.EvaluatorCollection.IsEmptyAsync());
        //    } while (
        //        (!context.InteractionCollection.IsEmpty() ||
        //        !context.EvaluatorCollection.IsEmpty()) &&
        //        !context.IsCancellationRequested);

        //    if (context.IsCancellationRequested) return;
        //    context.EvaluatorCollection.CompleteAdding();
        //    context.InteractionCollection.CompleteAdding();
        //}

        public async Task<bool> IsEmptyAsync(CancellationToken cancellationToken)
        {
            // Lock our mutex
            using (await _mutex.LockAsync().ConfigureAwait(false))
            {
                // while we are not complete and the collection is not empty wait to be notified that it is.
                while (!_completed.IsCancellationRequested && !Empty)
                    await _completedOrIsEmpty.WaitAsync(cancellationToken).ConfigureAwait(false);

                return Empty;
            }
        }

        public async Task<bool> OutputAvailableAsync(CancellationToken cancellationToken)
        {
            using (await _mutex.LockAsync().ConfigureAwait(false))
            {
                while (!_completed.IsCancellationRequested && Empty)
                    await _completedOrNotEmpty.WaitAsync(cancellationToken).ConfigureAwait(false);

                return !Empty;
            }
        }

        //public bool TryAdd(T item)
        //{
        //    var ret = _collection.TryAdd(item);
        //    _completedOrIsEmpty.NotifyAll();
        //    _completedOrNotEmpty.NotifyAll();
        //    return ret;
        //}

        ///// <summary>
        ///// Tries to take an item from the collection.
        ///// </summary>
        ///// <returns></returns>
        //public T Peek()
        //{
        //    return _collection.FirstOrDefault();
        //}

        //public async Task<T> PopAsync()
        //{
        //    var ret = await PopAsync(_cancelledOrCompleted.Token).ConfigureAwait(false);
        //    _completedOrIsEmpty.NotifyAll();
        //    _completedOrNotEmpty.NotifyAll();
        //    return ret;
        //}

        //internal async Task<T> PopAsync(CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        using (await _mutex.LockAsync().ConfigureAwait(false))
        //        {
        //            while (!_completed.IsCancellationRequested && Empty)
        //                await _completedOrNotEmpty.WaitAsync(cancellationToken).ConfigureAwait(false);
        //            if (_completed.IsCancellationRequested && Empty)
        //                return default(T);
        //            T item;
        //            if (!_collection.TryTake(out item))
        //                return default(T);
        //            return item;
        //        }
        //    }
        //    catch (OperationCanceledException)
        //    {
        //        return default(T);
        //    }
        //}


    }
}
