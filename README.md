![Cuemon for .NET](https://nblcdn.net/cuemon/128x128.png)

# Cuemon for .NET

An open-source project (MIT license) that targets and complements the Microsoft .NET platform. It provides vast ways of possibilities for all breeds of coders, programmers, developers and the likes thereof.
Your ideal companion for .NET 6, .NET 5, .NET Core 3.1, .NET Standard 2, Universal Windows Platform and .NET Framework 4.6.1 and newer.

It is, by heart, free, flexible and built to extend and boost your agile codebelt.

## State of the Union

Cuemon for .NET (formerly Cuemon .NET Standard) has been completely refactored and updated to support .NET 5.

Check out the documentation (generated by DocFx): https://docs.cuemon.net/

All CI and CD integrations are done on [Microsoft Azure DevOps](https://azure.microsoft.com/en-us/services/devops/) and is currently in the process of being tweaked.

All code quality analysis are done by [SonarCloud](https://sonarcloud.io/) and [CodeCov.io](https://codecov.io/).

![License](https://img.shields.io/github/license/gimlichael/cuemon) [![Build Status](https://dev.azure.com/gimlichael/Cuemon/_apis/build/status/gimlichael.Cuemon?branchName=development)](https://dev.azure.com/gimlichael/Cuemon/_build/latest?definitionId=9&branchName=development) [![codecov](https://codecov.io/gh/gimlichael/Cuemon/branch/development/graph/badge.svg)](https://codecov.io/gh/gimlichael/Cuemon) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=Cuemon&metric=coverage)](https://sonarcloud.io/dashboard?id=Cuemon) [![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-2.0-4baaaa.svg)](.github/CODE_OF_CONDUCT.md)


## Development Branch

The `development` branch contains the latest (and greatest) version of the code.

To consume a CI build, create a `NuGet.Config` in your root solution directory and add following content:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <!-- Cuemon CI build feed -->
    <add key="cuemon" value="https://nuget.cuemon.net/v3/index.json" />
    <!-- Defaul nuget feed -->
    <add key="nuget" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
</configuration>
```
Do note, that builds from development are preview builds and not to be considered stable.

Once tested thoroughly and feature milestone has been reached, the code will be pushed and merged to a new branch; `release`.

## Release Branch

The `release` branch contains the next version of Cuemon for .NET. Here it will be tested again while the next semantic version is being determined.

All CI builds are pushed to NuGet.org as either `alpha`, `beta` or `rc` releases (when deemed fit for purpose). For more information, check out [Package versioning - Pre-release Versions](https://docs.microsoft.com/en-us/nuget/concepts/package-versioning#pre-release-versions) at Microsoft.

Lastly, when things are looking all fine and dandy, the code will be pushed and merged to the `master` branch.

## Master Branch

The `master` branch always contains the current `production` ready version of Cuemon for .NET.

Builds performed from this repository are pushed to NuGet.org as the actual version they represent.

### Code Quality Monitoring

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Cuemon&metric=alert_status)](https://sonarcloud.io/dashboard?id=Cuemon) [![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=Cuemon&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=Cuemon) [![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=Cuemon&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=Cuemon) [![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=Cuemon&metric=security_rating)](https://sonarcloud.io/dashboard?id=Cuemon)

[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=Cuemon&metric=ncloc)](https://sonarcloud.io/dashboard?id=Cuemon) [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=Cuemon&metric=code_smells)](https://sonarcloud.io/dashboard?id=Cuemon) [![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=Cuemon&metric=sqale_index)](https://sonarcloud.io/dashboard?id=Cuemon) [![Bugs](https://sonarcloud.io/api/project_badges/measure?project=Cuemon&metric=bugs)](https://sonarcloud.io/dashboard?id=Cuemon) [![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=Cuemon&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=Cuemon) [![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=Cuemon&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=Cuemon)

# Contributing to Cuemon for .NET

A big welcome and thank you for considering contributing to Cuemon for .NET open source project!

Please read more about [contributing to Cuemon for .NET](.github/CONTRIBUTING.md).

# Code of Conduct

Project maintainers pledge to foster an open and welcoming environment, and ask contributors to do the same.

For more information see our [code of conduct](.github/CODE_OF_CONDUCT.md).

## Links to NuGet packages

NuGet links to all projects of Cuemon for .NET:

* [Cuemon.AspNetCore](https://www.nuget.org/packages/Cuemon.AspNetCore/)
* [Cuemon.AspNetCore.App](https://www.nuget.org/packages/Cuemon.AspNetCore.App/) *
* [Cuemon.AspNetCore.Authentication](https://www.nuget.org/packages/Cuemon.AspNetCore.Authentication/)
* [Cuemon.AspNetCore.Mvc](https://www.nuget.org/packages/Cuemon.AspNetCore.Mvc/)
* [Cuemon.AspNetCore.Razor.TagHelpers](https://www.nuget.org/packages/Cuemon.AspNetCore.Razor.TagHelpers/)
* [Cuemon.Core](https://www.nuget.org/packages/Cuemon.Core/)
* [Cuemon.Core.App](https://www.nuget.org/packages/Cuemon.Core.App/) *
* [Cuemon.Data](https://www.nuget.org/packages/Cuemon.Data/)
* [Cuemon.Data.Integrity](https://www.nuget.org/packages/Cuemon.Data.Integrity/)
* [Cuemon.Data.SqlClient](https://www.nuget.org/packages/Cuemon.Data.SqlClient/)
* [Cuemon.Diagnostics](https://www.nuget.org/packages/Cuemon.Diagnostics/)
* [Cuemon.Extensions.AspNetCore](https://www.nuget.org/packages/Cuemon.Extensions.AspNetCore/)
* [Cuemon.Extensions.AspNetCore.Authentication](https://www.nuget.org/packages/Cuemon.Extensions.AspNetCore.Authentication/)
* [Cuemon.Extensions.AspNetCore.Mvc](https://www.nuget.org/packages/Cuemon.Extensions.AspNetCore.Mvc/)
* [Cuemon.Extensions.AspNetCore.Mvc.Formatters.Newtonsoft.Json](https://www.nuget.org/packages/Cuemon.Extensions.AspNetCore.Mvc.Formatters.Newtonsoft.Json/)
* [Cuemon.Extensions.AspNetCore.Mvc.Formatters.Xml](https://www.nuget.org/packages/Cuemon.Extensions.AspNetCore.Mvc.Formatters.Xml/)
* [Cuemon.Extensions.AspNetCore.Mvc.RazorPages](https://www.nuget.org/packages/Cuemon.Extensions.AspNetCore.Mvc.RazorPages/)
* [Cuemon.Extensions.Collections.Generic](https://www.nuget.org/packages/Cuemon.Extensions.Collections.Generic/)
* [Cuemon.Extensions.Collections.Specialized](https://www.nuget.org/packages/Cuemon.Extensions.Collections.Specialized/)
* [Cuemon.Extensions.Core](https://www.nuget.org/packages/Cuemon.Extensions.Core/)
* [Cuemon.Extensions.Data](https://www.nuget.org/packages/Cuemon.Extensions.Data/)
* [Cuemon.Extensions.Data.Integrity](https://www.nuget.org/packages/Cuemon.Extensions.Data.Integrity/)
* [Cuemon.Extensions.DependencyInjection](https://www.nuget.org/packages/Cuemon.Extensions.DependencyInjection/)
* [Cuemon.Extensions.Diagnostics](https://www.nuget.org/packages/Cuemon.Extensions.Diagnostics/)
* [Cuemon.Extensions.Hosting](https://www.nuget.org/packages/Cuemon.Extensions.Hosting/)
* [Cuemon.Extensions.IO](https://www.nuget.org/packages/Cuemon.Extensions.IO/)
* [Cuemon.Extensions.Net](https://www.nuget.org/packages/Cuemon.Extensions.Net/)
* [Cuemon.Extensions.Newtonsoft.Json](https://www.nuget.org/packages/Cuemon.Extensions.Newtonsoft.Json/)
* [Cuemon.Extensions.Reflection](https://www.nuget.org/packages/Cuemon.Extensions.Reflection/)
* [Cuemon.Extensions.Runtime.Caching](https://www.nuget.org/packages/Cuemon.Extensions.Runtime.Caching/)
* [Cuemon.Extensions.Text](https://www.nuget.org/packages/Cuemon.Extensions.Text/)
* [Cuemon.Extensions.Threading](https://www.nuget.org/packages/Cuemon.Extensions.Threading/)
* [Cuemon.Extensions.Xml](https://www.nuget.org/packages/Cuemon.Extensions.Xml/)
* [Cuemon.Extensions.Xunit](https://www.nuget.org/packages/Cuemon.Extensions.Xunit/)
* [Cuemon.Extensions.Xunit.App](https://www.nuget.org/packages/Cuemon.Extensions.Xunit.App/) *
* [Cuemon.Extensions.Xunit.Hosting](https://www.nuget.org/packages/Cuemon.Extensions.Xunit.Hosting/)
* [Cuemon.Extensions.Xunit.Hosting.AspNetCore](https://www.nuget.org/packages/Cuemon.Extensions.Xunit.Hosting.AspNetCore/)
* [Cuemon.Extensions.Xunit.Hosting.AspNetCore.Mvc](https://www.nuget.org/packages/Cuemon.Extensions.Xunit.Hosting.AspNetCore.Mvc/)
* [Cuemon.IO](https://www.nuget.org/packages/Cuemon.IO/)
* [Cuemon.Net](https://www.nuget.org/packages/Cuemon.Net/)
* [Cuemon.Resilience](https://www.nuget.org/packages/Cuemon.Resilience/)
* [Cuemon.Runtime.Caching](https://www.nuget.org/packages/Cuemon.Runtime.Caching/)
* [Cuemon.Security.Cryptography](https://www.nuget.org/packages/Cuemon.Security.Cryptography/)
* [Cuemon.Threading](https://www.nuget.org/packages/Cuemon.Threading/)
* [Cuemon.Xml](https://www.nuget.org/packages/Cuemon.Xml/)

*) Provides a convenient set of default API additions for building various types of .NET projects.