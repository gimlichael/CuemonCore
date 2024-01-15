﻿using System;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Cuemon.AspNetCore.Http.Headers;
using Cuemon.AspNetCore.Http.Throttling;
using Cuemon.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace Cuemon.AspNetCore.Http
{
    /// <summary>
    /// Extension methods for the <see cref="HttpContext"/> class hidden behind the <see cref="IDecorator{T}"/> interface.
    /// This API supports the product infrastructure and is not intended to be used directly from your code.
    /// </summary>
    /// <seealso cref="IDecorator{T}"/>
    /// <seealso cref="Decorator{T}"/>
    public static class HttpContextDecoratorExtensions
    {
        private static readonly SemaphoreSlim ThrottleLocker = new(1);

        /// <summary>
        /// Common throttler operation logic for ASP.NET Core and ASP.NET Core MVC. Not intended to be used directly from your code.
        /// </summary>
        /// <param name="decorator">The <see cref="IDecorator{HttpContext}"/> to extend.</param>
        /// <param name="tc">The <see cref="IThrottlingCache"/> implementation.</param>
        /// <param name="options">The configured options.</param>
        public static async Task InvokeThrottlerSentinelAsync(this IDecorator<HttpContext> decorator, IThrottlingCache tc, ThrottlingSentinelOptions options)
        {
            var utcNow = DateTime.UtcNow;
            var throttlingContext = options.ContextResolver?.Invoke(decorator.Inner);
            if (!string.IsNullOrWhiteSpace(throttlingContext))
            {
                ThrottleRequest tr = null;
                try
                {
                    await ThrottleLocker.WaitAsync().ConfigureAwait(false);

                    if (!tc.TryGetValue(throttlingContext, out tr))
                    {
                        tr = new ThrottleRequest(options.Quota);
                        Decorator.Enclose(tc).TryAdd(throttlingContext, tr);
                    }
                    else
                    {
                        tr.Refresh();
                        tr.IncrementTotal();
                    }

                    var window = new DateTimeRange(utcNow, tr.Expires);
                    var delta = window.Duration;
                    var reset = utcNow.Add(delta);
                    Decorator.Enclose(decorator.Inner.Response.Headers).AddOrUpdate(options.RateLimitHeaderName, tr.Quota.RateLimit.ToString(CultureInfo.InvariantCulture));
                    Decorator.Enclose(decorator.Inner.Response.Headers).AddOrUpdate(options.RateLimitRemainingHeaderName, Math.Max(tr.Quota.RateLimit - tr.Total, 0).ToString(CultureInfo.InvariantCulture));
                    if (options.UseRetryAfterHeader) { options.RateLimitResetScope = options.RetryAfterScope; } // if a response contains both the Retry-After and the RateLimit-Reset header fields, the value of RateLimit-Reset MUST be consistent with the one of Retry-After https://tools.ietf.org/id/draft-polli-ratelimit-headers-00.html#providing-ratelimit-headers
                    switch (options.RateLimitResetScope)
                    {
                        case RetryConditionScope.DeltaSeconds:
                            Decorator.Enclose(decorator.Inner.Response.Headers).AddOrUpdate(options.RateLimitResetHeaderName, new RetryConditionHeaderValue(delta).ToString());
                            break;
                        case RetryConditionScope.HttpDate:
                            Decorator.Enclose(decorator.Inner.Response.Headers).AddOrUpdate(options.RateLimitResetHeaderName, new RetryConditionHeaderValue(reset).ToString());
                            break;
                    }
                    if (tr.Total > tr.Quota.RateLimit && tr.Expires > utcNow)
                    {
                        var message = options.ResponseHandler?.Invoke(delta, reset);
                        if (message != null)
                        {
                            throw Decorator.Enclose(new ThrottlingException(await message.Content.ReadAsStringAsync().ConfigureAwait(false), tr.Quota.RateLimit, delta, reset))
                                .AddResponseHeaders(decorator.Inner.Response.Headers)
                                .AddResponseHeaders(message.Headers).Inner;
                        }
                    }
                }
                finally
                {
                    tc[throttlingContext] = tr;
                    ThrottleLocker.Release();
                }
            }
        }

        /// <summary>
        /// Common user agent logic for ASP.NET Core and ASP.NET Core MVC. Not intended to be used directly from your code.
        /// </summary>
        /// <param name="decorator">The <see cref="IDecorator{HttpContext}"/> to extend.</param>
        /// <param name="options">The configured options.</param>
        public static async Task InvokeUserAgentSentinelAsync(this IDecorator<HttpContext> decorator, UserAgentSentinelOptions options)
        {
            var userAgent = decorator.Inner.Request.Headers[HeaderNames.UserAgent].FirstOrDefault();
            if (options.RequireUserAgentHeader)
            {
                var message = options.ResponseHandler?.Invoke(userAgent);
                if (message != null)
                {
                    throw Decorator.Enclose(new UserAgentException((int)message.StatusCode, await message.Content.ReadAsStringAsync().ConfigureAwait(false)))
                        .AddResponseHeaders(decorator.Inner.Response.Headers)
                        .AddResponseHeaders(message.Headers).Inner;
                }
            }
        }

        /// <summary>
        /// Common API key logic for ASP.NET Core and ASP.NET Core MVC. Not intended to be used directly from your code.
        /// </summary>
        /// <param name="decorator">The <see cref="IDecorator{HttpContext}"/> to extend.</param>
        /// <param name="options">The configured options.</param>
        public static async Task InvokeApiKeySentinelAsync(this IDecorator<HttpContext> decorator, ApiKeySentinelOptions options)
        {
            var apiKey = decorator.Inner.Request.Headers[options.HeaderName].FirstOrDefault();
            var message = options.ResponseHandler?.Invoke(apiKey);
            if (message != null)
            {
                throw Decorator.Enclose(new ApiKeyException((int)message.StatusCode, await message.Content.ReadAsStringAsync().ConfigureAwait(false)))
                    .AddResponseHeaders(decorator.Inner.Response.Headers)
                    .AddResponseHeaders(message.Headers).Inner;
            }
        }
    }
}
