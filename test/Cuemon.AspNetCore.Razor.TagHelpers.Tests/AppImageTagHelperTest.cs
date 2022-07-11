﻿using System.Threading.Tasks;
using Cuemon.AspNetCore.Razor.TagHelpers.Assets;
using Cuemon.Extensions.AspNetCore.Configuration;
using Cuemon.Extensions.Xunit;
using Cuemon.Extensions.Xunit.Hosting.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Cuemon.AspNetCore.Razor.TagHelpers
{
    public class AppImageTagHelperTest : Test
    {
        public AppImageTagHelperTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task Page_RenderImageTagForAppRole()
        {
            using (var filter = WebApplicationTestFactory.Create(app =>
            {
                app.UseRouting();
                app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
            }, services =>
            {
                services.AddRazorPages();
                services.Configure<CdnTagHelperOptions>(o =>
                {
                    o.Scheme = ProtocolUriScheme.Https;
                    o.BaseUrl = "nblcdn.net";
                });
                services.Configure<AppTagHelperOptions>(o =>
                {
                    o.Scheme = ProtocolUriScheme.Relative;
                    o.BaseUrl = "static.cuemon.net";
                });
            }))
            {
                var client = filter.Host.GetTestClient();
                var result = await client.GetAsync("/AppImageTagHelper");
                var body = await result.Content.ReadAsStringAsync();

                TestOutput.WriteLine(body);

                Assert.Equal(@"<img class=""hero-logo-image"" src=""//static.cuemon.net/cuemon-logo.svg"" alt=""Cuemon for .NET"">", body, ignoreLineEndingDifferences: true);
            }
        }

        [Fact]
        public async Task Page_RenderImageTagForAppRole_WithCacheBusting()
        {
            using (var filter = WebApplicationTestFactory.Create(app =>
            {
                app.UseRouting();
                app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
            }, services =>
            {
                services.AddCacheBusting<FakeCacheBusting>();
                services.AddRazorPages();
                services.Configure<CdnTagHelperOptions>(o =>
                {
                    o.Scheme = ProtocolUriScheme.Https;
                    o.BaseUrl = "nblcdn.net";
                });
                services.Configure<AppTagHelperOptions>(o =>
                {
                    o.Scheme = ProtocolUriScheme.Relative;
                    o.BaseUrl = "static.cuemon.net";
                });
            }))
            {
                var client = filter.Host.GetTestClient();
                var result = await client.GetAsync("/AppImageTagHelper");
                var body = await result.Content.ReadAsStringAsync();

                TestOutput.WriteLine(body);

                Assert.Equal(@"<img class=""hero-logo-image"" src=""//static.cuemon.net/cuemon-logo.svg?v=00000000000000000000000000000000"" alt=""Cuemon for .NET"">", body, ignoreLineEndingDifferences: true);
            }
        }
    }
}
