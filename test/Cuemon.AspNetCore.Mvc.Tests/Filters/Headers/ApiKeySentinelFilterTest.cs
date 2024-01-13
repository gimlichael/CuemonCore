﻿using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Cuemon.AspNetCore.Http.Headers;
using Cuemon.AspNetCore.Mvc.Assets;
using Cuemon.Extensions.AspNetCore.Mvc.Formatters.Newtonsoft.Json;
using Cuemon.Extensions.Xunit;
using Cuemon.Extensions.Xunit.Hosting.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Xunit;
using Xunit.Abstractions;

namespace Cuemon.AspNetCore.Mvc.Filters.Headers
{
	public class ApiKeySentinelFilterTest : Test
	{
		public ApiKeySentinelFilterTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public async Task OnAuthorizationAsync_ShouldProvideForbiddenResult_WithBadRequestStatus()
		{
			using (var filter = WebApplicationTestFactory.Create(services =>
				   {
					   services.AddControllers(o =>
					   {
						   o.Filters.Add<ApiKeySentinelFilter>();
					   }).AddApplicationPart(typeof(FakeController).Assembly)
						   .AddNewtonsoftJson()
						   .AddNewtonsoftJsonFormatters();
				   }, app =>
				   {
					   app.UseRouting();
					   app.UseEndpoints(routes => { routes.MapControllers(); });
				   }))
			{
				var options = filter.ServiceProvider.GetRequiredService<IOptions<ApiKeySentinelOptions>>();
				var client = filter.Host.GetTestClient();

				var result = await client.GetAsync("/fake/it");

				Assert.Contains(options.Value.GenericClientMessage, await result.Content.ReadAsStringAsync());
				Assert.Equal((int)result.StatusCode, StatusCodes.Status400BadRequest);
			}
		}

		[Fact]
		public async Task OnAuthorizationAsync_ShouldProvideForbiddenResult_WithForbiddenStatus()
		{
			using (var filter = WebApplicationTestFactory.Create(services =>
				   {
					   services.Configure<ApiKeySentinelOptions>(o =>
					   {
						   o.AllowedKeys.Add("Cuemon-Key");
					   });
					   services.AddControllers(o =>
						   {
							   o.Filters.Add<ApiKeySentinelFilter>();
						   }).AddApplicationPart(typeof(FakeController).Assembly)
						   .AddNewtonsoftJson()
						   .AddNewtonsoftJsonFormatters();
				   }, app =>
				   {
					   app.UseRouting();
					   app.UseEndpoints(routes => { routes.MapControllers(); });
				   }))
			{
				var options = filter.ServiceProvider.GetRequiredService<IOptions<ApiKeySentinelOptions>>();
				var client = filter.Host.GetTestClient();
				client.DefaultRequestHeaders.Add(options.Value.HeaderName, "Invalid-Key");

				var result = await client.GetAsync("/fake/it");

				Assert.Contains(options.Value.ForbiddenMessage, await result.Content.ReadAsStringAsync());
				Assert.Equal(StatusCodes.Status403Forbidden, (int)result.StatusCode);

				Assert.True(options.Value.AllowedKeys.Any());
			}
		}

		[Fact]
		public async Task OnAuthorizationAsync_ShouldProvideForbiddenResult_WithCustom_ClientError()
		{
			using (var filter = WebApplicationTestFactory.Create(services =>
			{
				services.Configure<ApiKeySentinelOptions>(o =>
				{
					o.UseGenericResponse = true;
					o.GenericClientStatusCode = HttpStatusCode.NotFound;
					o.GenericClientMessage = "Not Found";
					o.AllowedKeys.Add("Cuemon-Key");
				});
				services.AddControllers(o => { o.Filters.Add<ApiKeySentinelFilter>(); }).AddApplicationPart(typeof(FakeController).Assembly);
			}, app =>
				   {
					   app.UseRouting();
					   app.UseEndpoints(routes => { routes.MapControllers(); });
				   }))
			{
				var options = filter.ServiceProvider.GetRequiredService<IOptions<ApiKeySentinelOptions>>();
				var client = filter.Host.GetTestClient();
				client.DefaultRequestHeaders.Add(options.Value.HeaderName, "Invalid-Key");

				var result = await client.GetAsync("/fake/it");

				Assert.Equal("Not Found", options.Value.GenericClientMessage);
				Assert.Equal(StatusCodes.Status404NotFound, (int)options.Value.GenericClientStatusCode);
				Assert.True(options.Value.UseGenericResponse);
				Assert.Collection(options.Value.AllowedKeys, key => Assert.Equal("Cuemon-Key", key));

				Assert.Equal(options.Value.GenericClientMessage, await result.Content.ReadAsStringAsync());
				Assert.Equal(options.Value.GenericClientStatusCode, result.StatusCode);
			}
		}

