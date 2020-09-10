﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cuemon.Threading
{
    public static partial class ParallelFactory
    {
        /// <summary>
        /// Executes a parallel for loop where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="worker"/>.</typeparam>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="setup">The <see cref="AsyncWorkloadOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.
        /// The task result contains an <see cref="IReadOnlyCollection{TResult}" /> where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.</returns>
        public static Task<IReadOnlyCollection<TResult>> ForResultAsync<TResult>(int fromInclusive, int toExclusive, Func<int, CancellationToken, Task<TResult>> worker, Action<AsyncWorkloadOptions> setup = null)
        {
            Validator.ThrowIfNull(worker, nameof(worker));
            return AdvancedParallelFactory.ForResultAsync(new ForLoopRuleset<int>(fromInclusive, toExclusive, 1), worker, setup);
        }

        /// <summary>
        /// Executes a parallel for loop where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="worker"/>.</typeparam>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg">The parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="setup">The <see cref="AsyncWorkloadOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.
        /// The task result contains an <see cref="IReadOnlyCollection{TResult}" /> where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.</returns>
        public static Task<IReadOnlyCollection<TResult>> ForResultAsync<T, TResult>(int fromInclusive, int toExclusive, Func<int, T, CancellationToken, Task<TResult>> worker, T arg, Action<AsyncWorkloadOptions> setup = null)
        {
            Validator.ThrowIfNull(worker, nameof(worker));
            return AdvancedParallelFactory.ForResultAsync(new ForLoopRuleset<int>(fromInclusive, toExclusive, 1), worker, arg, setup);
        }

        /// <summary>
        /// Executes a parallel for loop where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="worker"/>.</typeparam>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg1">The first parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg2">The second parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="setup">The <see cref="AsyncWorkloadOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.
        /// The task result contains an <see cref="IReadOnlyCollection{TResult}" /> where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.</returns>
        public static Task<IReadOnlyCollection<TResult>> ForResultAsync<T1, T2, TResult>(int fromInclusive, int toExclusive, Func<int, T1, T2, CancellationToken, Task<TResult>> worker, T1 arg1, T2 arg2, Action<AsyncWorkloadOptions> setup = null)
        {
            Validator.ThrowIfNull(worker, nameof(worker));
            return AdvancedParallelFactory.ForResultAsync(new ForLoopRuleset<int>(fromInclusive, toExclusive, 1), worker, arg1, arg2, setup);
        }

        /// <summary>
        /// Executes a parallel for loop where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="worker"/>.</typeparam>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg1">The first parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg2">The second parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg3">The third parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="setup">The <see cref="AsyncWorkloadOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.
        /// The task result contains an <see cref="IReadOnlyCollection{TResult}" /> where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.</returns>
        public static Task<IReadOnlyCollection<TResult>> ForResultAsync<T1, T2, T3, TResult>(int fromInclusive, int toExclusive, Func<int, T1, T2, T3, CancellationToken, Task<TResult>> worker, T1 arg1, T2 arg2, T3 arg3, Action<AsyncWorkloadOptions> setup = null)
        {
            Validator.ThrowIfNull(worker, nameof(worker));
            return AdvancedParallelFactory.ForResultAsync(new ForLoopRuleset<int>(fromInclusive, toExclusive, 1), worker, arg1, arg2, arg3, setup);
        }

        /// <summary>
        /// Executes a parallel for loop where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="worker"/>.</typeparam>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg1">The first parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg2">The second parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg3">The third parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg4">The fourth parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="setup">The <see cref="AsyncWorkloadOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.
        /// The task result contains an <see cref="IReadOnlyCollection{TResult}" /> where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.</returns>
        public static Task<IReadOnlyCollection<TResult>> ForResultAsync<T1, T2, T3, T4, TResult>(int fromInclusive, int toExclusive, Func<int, T1, T2, T3, T4, CancellationToken, Task<TResult>> worker, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Action<AsyncWorkloadOptions> setup = null)
        {
            Validator.ThrowIfNull(worker, nameof(worker));
            return AdvancedParallelFactory.ForResultAsync(new ForLoopRuleset<int>(fromInclusive, toExclusive, 1), worker, arg1, arg2, arg3, arg4, setup);
        }

        /// <summary>
        /// Executes a parallel for loop where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="worker"/>.</typeparam>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg1">The first parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg2">The second parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg3">The third parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg4">The fourth parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg5">The fifth parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="setup">The <see cref="AsyncWorkloadOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.
        /// The task result contains an <see cref="IReadOnlyCollection{TResult}" /> where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.</returns>
        public static Task<IReadOnlyCollection<TResult>> ForResultAsync<T1, T2, T3, T4, T5, TResult>(int fromInclusive, int toExclusive, Func<int, T1, T2, T3, T4, T5, CancellationToken, Task<TResult>> worker, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Action<AsyncWorkloadOptions> setup = null)
        {
            Validator.ThrowIfNull(worker, nameof(worker));
            return AdvancedParallelFactory.ForResultAsync(new ForLoopRuleset<int>(fromInclusive, toExclusive, 1), worker, arg1, arg2, arg3, arg4, arg5, setup);
        }

        /// <summary>
        /// Executes a parallel for loop where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="worker"/>.</typeparam>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="setup">The <see cref="AsyncWorkloadOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.
        /// The task result contains an <see cref="IReadOnlyCollection{TResult}" /> where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.</returns>
        public static Task<IReadOnlyCollection<TResult>> ForResultAsync<TResult>(long fromInclusive, long toExclusive, Func<long, CancellationToken, Task<TResult>> worker, Action<AsyncWorkloadOptions> setup = null)
        {
            Validator.ThrowIfNull(worker, nameof(worker));
            return AdvancedParallelFactory.ForResultAsync(new ForLoopRuleset<long>(fromInclusive, toExclusive, 1), worker, setup: setup);
        }

        /// <summary>
        /// Executes a parallel for loop where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="worker"/>.</typeparam>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg">The parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="setup">The <see cref="AsyncWorkloadOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.
        /// The task result contains an <see cref="IReadOnlyCollection{TResult}" /> where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.</returns>
        public static Task<IReadOnlyCollection<TResult>> ForResultAsync<T, TResult>(long fromInclusive, long toExclusive, Func<long, T, CancellationToken, Task<TResult>> worker, T arg, Action<AsyncWorkloadOptions> setup = null)
        {
            Validator.ThrowIfNull(worker, nameof(worker));
            return AdvancedParallelFactory.ForResultAsync(new ForLoopRuleset<long>(fromInclusive, toExclusive, 1), worker, arg, setup: setup);
        }

        /// <summary>
        /// Executes a parallel for loop where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="worker"/>.</typeparam>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg1">The first parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg2">The second parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="setup">The <see cref="AsyncWorkloadOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.
        /// The task result contains an <see cref="IReadOnlyCollection{TResult}" /> where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.</returns>
        public static Task<IReadOnlyCollection<TResult>> ForResultAsync<T1, T2, TResult>(long fromInclusive, long toExclusive, Func<long, T1, T2, CancellationToken, Task<TResult>> worker, T1 arg1, T2 arg2, Action<AsyncWorkloadOptions> setup = null)
        {
            Validator.ThrowIfNull(worker, nameof(worker));
            return AdvancedParallelFactory.ForResultAsync(new ForLoopRuleset<long>(fromInclusive, toExclusive, 1), worker, arg1, arg2, setup: setup);
        }

        /// <summary>
        /// Executes a parallel for loop where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="worker"/>.</typeparam>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg1">The first parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg2">The second parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg3">The third parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="setup">The <see cref="AsyncWorkloadOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.
        /// The task result contains an <see cref="IReadOnlyCollection{TResult}" /> where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.</returns>
        public static Task<IReadOnlyCollection<TResult>> ForResultAsync<T1, T2, T3, TResult>(long fromInclusive, long toExclusive, Func<long, T1, T2, T3, CancellationToken, Task<TResult>> worker, T1 arg1, T2 arg2, T3 arg3, Action<AsyncWorkloadOptions> setup = null)
        {
            Validator.ThrowIfNull(worker, nameof(worker));
            return AdvancedParallelFactory.ForResultAsync(new ForLoopRuleset<long>(fromInclusive, toExclusive, 1), worker, arg1, arg2, arg3, setup: setup);
        }

        /// <summary>
        /// Executes a parallel for loop where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="worker"/>.</typeparam>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg1">The first parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg2">The second parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg3">The third parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg4">The fourth parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="setup">The <see cref="AsyncWorkloadOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.
        /// The task result contains an <see cref="IReadOnlyCollection{TResult}" /> where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.</returns>
        public static Task<IReadOnlyCollection<TResult>> ForResultAsync<T1, T2, T3, T4, TResult>(long fromInclusive, long toExclusive, Func<long, T1, T2, T3, T4, CancellationToken, Task<TResult>> worker, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Action<AsyncWorkloadOptions> setup = null)
        {
            Validator.ThrowIfNull(worker, nameof(worker));
            return AdvancedParallelFactory.ForResultAsync(new ForLoopRuleset<long>(fromInclusive, toExclusive, 1), worker, arg1, arg2, arg3, arg4, setup: setup);
        }

        /// <summary>
        /// Executes a parallel for loop where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the function delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="worker"/>.</typeparam>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg1">The first parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg2">The second parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg3">The third parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg4">The fourth parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="arg5">The fifth parameter of the function delegate <paramref name="worker" />.</param>
        /// <param name="setup">The <see cref="AsyncWorkloadOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.
        /// The task result contains an <see cref="IReadOnlyCollection{TResult}" /> where the return value of the function delegate <paramref name="worker" /> is stored in the same sequential order as the for loop.</returns>
        public static Task<IReadOnlyCollection<TResult>> ForResultAsync<T1, T2, T3, T4, T5, TResult>(long fromInclusive, long toExclusive, Func<long, T1, T2, T3, T4, T5, CancellationToken, Task<TResult>> worker, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Action<AsyncWorkloadOptions> setup = null)
        {
            Validator.ThrowIfNull(worker, nameof(worker));
            return AdvancedParallelFactory.ForResultAsync(new ForLoopRuleset<long>(fromInclusive, toExclusive, 1), worker, arg1, arg2, arg3, arg4, arg5, setup: setup);
        }
    }
}