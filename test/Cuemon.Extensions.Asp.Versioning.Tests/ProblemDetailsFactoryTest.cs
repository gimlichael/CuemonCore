﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Asp.Versioning;
using Cuemon.AspNetCore.Diagnostics;
using Cuemon.AspNetCore.Http;
using Cuemon.AspNetCore.Mvc.Filters.Diagnostics;
using Cuemon.Diagnostics;
using Cuemon.Extensions.Asp.Versioning.Assets;
using Cuemon.Extensions.AspNetCore.Diagnostics;
using Cuemon.Extensions.AspNetCore.Mvc.Filters;
using Cuemon.Extensions.AspNetCore.Mvc.Formatters.Text.Json;
using Cuemon.Extensions.AspNetCore.Mvc.Formatters.Xml;
using Cuemon.Extensions.Text.Json.Formatters;
using Cuemon.Extensions.Xunit;
using Cuemon.Extensions.Xunit.Hosting.AspNetCore.Mvc;
using Cuemon.Xml.Serialization.Formatters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;
using Xunit.Abstractions;

namespace Cuemon.Extensions.Asp.Versioning
{
    public class ProblemDetailsFactoryTest : Test
    {
        public ProblemDetailsFactoryTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task GetRequest_ShouldFailWithBadRequest_FormattedAsRfc7807_As_b3_IsAnUnknownVersion()
        {
            using (var app = WebApplicationTestFactory.Create(app =>
                   {
                       app.UseRouting();
                       app.UseEndpoints(routes => { routes.MapControllers(); });
                   }, services =>
                   {
                       services.AddControllers().AddApplicationPart(typeof(FakeController).Assembly)
                           .AddJsonFormatters();
                       services.AddRestfulApiVersioning(o =>
                       {
	                       o.UseBuiltInRfc7807 = true;
                           o.ValidAcceptHeaders.Clear();
                       });
                   }))
            {
                var client = app.Host.GetTestClient();
                client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                var sut = await client.GetAsync("/fake/");

                TestOutput.WriteLine(sut.Content.Headers.ContentType.ToString());
                TestOutput.WriteLine(await sut.Content.ReadAsStringAsync());

                Assert.Equal(HttpStatusCode.BadRequest, sut.StatusCode);
                Assert.Equal(HttpMethod.Get, sut.RequestMessage.Method);
                Assert.EndsWith("application/problem+json", sut.Content.Headers.ContentType.ToString());

                // sadly Microsoft does not use the formatter we feed into the pipeline .. they use their own horrid WriteJsonAsync implementation .. 
                Assert.StartsWith(@"{""type"":""https://docs.api-versioning.org/problems#invalid"",""title"":""Invalid API version"",""status"":400,""detail"":""The HTTP resource that matches the request URI \u0027http://localhost/fake/\u0027 does not support the API version \u0027b3\u0027.""}", await sut.Content.ReadAsStringAsync());
            }
        }

        [Fact]
        public async Task GetRequest_ShouldFailWithBadRequestFormattedAsXmlResponse_As_b3_IsAnUnknownVersion()
        {
            using (var app = WebApplicationTestFactory.Create(app =>
            {
                app.UseFaultDescriptorExceptionHandler(o =>
                {
                    o.NonMvcResponseHandlers
                        .AddXmlResponseHandler(Patterns.ConfigureRevertExchange<XmlFormatterOptions, ExceptionDescriptorOptions>(app.ApplicationServices.GetService<IOptions<XmlFormatterOptions>>()?.Value ?? new XmlFormatterOptions()))
                        .AddJsonResponseHandler(Patterns.ConfigureRevertExchange<JsonFormatterOptions, ExceptionDescriptorOptions>(app.ApplicationServices.GetService<IOptions<JsonFormatterOptions>>()?.Value ?? new JsonFormatterOptions()));
                });
                app.UseRestfulApiVersioning();
                app.UseRouting();
                app.UseEndpoints(routes => { routes.MapControllers(); });

            }, services =>
            {
                services.AddControllers(o => o.Filters.AddFaultDescriptor())
                    .AddApplicationPart(typeof(FakeController).Assembly)
                    .AddJsonFormatters();
                services.AddHttpContextAccessor();
                services.AddRestfulApiVersioning(o =>
                {
                    o.ValidAcceptHeaders.Clear();
                });
            }))
            {
                var client = app.Host.GetTestClient();
                client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9,application/xml;q=0.9");
                var sut = await client.GetAsync("/fake/throw");

                TestOutput.WriteLine(await sut.Content.ReadAsStringAsync());

                Assert.Equal(HttpStatusCode.BadRequest, sut.StatusCode);
                Assert.Equal(HttpMethod.Get, sut.RequestMessage.Method);
                Assert.EndsWith("application/xml", sut.Content.Headers.ContentType.ToString());
                Assert.Equal(@"<?xml version=""1.0"" encoding=""utf-8""?><HttpExceptionDescriptor><Error><Status>400</Status><Code>BadRequest</Code><Message>The HTTP resource that matches the request URI 'http://localhost/fake/throw' does not support the API version 'b3'.</Message></Error></HttpExceptionDescriptor>", await sut.Content.ReadAsStringAsync(), ignoreLineEndingDifferences: true);
            }
        }