		[Fact]
		public async Task OnAuthorizationAsync_ShouldProvideForbiddenResult_WithCustom_ForbiddenMessage()
		{
			using (var filter = WebApplicationTestFactory.Create(services =>
				   {
					   services.Configure<ApiKeySentinelOptions>(o =>
					   {
						   o.ForbiddenMessage = "Stop. Halt. Adgang nægtet!";
						   o.AllowedKeys.Add("Cuemon-Key");
					   });
					   services.AddControllers(o => { o.Filters.Add<ApiKeySentinelFilter>(); }).AddApplicationPart(typeof(FakeController).Assembly);
				   }, app =>
				   {
					   app.UseRouting();
					   app.UseEndpoints(routes => { routes.MapControllers(); });
				   }))
			{
				var options = filter.ServiceProvider.GetRequiredService<IOptions<ApiKeySentinelOptions>>();
				var client = filter.Host.GetTestClient();
				client.DefaultRequestHeaders.Add(options.Value.HeaderName, "Invalid-Key");

				var result = await client.GetAsync("/fake/it");

				Assert.Equal("Stop. Halt. Adgang nægtet!", options.Value.ForbiddenMessage);
				Assert.False(options.Value.UseGenericResponse);
				Assert.Collection(options.Value.AllowedKeys, key => Assert.Equal("Cuemon-Key", key));

				Assert.Equal(options.Value.ForbiddenMessage, await result.Content.ReadAsStringAsync());
				Assert.Equal(HttpStatusCode.Forbidden, result.StatusCode);
			}
		}

		[Fact]
		public async Task OnAuthorizationAsync_ShouldProvideOkResult_ShouldAllowRequestAfterBeingValidated()
		{
			using (var filter = WebApplicationTestFactory.Create(services =>
			{
				services.Configure<ApiKeySentinelOptions>(o =>
				{
					o.AllowedKeys.Add("Cuemon-Key");
				});
				services.AddControllers(o => { o.Filters.Add<ApiKeySentinelFilter>(); }).AddApplicationPart(typeof(FakeController).Assembly);
			}, app =>
				   {
					   app.UseRouting();
					   app.UseEndpoints(routes => { routes.MapControllers(); });
				   }))
			{
				var options = filter.ServiceProvider.GetRequiredService<IOptions<ApiKeySentinelOptions>>();
				var client = filter.Host.GetTestClient();
				client.DefaultRequestHeaders.Add(options.Value.HeaderName, "Cuemon-Key");

				var result = await client.GetAsync("/fake/it");

				Assert.Equal(StatusCodes.Status200OK, (int)result.StatusCode);
			}
		}

		[Fact]
		public async Task OnAuthorizationAsync_ShouldProvideForbiddenResult_UsingApiKeySentinelAttribute_And_ServicesHavingApiKeySentinelFilter()
		{
			using (var filter = WebApplicationTestFactory.Create(services =>
			       {
				       services.Configure<ApiKeySentinelOptions>(o =>
				       {
					       o.AllowedKeys.Add("Cuemon-Key");
				       });
					   services.AddSingleton<ApiKeySentinelFilter>();
				       services.AddControllers().AddApplicationPart(typeof(FakeController).Assembly);
			       }, app =>
			       {
				       app.UseRouting();
				       app.UseEndpoints(routes => { routes.MapControllers(); });
			       }))
			{
				var options = filter.ServiceProvider.GetRequiredService<IOptions<ApiKeySentinelOptions>>();
				var client = filter.Host.GetTestClient();
				client.DefaultRequestHeaders.Add(options.Value.HeaderName, "Invalid-Key");

				var result = await client.GetAsync("/fake/it");

				Assert.Equal(StatusCodes.Status200OK, (int)result.StatusCode);

				result = await client.GetAsync("/fake/it-apikeysentinelattribute");

				Assert.Equal(StatusCodes.Status403Forbidden, (int)result.StatusCode);
			}
		}
	}
}