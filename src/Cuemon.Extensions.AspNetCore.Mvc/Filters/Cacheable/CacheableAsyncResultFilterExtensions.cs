﻿using System;
using System.Collections.Generic;
using Cuemon.AspNetCore.Mvc.Filters.Cacheable;
using Cuemon.Reflection;

namespace Cuemon.Extensions.AspNetCore.Mvc.Filters.Cacheable
{
    /// <summary>
    /// Extension methods for the <see cref="ICacheableAsyncResultFilter"/> interface.
    /// </summary>
    public static class CacheableAsyncResultFilterExtensions
    {
        /// <summary>
        /// Adds a HTTP related filter to the list.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="ICacheableAsyncResultFilter"/>.</typeparam>
        /// <typeparam name="TOptions">The type of delegate setup to configure <typeparamref name="T"/>.</typeparam>
        /// <param name="filters">The list of cache related HTTP head filters.</param>
        /// <param name="setup">The <see cref="Action{TOptions}"/> which need to be configured.</param>
        public static void AddFilter<T, TOptions>(this IList<ICacheableAsyncResultFilter> filters, Action<TOptions> setup) 
            where T : ICacheableAsyncResultFilter
            where TOptions : class, new()
        {
            filters.Add(ActivatorFactory.CreateInstance<Action<TOptions>, T>(setup));
        }

        /// <summary>
        /// Inserts a HTTP related filter to the list at the specified <paramref name="index" />.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="ICacheableAsyncResultFilter"/>.</typeparam>
        /// <typeparam name="TOptions">The type of delegate setup to configure <typeparamref name="T"/>.</typeparam>
        /// <param name="filters">The list of cache related HTTP head filters.</param>
        /// <param name="index">The zero-based index at which a HTTP related filter should be inserted.</param>
        /// <param name="setup">The <see cref="Action{TOptions}"/> which need to be configured.</param>
        public static void InsertFilter<T, TOptions>(this IList<ICacheableAsyncResultFilter> filters, int index, Action<TOptions> setup) 
            where T : ICacheableAsyncResultFilter
            where TOptions : class, new()
        {
            filters.Insert(index, ActivatorFactory.CreateInstance<Action<TOptions>, T>(setup));
        }

        /// <summary>
        /// Adds an <see cref="HttpEntityTagHeaderFilter" /> filter to the list.
        /// </summary>
        /// <param name="filters">The list of cache related HTTP filters.</param>
        /// <param name="setup">The <see cref="HttpEntityTagHeaderOptions"/> which need to be configured.</param>
        public static void AddEntityTagHeader(this IList<ICacheableAsyncResultFilter> filters, Action<HttpEntityTagHeaderOptions> setup = null)
        {
            filters.AddFilter<HttpEntityTagHeaderFilter, HttpEntityTagHeaderOptions>(setup);
        }

        /// <summary>
        /// Adds an <see cref="HttpLastModifiedHeaderFilter"/> filter to the list.
        /// </summary>
        /// <param name="filters">The list of cache related HTTP filters.</param>
        /// <param name="setup">The <see cref="HttpLastModifiedHeaderOptions"/> which need to be configured.</param>
        public static void AddLastModifiedHeader(this IList<ICacheableAsyncResultFilter> filters, Action<HttpLastModifiedHeaderOptions> setup = null)
        {
            filters.InsertFilter<HttpLastModifiedHeaderFilter, HttpLastModifiedHeaderOptions>(0, setup);
        }
    }
}