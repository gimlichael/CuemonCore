﻿using System;
using System.Threading.Tasks;
using Cuemon.AspNetCore.Infrastructure;
using Cuemon.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Cuemon.AspNetCore.Http.Headers
{
    /// <summary>
    /// Provides a HTTP User-Agent sentinel middleware implementation for ASP.NET Core.
    /// </summary>
    public class UserAgentSentinelMiddleware : ConfigurableMiddleware<UserAgentSentinelOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserAgentSentinelMiddleware"/> class.
        /// </summary>
        /// <param name="next">The delegate of the request pipeline to invoke.</param>
        /// <param name="setup">The <see cref="UserAgentSentinelOptions" /> which need to be configured.</param>
        public UserAgentSentinelMiddleware(RequestDelegate next, IOptions<UserAgentSentinelOptions> setup) : base(next, setup)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAgentSentinelMiddleware"/> class.
        /// </summary>
        /// <param name="next">The delegate of the request pipeline to invoke.</param>
        /// <param name="setup">The <see cref="UserAgentSentinelOptions" /> which need to be configured.</param>
        public UserAgentSentinelMiddleware(RequestDelegate next, Action<UserAgentSentinelOptions> setup) : base(next, setup)
        {
        }

        /// <summary>
        /// Executes the <see cref="UserAgentSentinelMiddleware" />.
        /// </summary>
        /// <param name="context">The context of the current request.</param>
        /// <returns>A task that represents the execution of this middleware.</returns>
        public override async Task InvokeAsync(HttpContext context)
        {
            var exception = false;
            try
            {
                await AspNetCoreInfrastructure.InvokeUserAgentSentinelAsync(context, Options, async (message, response) =>
                {
                    response.StatusCode = (int) message.StatusCode;
                    Decorator.Enclose(response.Headers).TryAddOrUpdateHeaders(message.Headers);
                    await Decorator.Enclose(response.Body).WriteAsync(await message.Content.ReadAsByteArrayAsync());
                }).ConfigureAwait(false);
            }
            catch (UserAgentException)
            {
                exception = true;
            }
            if (!exception) { await Next(context).ConfigureAwait(false); }
        }
    }
}