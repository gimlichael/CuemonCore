﻿using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cuemon.AspNetCore.Mvc.Filters.Diagnostics;
using Cuemon.Extensions.AspNetCore.Mvc.Formatters.Text.Json.Assets;
using Cuemon.Extensions.IO;
using Cuemon.Extensions.Text.Json.Converters;
using Cuemon.Extensions.Text.Json.Formatters;
using Cuemon.Extensions.Xunit;
using Cuemon.Extensions.Xunit.Hosting.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Cuemon.Extensions.AspNetCore.Mvc.Formatters.Text.Json
{
    public class JsonSerializationInputFormatterTest : Test
    {
        public JsonSerializationInputFormatterTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Ctor_VerifyThatUtf8AndUtf16_WasAdded_ToSupportedEncodings()
        {
            var sut = new JsonSerializationInputFormatter(new JsonFormatterOptions());

            Assert.Equal(2, sut.SupportedEncodings.Count);
            Assert.Collection(sut.SupportedEncodings,
                e => Assert.Equal(Encoding.UTF8, e),
                e => Assert.Equal(Encoding.Unicode, e));
        }

        [Fact]
        public void Ctor_VerifyThatApplicationJsonAndTextJson_WasAdded_ToSupportedMediaTypes()
        {
            var sut = new JsonSerializationInputFormatter(new JsonFormatterOptions());

            Assert.Equal(2, sut.SupportedMediaTypes.Count);
            Assert.Collection(sut.SupportedMediaTypes,
                s => Assert.Contains("application/json", s),
                s => Assert.Contains("text/json", s));
        }

        [Fact]
        public async Task ReadRequestBodyAsync_ShouldReturnCreated()
        {
            using (var filter = WebApplicationTestFactory.CreateWebApplicationTest(app =>
            {
                app.UseRouting();
                app.UseEndpoints(routes => { routes.MapControllers(); });
            }, services =>
            {
                services.AddControllers(o => { o.Filters.Add<FaultDescriptorFilter>(); })
                    .AddApplicationPart(typeof(FakeController).Assembly)
                    .AddJsonFormatters(o => o.Settings.Converters.AddDateTimeConverter());
            }))
            {
                var wf = new WeatherForecast();
                var formatter = new JsonFormatter(o => o.Settings.WriteIndented = true);
                var stream = formatter.Serialize(wf);
                var client = filter.Host.GetTestClient();

                await Task.Delay(1000);

                var result = await client.PostAsync("/fake", new StringContent(stream.ToEncodedString(o => o.LeaveOpen = true), Encoding.UTF8, "application/json"));
                var model = await result.Content.ReadAsStringAsync();

                TestOutput.WriteLine(stream.ToEncodedString(o => o.LeaveOpen = true));
                TestOutput.WriteLine("---");
                TestOutput.WriteLine(model);

                Assert.Equal(stream.ToEncodedString(), model, ignoreLineEndingDifferences: true);

                Assert.Equal(StatusCodes.Status201Created, (int)result.StatusCode);
                Assert.Equal(HttpMethod.Post, result.RequestMessage.Method);
                Assert.Equal(new Uri("http://localhost/fake"), result.RequestMessage.RequestUri);
            }
        }
    }
}
