![Cuemon for .NET](https://nblcdn.net/cuemon/128x128.png)

# Cuemon for .NET

An open-source project (MIT license) that targets and complements the Microsoft .NET platform. It provides vast ways of possibilities for all breeds of coders, programmers, developers and the likes thereof.
Your ideal companion for .NET 8, .NET 6, .NET Standard 2 and .NET Framework 4.6.2 and newer.

It is, by heart, free, flexible and built to extend and boost your agile codebelt.

## State of the Union

Cuemon for .NET (formerly Cuemon .NET Standard) has been completely refactored and updated to support .NET 8 (LTS) and .NET 6 (LTS).

Support for .NET Core 3.0, .NET Core 3.1, .NET 5 and .NET 7 has been deprecated as these are out of [support](https://endoflife.date/dotnet). 

> [!IMPORTANT]
> Version 8.3.1 of Cuemon for .NET will be the last version to support .NET 7.

Full documentation (generated by [DocFx](https://github.com/dotnet/docfx)) located here: https://docs.cuemon.net/

All CI and CD integrations have been migrated away from [Microsoft Azure DevOps](https://azure.microsoft.com/en-us/services/devops/) and now embraces GitHub Actions based on the [Codebelt](https://github.com/codebeltnet) umbrella.

All code quality analysis are done by [SonarCloud](https://sonarcloud.io/) and [CodeCov.io](https://codecov.io/).

![License](https://img.shields.io/github/license/gimlichael/cuemon) ![Build Status](https://github.com/gimlichael/Cuemon/actions/workflows/pipelines.yml/badge.svg?branch=main) [![codecov](https://codecov.io/gh/gimlichael/Cuemon/branch/development/graph/badge.svg)](https://codecov.io/gh/gimlichael/Cuemon) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=Cuemon&metric=coverage)](https://sonarcloud.io/dashboard?id=Cuemon) [![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-2.0-4baaaa.svg)](.github/CODE_OF_CONDUCT.md)

## Branching Strategy

We have finally moved away from the somewhat dated `git flow` branching strategy, and adapted `trunk` based branching that is more aligned with todays DevSecOps practices.

That means, going forward, only one branch will be maintained; `main`. The previous branches, `development`, `release` and `master` is for reference only.

> [!NOTE]
> `main` branch will be a clean slate starting from v8.3.1, meaning no previous commits will be preserved. Previous bad practices is a result of this, and going forward we will use Squash or Rebase before committing new code.

## Tag Versioning

We will continue using semantic versioning and account for [pre-release](https://docs.microsoft.com/en-us/nuget/concepts/package-versioning#pre-release-versions) versions when tagging in git.

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

This is a list of all NuGet packages from Cuemon for .NET that is publicly available on [NuGet.org](https://www.nuget.org/packages?q=cuemon); the packages here are listed alphabetically and are available in preview-, rc- and production-ready versions.

### 📦 Standalone Packages

Provides a focused API for building various types of .NET projects.

|Package|vNext|Stable|Downloads|
|:--|:-:|:-:|:-:|
| [Cuemon.AspNetCore](https://www.nuget.org/packages/Cuemon.AspNetCore/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.AspNetCore?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.AspNetCore?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.AspNetCore?color=blueviolet&logo=nuget) |
| [Cuemon.AspNetCore.Authentication](https://www.nuget.org/packages/Cuemon.AspNetCore.Authentication/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.AspNetCore.Authentication?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.AspNetCore.Authentication?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.AspNetCore.Authentication?color=blueviolet&logo=nuget) |
| [Cuemon.AspNetCore.Mvc](https://www.nuget.org/packages/Cuemon.AspNetCore.Mvc/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.AspNetCore.Mvc?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.AspNetCore.Mvc?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.AspNetCore.Mvc?color=blueviolet&logo=nuget) |
| [Cuemon.AspNetCore.Razor.TagHelpers](https://www.nuget.org/packages/Cuemon.AspNetCore.Razor.TagHelpers/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.AspNetCore.Razor.TagHelpers?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.AspNetCore.Razor.TagHelpers?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.AspNetCore.Razor.TagHelpers?color=blueviolet&logo=nuget) |
| [Cuemon.Core](https://www.nuget.org/packages/Cuemon.Core/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Core?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Core?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Core?color=blueviolet&logo=nuget) |
| [Cuemon.Data](https://www.nuget.org/packages/Cuemon.Data/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Data?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Data?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Data?color=blueviolet&logo=nuget) |
| [Cuemon.Data.Integrity](https://www.nuget.org/packages/Cuemon.Data.Integrity/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Data.Integrity?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Data.Integrity?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Data.Integrity?color=blueviolet&logo=nuget) |
| [Cuemon.Data.SqlClient](https://www.nuget.org/packages/Cuemon.Data.SqlClient/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Data.SqlClient?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Data.SqlClient?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Data.SqlClient?color=blueviolet&logo=nuget) |
| [Cuemon.Diagnostics](https://www.nuget.org/packages/Cuemon.Diagnostics/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Diagnostics?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Diagnostics?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Diagnostics?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.AspNetCore](https://www.nuget.org/packages/Cuemon.Extensions.AspNetCore/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.AspNetCore?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.AspNetCore?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.AspNetCore?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.AspNetCore.Authentication](https://www.nuget.org/packages/Cuemon.Extensions.AspNetCore.Authentication/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.AspNetCore.Authentication?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.AspNetCore.Authentication?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.AspNetCore.Authentication?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.AspNetCore.Authentication.AwsSignature4](https://www.nuget.org/packages/Cuemon.Extensions.AspNetCore.Authentication.AwsSignature4/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.AspNetCore.Authentication.AwsSignature4?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.AspNetCore.Authentication.AwsSignature4?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.AspNetCore.Authentication.AwsSignature4?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.AspNetCore.Mvc](https://www.nuget.org/packages/Cuemon.Extensions.AspNetCore.Mvc/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.AspNetCore.Mvc?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.AspNetCore.Mvc?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.AspNetCore.Mvc?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.AspNetCore.Mvc.Formatters.Text.Json](https://www.nuget.org/packages/Cuemon.Extensions.AspNetCore.Mvc.Formatters.Text.Json/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.AspNetCore.Mvc.Formatters.Text.Json?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.AspNetCore.Mvc.Formatters.Text.Json?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.AspNetCore.Mvc.Formatters.Text.Json?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.AspNetCore.Mvc.Formatters.Xml](https://www.nuget.org/packages/Cuemon.Extensions.AspNetCore.Mvc.Formatters.Xml/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.AspNetCore.Mvc.Formatters.Xml?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.AspNetCore.Mvc.Formatters.Xml?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.AspNetCore.Mvc.Formatters.Xml?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.AspNetCore.Mvc.RazorPages](https://www.nuget.org/packages/Cuemon.Extensions.AspNetCore.Mvc.RazorPages/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.AspNetCore.Mvc.RazorPages?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.AspNetCore.Mvc.RazorPages?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.AspNetCore.Mvc.RazorPages?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.AspNetCore.Text.Json](https://www.nuget.org/packages/Cuemon.Extensions.AspNetCore.Text.Json/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.AspNetCore.Text.Json?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.AspNetCore.Text.Json?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.AspNetCore.Text.Json?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.AspNetCore.Xml](https://www.nuget.org/packages/Cuemon.Extensions.AspNetCore.Xml/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.AspNetCore.Xml?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.AspNetCore.Xml?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.AspNetCore.Xml?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.Collections.Generic](https://www.nuget.org/packages/Cuemon.Extensions.Collections.Generic/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.Collections.Generic?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.Collections.Generic?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.Collections.Generic?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.Collections.Specialized](https://www.nuget.org/packages/Cuemon.Extensions.Collections.Specialized/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.Collections.Specialized?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.Collections.Specialized?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.Collections.Specialized?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.Core](https://www.nuget.org/packages/Cuemon.Extensions.Core/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.Core?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.Core?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.Core?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.Data](https://www.nuget.org/packages/Cuemon.Extensions.Data/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.Data?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.Data?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.Data?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.Data.Integrity](https://www.nuget.org/packages/Cuemon.Extensions.Data.Integrity/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.Data.Integrity?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.Data.Integrity?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.Data.Integrity?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.DependencyInjection](https://www.nuget.org/packages/Cuemon.Extensions.DependencyInjection/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.DependencyInjection?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.DependencyInjection?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.DependencyInjection?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.Diagnostics](https://www.nuget.org/packages/Cuemon.Extensions.Diagnostics/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.Diagnostics?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.Diagnostics?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.Diagnostics?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.Globalization](https://www.nuget.org/packages/Cuemon.Extensions.Globalization/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.Globalization?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.Globalization?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.Globalization?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.Hosting](https://www.nuget.org/packages/Cuemon.Extensions.Hosting/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.Hosting?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.Hosting?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.Hosting?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.IO](https://www.nuget.org/packages/Cuemon.Extensions.IO/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.IO?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.IO?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.IO?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.Net](https://www.nuget.org/packages/Cuemon.Extensions.Net/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.Net?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.Net?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.Net?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.Reflection](https://www.nuget.org/packages/Cuemon.Extensions.Reflection/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.Reflection?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.Reflection?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.Reflection?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.Runtime.Caching](https://www.nuget.org/packages/Cuemon.Extensions.Runtime.Caching/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.Runtime.Caching?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.Runtime.Caching?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.Runtime.Caching?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.Text](https://www.nuget.org/packages/Cuemon.Extensions.Text/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.Text?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.Text?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.Text?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.Text.Json](https://www.nuget.org/packages/Cuemon.Extensions.Text.Json/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.Text.Json?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.Text.Json?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.Text.Json?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.Threading](https://www.nuget.org/packages/Cuemon.Extensions.Threading/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.Threading?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.Threading?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.Threading?color=blueviolet&logo=nuget) |
| [Cuemon.Extensions.Xml](https://www.nuget.org/packages/Cuemon.Extensions.Xml/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Extensions.Xml?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Extensions.Xml?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.Xml?color=blueviolet&logo=nuget) |
| [Cuemon.IO](https://www.nuget.org/packages/Cuemon.IO/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.IO?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.IO?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.IO?color=blueviolet&logo=nuget) |
| [Cuemon.Net](https://www.nuget.org/packages/Cuemon.Net/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Net?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Net?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Net?color=blueviolet&logo=nuget) |
| [Cuemon.Resilience](https://www.nuget.org/packages/Cuemon.Resilience/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Resilience?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Resilience?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Resilience?color=blueviolet&logo=nuget) |
| [Cuemon.Runtime.Caching](https://www.nuget.org/packages/Cuemon.Runtime.Caching/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Runtime.Caching?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Runtime.Caching?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Runtime.Caching?color=blueviolet&logo=nuget) |
| [Cuemon.Security.Cryptography](https://www.nuget.org/packages/Cuemon.Security.Cryptography/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Security.Cryptography?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Security.Cryptography?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Security.Cryptography?color=blueviolet&logo=nuget) |
| [Cuemon.Threading](https://www.nuget.org/packages/Cuemon.Threading/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Threading?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Threading?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Threading?color=blueviolet&logo=nuget) |
| [Cuemon.Xml](https://www.nuget.org/packages/Cuemon.Xml/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Xml?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Xml?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Xml?color=blueviolet&logo=nuget) |

### 🏭 Productivity Packages

Provides a convenient set of default API additions for building various types of .NET projects.

|Package|vNext|Stable|Downloads|
|:--|:-:|:-:|:-:|
| [Cuemon.AspNetCore.App](https://www.nuget.org/packages/Cuemon.AspNetCore.App/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.AspNetCore.App?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.AspNetCore.App?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.AspNetCore.App?color=blueviolet&logo=nuget) |
| [Cuemon.Core.App](https://www.nuget.org/packages/Cuemon.Core.App/) | ![vNext](https://img.shields.io/nuget/vpre/Cuemon.Core.App?logo=nuget) | ![Stable](https://img.shields.io/nuget/v/Cuemon.Core.App?logo=nuget) | ![Downloads](https://img.shields.io/nuget/dt/Cuemon.Core.App?color=blueviolet&logo=nuget) |

# Credits & Appreciation

Building a sort-of sidecar for .NET is not an easy task; a lot of time, effort and refactoring is needed.

We are incredibly grateful to all of our sponsors.

## JetBrains

[ReSharper](https://www.jetbrains.com/resharper/) from [JetBrains](https://www.jetbrains.com/) is an indispensable Visual Studio extension that makes development, refactoring and unit testing a bliss to work with.

## Submain

[GhostDoc Pro](https://submain.com/GhostDoc/editions/) from [SubMain](https://submain.com) is used to write the majority of source code documentation.