        [Fact]
        public async Task GetRequest_ShouldFailWithBadRequestFormattedAsJsonResponse_As_b3_IsAnUnknownVersion()
        {
            using (var app = WebApplicationTestFactory.Create(app =>
                   {
                       app.UseFaultDescriptorExceptionHandler(o =>
                       {
                           o.NonMvcResponseHandlers
                               .AddJsonResponseHandler(Patterns.ConfigureRevertExchange<JsonFormatterOptions, ExceptionDescriptorOptions>(app.ApplicationServices.GetService<IOptions<JsonFormatterOptions>>()?.Value ?? new JsonFormatterOptions()))
                               .AddXmlResponseHandler(Patterns.ConfigureRevertExchange<XmlFormatterOptions, ExceptionDescriptorOptions>(app.ApplicationServices.GetService<IOptions<XmlFormatterOptions>>()?.Value ?? new XmlFormatterOptions()));
                       });
                       app.UseRouting();
                       app.UseEndpoints(routes => { routes.MapControllers(); });

                   }, services =>
                   {
                       services.AddControllers(o => o.Filters.AddFaultDescriptor())
                           .AddApplicationPart(typeof(FakeController).Assembly)
                           .AddJsonFormatters();
                       services.AddHttpContextAccessor();
                       services.AddRestfulApiVersioning(o =>
                       {
                           o.ValidAcceptHeaders.Clear();
                       });
                   }))
            {
                var client = app.Host.GetTestClient();
                client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9,application/json;q=10.0");
                var sut = await client.GetAsync("/fake/throw");

                TestOutput.WriteLine(await sut.Content.ReadAsStringAsync());

                Assert.Equal(HttpStatusCode.BadRequest, sut.StatusCode);
                Assert.Equal(HttpMethod.Get, sut.RequestMessage.Method);
                Assert.EndsWith("application/json", sut.Content.Headers.ContentType.ToString());
                Assert.Equal(@"{
  ""error"": {
    ""status"": 400,
    ""code"": ""BadRequest"",
    ""message"": ""The HTTP resource that matches the request URI \u0027http://localhost/fake/throw\u0027 does not support the API version \u0027b3\u0027.""
  }
}", await sut.Content.ReadAsStringAsync(), ignoreLineEndingDifferences: true);
            }
        }

        [Fact]
        public async Task GetRequest_ShouldFailWithBadRequestFormattedAsPlainResponse_As_b3_IsAnUnknownVersion()
        {
            using (var app = WebApplicationTestFactory.Create(app =>
            {
                app.UseFaultDescriptorExceptionHandler(o =>
                {
                    o.SensitivityDetails = FaultSensitivityDetails.All;
                });
                app.UseRouting();
                app.UseEndpoints(routes => { routes.MapControllers(); });

            }, services =>
            {
                services.AddControllers(o => o.Filters.AddFaultDescriptor())
                    .AddApplicationPart(typeof(FakeController).Assembly)
                    .AddJsonFormatters();
                services.AddHttpContextAccessor();
                services.AddRestfulApiVersioning(o =>
                {
                    o.ValidAcceptHeaders.Clear();
                });
                services.Configure<MvcFaultDescriptorOptions>(o =>
                {
                    o.SensitivityDetails = FaultSensitivityDetails.Evidence;
                });
                services.Configure<XmlFormatterOptions>(o =>
                {
                    o.SensitivityDetails = FaultSensitivityDetails.Failure | FaultSensitivityDetails.StackTrace;
                });
                services.Configure<JsonFormatterOptions>(o =>
                {
                    o.SensitivityDetails = FaultSensitivityDetails.Failure | FaultSensitivityDetails.StackTrace;
                });
            }))
            {
                var client = app.Host.GetTestClient();
                client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9,application/json;q=10.0");
                var sut = await client.GetAsync("/fake/throw");

                TestOutput.WriteLine(await sut.Content.ReadAsStringAsync());

                Assert.Equal(HttpStatusCode.BadRequest, sut.StatusCode);
                Assert.Equal(HttpMethod.Get, sut.RequestMessage.Method);
                Assert.EndsWith("text/plain", sut.Content.Headers.ContentType.ToString());
                Assert.StartsWith(@"Error: 
  Status: 400
  Code: BadRequest
  Message: The HTTP resource that matches the request URI 'http://localhost/fake/throw' does not support the API version 'b3'.
  Failure: 
    Type: Cuemon.AspNetCore.Http.BadRequestException
    Source: Cuemon.Extensions.Asp.Versioning
    Message: The HTTP resource that matches the request URI 'http://localhost/fake/throw' does not support the API version 'b3'.
    Stack: 
", await sut.Content.ReadAsStringAsync());
                Assert.EndsWith(@"
Evidence: 
  Request: 
    Location: http://localhost/fake/throw
    Method: GET
    Headers: 
      Accept: 
        - text/html
        - application/xhtml+xml
        - image/avif
        - image/webp
        - image/apng
        - */*; q=0.8
        - application/signed-exchange; v=b3; q=0.9
        - application/json; q=10.0
      Host: 
        - localhost
    Query: []
    Cookies: []
    Body: ", await sut.Content.ReadAsStringAsync());
            }
        }

        [Fact]
        public async Task GetRequest_ShouldThrowABadRequestException_As_b3_IsAnUnknownVersion()
        {
            using (var app = WebApplicationTestFactory.Create(app =>
                   {
                       app.UseRouting();
                       app.UseEndpoints(routes => { routes.MapControllers(); });
                   }, services =>
                   {
                       services.AddControllers().AddApplicationPart(typeof(FakeController).Assembly);
                       services.AddRestfulApiVersioning(o =>
                       {
                           o.ValidAcceptHeaders.Clear();
                       });
                   }))
            {
                var client = app.Host.GetTestClient();
                client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");

                await Assert.ThrowsAsync<BadRequestException>(() => client.GetAsync("/fake/"));
            }
        }
    }
}
