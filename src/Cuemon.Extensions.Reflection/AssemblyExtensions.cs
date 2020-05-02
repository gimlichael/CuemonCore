﻿using System;
using System.Reflection;
using Cuemon.Reflection;

namespace Cuemon.Extensions.Reflection
{
    /// <summary>
    /// Extension methods for the <see cref="Assembly"/> class.
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Returns a <see cref="Version"/> that represents the version number of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly to resolve a <see cref="Version"/> from.</param>
        /// <returns>A <see cref="Version"/> that represents the version number of the specified <paramref name="assembly"/>.</returns>
        public static Version GetAssemblyVersion(this Assembly assembly)
        {
            return AssemblyInsight.FromAssembly(assembly).GetAssemblyVersion();
        }

        /// <summary>
        /// Returns a <see cref="Version"/> that represents the file version number of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly to resolve a <see cref="Version"/> from.</param>
        /// <returns>A <see cref="Version"/> that represents the file version number of the specified <paramref name="assembly"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="assembly"/> is null.
        /// </exception>
        public static Version GetFileVersion(this Assembly assembly)
        {
            return AssemblyInsight.FromAssembly(assembly).GetFileVersion();
        }

        /// <summary>
        /// Returns a <see cref="Version"/> that represents the version of the product this <paramref name="assembly"/> is distributed with.
        /// </summary>
        /// <param name="assembly">The assembly to resolve a <see cref="Version"/> from.</param>
        /// <returns>A <see cref="Version"/> that represents the version of the product this <paramref name="assembly"/> is distributed with.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="assembly"/> is null.
        /// </exception>
        public static Version GetProductVersion(this Assembly assembly)
        {
            return AssemblyInsight.FromAssembly(assembly).GetProductVersion();
        }

        /// <summary>
        /// Determines whether the specified <paramref name="assembly"/> is a debug build.
        /// </summary>
        /// <param name="assembly">The assembly to parse and determine whether it is a debug build or not.</param>
        /// <returns><c>true</c> if the specified <paramref name="assembly"/> is a debug build; otherwise, <c>false</c>.</returns>
        public static bool IsDebugBuild(this Assembly assembly)
        {
            return AssemblyInsight.FromAssembly(assembly).IsDebugBuild();
        }
    }
}