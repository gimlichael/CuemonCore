﻿using System.Linq;
using Cuemon.AspNetCore.Authentication.Basic;
using Cuemon.AspNetCore.Authentication.Digest;
using Cuemon.AspNetCore.Authentication.Hmac;
using Cuemon.Extensions.Reflection;
using Cuemon.Extensions.Xunit;
using Cuemon.Extensions.Xunit.Hosting.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;
using Xunit.Abstractions;

namespace Cuemon.Extensions.AspNetCore.Authentication
{
	public class ApplicationBuilderExtensionsTest : Test
	{
		public ApplicationBuilderExtensionsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void UseBasicAuthentication_ShouldAddBasicAuthenticationMiddlewareAndBasicAuthenticationOptions_ToHost()
		{
			using (var host = MiddlewareTestFactory.Create(pipelineSetup: app =>
			       {
				       app.UseBasicAuthentication(o =>
				       {
					       o.RequireSecureConnection = false;
				       });
			       }))
			{
				var options = host.ServiceProvider.GetRequiredService<IOptions<BasicAuthenticationOptions>>();
				var middleware = host.Application.Build();

				Assert.NotNull(options);
				Assert.NotNull(middleware);
				Assert.IsType<BasicAuthenticationOptions>(options.Value);
				Assert.IsType<BasicAuthenticationMiddleware>(middleware.Target);
			}
		}

		[Fact]
		public void UseDigestAuthentication_ShouldAddDigestAuthenticationMiddlewareAndDigestAuthenticationOptions_ToHost()
		{
			using (var host = MiddlewareTestFactory.Create(pipelineSetup: app =>
			       {
				       app.UseDigestAccessAuthentication(o =>
				       {
					       o.RequireSecureConnection = false;
				       });
			       }))
			{
				var options = host.ServiceProvider.GetRequiredService<IOptions<DigestAuthenticationOptions>>();
				var middleware = host.Application.Build();

				Assert.NotNull(options);
				Assert.NotNull(middleware);
				Assert.IsType<DigestAuthenticationOptions>(options.Value);
				Assert.IsType<DigestAuthenticationMiddleware>(middleware.Target!.GetType().GetAllFields().Single(fi => fi.Name == "instance").GetValue(middleware.Target));
			}
		}

		[Fact]
		public void UseHmacAuthentication_ShouldAddHmacAuthenticationMiddlewareAndHmacAuthenticationOptions_ToHost()
		{
			using (var host = MiddlewareTestFactory.Create(pipelineSetup: app =>
			       {
				       app.UseHmacAuthentication(o =>
				       {
					       o.RequireSecureConnection = false;
				       });
			       }))
			{
				var options = host.ServiceProvider.GetRequiredService<IOptions<HmacAuthenticationOptions>>();
				var middleware = host.Application.Build();

				Assert.NotNull(options);
				Assert.NotNull(middleware);
				Assert.IsType<HmacAuthenticationOptions>(options.Value);
				Assert.IsType<HmacAuthenticationMiddleware>(middleware.Target);
			}
		}
	}
}
