﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cuemon.Threading
{
    public static partial class AdvancedParallelFactory
    {
        /// <summary>
        /// Executes a parallel for loop that offers control of the loop control variable and loop sections.
        /// </summary>
        /// <typeparam name="TNumber">The type of the number used with the loop control variable.</typeparam>
        /// <param name="from">The initial value of the loop control variable.</param>
        /// <param name="relation">The relation between the loop control variable <paramref name="from"/> and <paramref name="to"/>.</param>
        /// <param name="to">The conditional value of the loop control variable.</param>
        /// <param name="assignment">The assignment statement of the loop control variable using <paramref name="step"/>.</param>
        /// <param name="step">The value to assign the loop control variable.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="condition">The function delegate that represents the condition section of the for loop. Default value is <see cref="Condition{T}"/>.</param>
        /// <param name="iterator">The function delegate that represents the iterator section of the for loop. Default value is <see cref="Iterator{T}"/>.</param>
        /// <param name="setup">The <see cref="AsyncTaskFactoryOptions"/> which may be configured.</param>
        public static void For<TNumber>(TNumber from, RelationalOperator relation, TNumber to, AssignmentOperator assignment, TNumber step, Action<TNumber> worker, Func<TNumber, RelationalOperator, TNumber, bool> condition = null, Func<TNumber, AssignmentOperator, TNumber, TNumber> iterator = null, Action<AsyncTaskFactoryOptions> setup = null)
            where TNumber : struct, IComparable<TNumber>, IEquatable<TNumber>, IConvertible
        {
            Calculator.ValidAsNumericOperand<TNumber>();
            Validator.ThrowIfNull(worker, nameof(worker));
            ForCore(from, relation, to, assignment, step, ActionFactory.Create(worker, from), condition, iterator, setup);
        }

        /// <summary>
        /// Executes a parallel for loop that offers control of the loop control variable and loop sections.
        /// </summary>
        /// <typeparam name="TNumber">The type of the number used with the loop control variable.</typeparam>
        /// <typeparam name="T">The type of the parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <param name="from">The initial value of the loop control variable.</param>
        /// <param name="relation">The relation between the loop control variable <paramref name="from"/> and <paramref name="to"/>.</param>
        /// <param name="to">The conditional value of the loop control variable.</param>
        /// <param name="assignment">The assignment statement of the loop control variable using <paramref name="step"/>.</param>
        /// <param name="step">The value to assign the loop control variable.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg">The parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="condition">The function delegate that represents the condition section of the for loop. Default value is <see cref="Condition{T}"/>.</param>
        /// <param name="iterator">The function delegate that represents the iterator section of the for loop. Default value is <see cref="Iterator{T}"/>.</param>
        /// <param name="setup">The <see cref="AsyncTaskFactoryOptions"/> which may be configured.</param>
        public static void For<TNumber, T>(TNumber from, RelationalOperator relation, TNumber to, AssignmentOperator assignment, TNumber step, Action<TNumber, T> worker, T arg, Func<TNumber, RelationalOperator, TNumber, bool> condition = null, Func<TNumber, AssignmentOperator, TNumber, TNumber> iterator = null, Action<AsyncTaskFactoryOptions> setup = null)
            where TNumber : struct, IComparable<TNumber>, IEquatable<TNumber>, IConvertible
        {
            Calculator.ValidAsNumericOperand<TNumber>();
            Validator.ThrowIfNull(worker, nameof(worker));
            ForCore(from, relation, to, assignment, step, ActionFactory.Create(worker, from, arg), condition, iterator, setup);
        }

        /// <summary>
        /// Executes a parallel for loop that offers control of the loop control variable and loop sections.
        /// </summary>
        /// <typeparam name="TNumber">The type of the number used with the loop control variable.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <param name="from">The initial value of the loop control variable.</param>
        /// <param name="relation">The relation between the loop control variable <paramref name="from"/> and <paramref name="to"/>.</param>
        /// <param name="to">The conditional value of the loop control variable.</param>
        /// <param name="assignment">The assignment statement of the loop control variable using <paramref name="step"/>.</param>
        /// <param name="step">The value to assign the loop control variable.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg1">The first parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg2">The second parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="condition">The function delegate that represents the condition section of the for loop. Default value is <see cref="Condition{T}"/>.</param>
        /// <param name="iterator">The function delegate that represents the iterator section of the for loop. Default value is <see cref="Iterator{T}"/>.</param>
        /// <param name="setup">The <see cref="AsyncTaskFactoryOptions"/> which may be configured.</param>
        public static void For<TNumber, T1, T2>(TNumber from, RelationalOperator relation, TNumber to, AssignmentOperator assignment, TNumber step, Action<TNumber, T1, T2> worker, T1 arg1, T2 arg2, Func<TNumber, RelationalOperator, TNumber, bool> condition = null, Func<TNumber, AssignmentOperator, TNumber, TNumber> iterator = null, Action<AsyncTaskFactoryOptions> setup = null)
            where TNumber : struct, IComparable<TNumber>, IEquatable<TNumber>, IConvertible
        {
            Calculator.ValidAsNumericOperand<TNumber>();
            Validator.ThrowIfNull(worker, nameof(worker));
            ForCore(from, relation, to, assignment, step, ActionFactory.Create(worker, from, arg1, arg2), condition, iterator, setup);
        }

        /// <summary>
        /// Executes a parallel for loop that offers control of the loop control variable and loop sections.
        /// </summary>
        /// <typeparam name="TNumber">The type of the number used with the loop control variable.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <param name="from">The initial value of the loop control variable.</param>
        /// <param name="relation">The relation between the loop control variable <paramref name="from"/> and <paramref name="to"/>.</param>
        /// <param name="to">The conditional value of the loop control variable.</param>
        /// <param name="assignment">The assignment statement of the loop control variable using <paramref name="step"/>.</param>
        /// <param name="step">The value to assign the loop control variable.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg1">The first parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg2">The second parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg3">The third parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="condition">The function delegate that represents the condition section of the for loop. Default value is <see cref="Condition{T}"/>.</param>
        /// <param name="iterator">The function delegate that represents the iterator section of the for loop. Default value is <see cref="Iterator{T}"/>.</param>
        /// <param name="setup">The <see cref="AsyncTaskFactoryOptions"/> which may be configured.</param>
        public static void For<TNumber, T1, T2, T3>(TNumber from, RelationalOperator relation, TNumber to, AssignmentOperator assignment, TNumber step, Action<TNumber, T1, T2, T3> worker, T1 arg1, T2 arg2, T3 arg3, Func<TNumber, RelationalOperator, TNumber, bool> condition = null, Func<TNumber, AssignmentOperator, TNumber, TNumber> iterator = null, Action<AsyncTaskFactoryOptions> setup = null)
            where TNumber : struct, IComparable<TNumber>, IEquatable<TNumber>, IConvertible
        {
            Calculator.ValidAsNumericOperand<TNumber>();
            Validator.ThrowIfNull(worker, nameof(worker));
            ForCore(from, relation, to, assignment, step, ActionFactory.Create(worker, from, arg1, arg2, arg3), condition, iterator, setup);
        }

        /// <summary>
        /// Executes a parallel for loop that offers control of the loop control variable and loop sections.
        /// </summary>
        /// <typeparam name="TNumber">The type of the number used with the loop control variable.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <param name="from">The initial value of the loop control variable.</param>
        /// <param name="relation">The relation between the loop control variable <paramref name="from"/> and <paramref name="to"/>.</param>
        /// <param name="to">The conditional value of the loop control variable.</param>
        /// <param name="assignment">The assignment statement of the loop control variable using <paramref name="step"/>.</param>
        /// <param name="step">The value to assign the loop control variable.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg1">The first parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg2">The second parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg3">The third parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg4">The fourth parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="condition">The function delegate that represents the condition section of the for loop. Default value is <see cref="Condition{T}"/>.</param>
        /// <param name="iterator">The function delegate that represents the iterator section of the for loop. Default value is <see cref="Iterator{T}"/>.</param>
        /// <param name="setup">The <see cref="AsyncTaskFactoryOptions"/> which may be configured.</param>
        public static void For<TNumber, T1, T2, T3, T4>(TNumber from, RelationalOperator relation, TNumber to, AssignmentOperator assignment, TNumber step, Action<TNumber, T1, T2, T3, T4> worker, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Func<TNumber, RelationalOperator, TNumber, bool> condition = null, Func<TNumber, AssignmentOperator, TNumber, TNumber> iterator = null, Action<AsyncTaskFactoryOptions> setup = null)
            where TNumber : struct, IComparable<TNumber>, IEquatable<TNumber>, IConvertible
        {
            Calculator.ValidAsNumericOperand<TNumber>();
            Validator.ThrowIfNull(worker, nameof(worker));
            ForCore(from, relation, to, assignment, step, ActionFactory.Create(worker, from, arg1, arg2, arg3, arg4), condition, iterator, setup);
        }

        /// <summary>
        /// Executes a parallel for loop that offers control of the loop control variable and loop sections.
        /// </summary>
        /// <typeparam name="TNumber">The type of the number used with the loop control variable.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <param name="from">The initial value of the loop control variable.</param>
        /// <param name="relation">The relation between the loop control variable <paramref name="from"/> and <paramref name="to"/>.</param>
        /// <param name="to">The conditional value of the loop control variable.</param>
        /// <param name="assignment">The assignment statement of the loop control variable using <paramref name="step"/>.</param>
        /// <param name="step">The value to assign the loop control variable.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg1">The first parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg2">The second parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg3">The third parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg4">The fourth parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg5">The fifth parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="condition">The function delegate that represents the condition section of the for loop. Default value is <see cref="Condition{T}"/>.</param>
        /// <param name="iterator">The function delegate that represents the iterator section of the for loop. Default value is <see cref="Iterator{T}"/>.</param>
        /// <param name="setup">The <see cref="AsyncTaskFactoryOptions"/> which may be configured.</param>
        public static void For<TNumber, T1, T2, T3, T4, T5>(TNumber from, RelationalOperator relation, TNumber to, AssignmentOperator assignment, TNumber step, Action<TNumber, T1, T2, T3, T4, T5> worker, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Func<TNumber, RelationalOperator, TNumber, bool> condition = null, Func<TNumber, AssignmentOperator, TNumber, TNumber> iterator = null, Action<AsyncTaskFactoryOptions> setup = null)
            where TNumber : struct, IComparable<TNumber>, IEquatable<TNumber>, IConvertible
        {
            Calculator.ValidAsNumericOperand<TNumber>();
            Validator.ThrowIfNull(worker, nameof(worker));
            ForCore(from, relation, to, assignment, step, ActionFactory.Create(worker, from, arg1, arg2, arg3, arg4, arg5), condition, iterator, setup);
        }

        private static void ForCore<TWorker, TNumber>(TNumber from, RelationalOperator relation, TNumber to, AssignmentOperator assignment, TNumber step, ActionFactory<TWorker> workerFactory, Func<TNumber, RelationalOperator, TNumber, bool> condition, Func<TNumber, AssignmentOperator, TNumber, TNumber> iterator, Action<AsyncTaskFactoryOptions> setup)
            where TWorker : Template<TNumber>
            where TNumber : struct, IComparable<TNumber>, IEquatable<TNumber>, IConvertible
        {
            if (condition == null) { condition = Condition; }
            if (iterator == null) { iterator = Iterator; }

            var options = Patterns.Configure(setup);
            var exceptions = new ConcurrentBag<Exception>();

            TNumber processed = default;
            while (true)
            {
                var workChunks = options.PartitionSize;
                var queue = new List<Task>();
                for (var i = from; condition(i, relation, to); i = iterator(i, assignment, step))
                {
                    if (options.CancellationToken.IsCancellationRequested)
                    {
                        queue.Clear();
                        break;
                    }
                    queue.Add(Task.Factory.StartNew(j =>
                    {
                        var shallowWorkerFactory = workerFactory.Clone();
                        try
                        {
                            shallowWorkerFactory.GenericArguments.Arg1 = (TNumber)j;
                            shallowWorkerFactory.ExecuteMethod();
                        }
                        catch (Exception e)
                        {
                            exceptions.Add(e);
                        }
                    }, i, options.CancellationToken, options.CreationOptions, options.Scheduler));

                    processed = i;
                    workChunks--;
                    
                    if (workChunks == 0) { break; }
                }
                from = Calculator.Calculate(processed, assignment, step);
                if (queue.Count == 0) { break; }

                if (options.CancellationToken.IsCancellationRequested)
                {
                    queue.Clear();
                    break;
                }

                try
                {
                    Task.WaitAll(queue.ToArray(), options.CancellationToken);
                }
                catch (OperationCanceledException oce)
                {
                    exceptions.Add(oce);
                }

                if (workChunks > 1) { break; }
            }
            if (exceptions.Count > 0) { throw new AggregateException(exceptions); }
        }
    }
}