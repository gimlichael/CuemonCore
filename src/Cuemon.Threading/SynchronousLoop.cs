﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cuemon.Threading
{
    internal abstract class SynchronousLoop<TSource> : Loop<AsyncTaskFactoryOptions>
    {
        protected SynchronousLoop(Action<AsyncTaskFactoryOptions> setup) : base(setup)
        {
        }

        protected ConcurrentBag<Exception> Exceptions { get; } = new ConcurrentBag<Exception>();

        protected Func<bool> WhileCondition { get; set; }

        public void PrepareExecution<TWorker>(TemplateFactory<TWorker> worker) where TWorker : Template<TSource>
        {
            WhileExecuting(worker);
        }

        protected void WhileExecuting<TWorker>(TemplateFactory<TWorker> worker) where TWorker : Template<TSource>
        {
            if (WhileCondition == null) { throw new InvalidOperationException($"{nameof(WhileCondition)} cannot be null."); }
            while (WhileCondition())
            {
                OnWhileExecutingBeforeFillWorkQueue();
                var queue = new List<Func<Task>>();
                FillWorkQueue(worker, queue);
                if (queue.Count == 0) { break; }
                Process(queue);
            }
            if (!Exceptions.IsEmpty) { throw new AggregateException(Exceptions); }
        }

        protected virtual void OnWhileExecutingBeforeFillWorkQueue()
        {
        }

        protected abstract void FillWorkQueue<TWorker>(TemplateFactory<TWorker> worker, IList<Func<Task>> queue) where TWorker : Template<TSource>;

        protected void Process(IList<Func<Task>> queue)
        {
            try
            {
                Task.WaitAll(queue.Select(func => func()).ToArray(), Options.CancellationToken);
            }
            catch (Exception e)
            {
                Exceptions.Add(e);
            }
        }
    }
}